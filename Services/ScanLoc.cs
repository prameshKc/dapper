using Jumbotron.DataContext;
using Jumbotron.Models;
using Jumbotron.Services.Interfaces;
using Jumbotron.ViewModels;

namespace Jumbotron.Services
{
    public class ScanLoc : IScanLoc
    {
        private readonly SPContext _context;
        private readonly IDapperImplementor _dapper;


        public ScanLoc(SPContext context, IDapperImplementor dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public List<TruckDetailViewModel> GetTruckDetails(DateTime date)
        {
            //date = new DateTime(2022, 03, 09);
            var groupedScanLocs = _context.Set<Tscanloc>()
                .Where(o => o.RecUdtTs.Date == date.Date && !string.IsNullOrWhiteSpace(o.UloNr) && o.BcdEvtTypCd.Equals("05"))
                .ToList()
                .GroupBy(o => o.EmpIdNr);

            var result = new List<TruckDetailViewModel>();

            foreach (var groupedScanLoc in groupedScanLocs)
            {
                var truckDetailViewModel = new TruckDetailViewModel
                {
                    Id = groupedScanLoc.Key,
                    //TotalMisloads = groupedScanLoc.DistinctBy(o => o.SnObjTckNr).Count(o => o.BcdEvtTypCd.Equals("05"))
                };

                foreach (var item in groupedScanLoc)
                {
                    var hasMisload = item.BcdEvtTypCd.Equals("05");
                    if (!hasMisload) continue;
                    //Check if it was resolved later
                    var getScannedEventType = _context
                        .Tscanlocs
                        .FirstOrDefault(o => o.SnObjTckNr.Equals(item.SnObjTckNr) && o.BcdEvtTypCd.Equals("24"));

                    if (getScannedEventType == null || item.RecUdtTs > getScannedEventType.RecUdtTs)
                        truckDetailViewModel.TotalMisloads++;
                }

                truckDetailViewModel.HasMisload = truckDetailViewModel.TotalMisloads > 0;
                // Change DateTime.Now to DateTime.UtcNow
                var possibleMisloadTimeInterval = (int)DateTime.UtcNow
                    .Subtract(groupedScanLoc.OrderByDescending(o => o.RecUdtTs)
                    .First().RecUdtTs)
                    .TotalMinutes;

                truckDetailViewModel.MisloadNotificationReceivedTimeInterval = truckDetailViewModel.HasMisload
                    ? possibleMisloadTimeInterval == 0 ? 1 : possibleMisloadTimeInterval
                    : 0;

                // var totalPiecesLoaded = groupedScanLoc.Count();

                //  var loadingStartTime = groupedScanLoc.OrderBy(o => o.RecUdtTs).First().RecUdtTs;
                // var loadingEndTime = groupedScanLoc.OrderBy(o => o.RecUdtTs).Last().RecUdtTs;
                // var totalTimeTakenToLoad = loadingEndTime.Subtract(loadingStartTime).TotalMinutes;

                // truckDetailViewModel.Pph = (int)(totalPiecesLoaded / totalTimeTakenToLoad * 60); 

                // truckDetailViewModel.Margin = truckDetailViewModel.HasMisload ? $"{Random.Shared.Next(0, 77)}%" : $"{Random.Shared.Next(0, 88)}%";

                truckDetailViewModel.Margin = CalculateMargin(truckDetailViewModel.HasMisload, truckDetailViewModel.MisloadNotificationReceivedTimeInterval);

                var groupedUloList = groupedScanLoc.GroupBy(p => p.UloNr);
                var uloDetails = new List<UloDetailViewModel>();

                foreach (var item in groupedUloList)
                {
                    var latestEvent = item.OrderByDescending(p => p.RecUdtTs).First();
                    var detail = new UloDetailViewModel
                    {
                        // BeltBay = Random.Shared.Next(110, 119).ToString(),
                        BeltBay = latestEvent.Workarea,
                        RouteId = latestEvent.PlnPkgRteNr,
                        PackageCar = item.Key,
                        HasMisload = latestEvent.BcdEvtTypCd.Equals("05")
                    };
                    uloDetails.Add(detail);
                }
                truckDetailViewModel.UloDetailViewModels.AddRange(uloDetails);
                result.Add(truckDetailViewModel);
            }

            return result;
        }

        public List<LoadQualityByWorkAreaViewModel> GetLoadQualityByWorkArea(DateTime date)
        {
            //date = new DateTime(2022, 03, 09);
            var groupedScanLocs = _context.Set<Tscanloc>()
                .Where(o => o.RecUdtTs.Date == date.Date && !string.IsNullOrEmpty(o.PriInstruction))
                .ToList()
                .GroupBy(o => o.PriInstruction);

            var result = new List<LoadQualityByWorkAreaViewModel>();

            foreach (var groupedScanLoc in groupedScanLocs)
            {
                var loadAreaWorkDetail = new LoadQualityByWorkAreaViewModel
                {
                    Id = groupedScanLoc.Key,
                    TotalMisloads = groupedScanLoc.DistinctBy(o => o.SnObjTckNr).Count(o => o.BcdEvtTypCd.Equals("05")),
                    WorkAreaName = $"{groupedScanLoc.Key} BELT",
                    TotalLoaded = groupedScanLoc.Count()
                };

                var originalLoadQuality = (loadAreaWorkDetail.TotalLoaded - loadAreaWorkDetail.TotalMisloads) * 100 / loadAreaWorkDetail.TotalLoaded;
                loadAreaWorkDetail.QualityNumberOriginal = $"{originalLoadQuality}%";
                loadAreaWorkDetail.QualityNumber = GetLoadQualityMargin(originalLoadQuality);
                loadAreaWorkDetail.Quality = $"{loadAreaWorkDetail.QualityNumber}%";
                result.Add(loadAreaWorkDetail);
            }

            return result.OrderByDescending(o => o.Quality).ToList();
        }

        public MisloadByWorkAreaMainViewModel GetMisoadQualityByWorkArea(DateTime date)
        {
            //date = new DateTime(2022, 03, 09);
            var groupedMisloads = _context.Set<Tscanloc>()
                .Where(o => o.RecUdtTs.Date == date.Date
                            && !string.IsNullOrEmpty(o.PriInstruction)
                            && o.BcdEvtTypCd.Equals("05"))
                .ToList()
                .GroupBy(o => o.PriInstruction);

            var result = new MisloadByWorkAreaMainViewModel
            {
                TotalMisloadsForAllWorkArea = groupedMisloads.Sum(o => o.Count())
            };
            foreach (var groupedScanLoc in groupedMisloads)
            {
                var loadAreaWorkDetail = new MisloadByWorkAreaViewModel
                {
                    Id = groupedScanLoc.Key,
                    TotalMisloads = groupedScanLoc.DistinctBy(o => o.SnObjTckNr).Count(o => o.BcdEvtTypCd.Equals("05")),
                    WorkAreaName = $"{groupedScanLoc.Key} BELT",
                };

                var originalLoadQuality = (result.TotalMisloadsForAllWorkArea - loadAreaWorkDetail.TotalMisloads) * 100 / result.TotalMisloadsForAllWorkArea;
                loadAreaWorkDetail.QualityNumberOriginal = $"{originalLoadQuality}%";
                loadAreaWorkDetail.QualityNumber = GetLoadQualityMargin(originalLoadQuality);
                loadAreaWorkDetail.Quality = $"{loadAreaWorkDetail.QualityNumber}%";
                result.MisloadByWorkAreaViewModels.Add(loadAreaWorkDetail);
            }

            result.MisloadByWorkAreaViewModels = result.MisloadByWorkAreaViewModels.OrderByDescending(o => o.Quality).ToList();
            return result;
        }

        public List<RouteInDistressViewModel> GetRouteInDistressData(DateTime date)
        {
            var result = GetRouteSpaScanData(date);

            result = result.OrderBy(o => o.ScannedPercentage).ToList();

            var rank = result.Count;
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Rank = rank;
                rank--;
            }

            return result;
        }

        public List<RouteInDistressViewModel> GetTopPerformersData(DateTime date)
        {
            var result = GetRouteSpaScanData(date);

            result = result.OrderByDescending(o => o.ScannedPercentage).ToList();

            var rank = 1;
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Rank = rank;
                rank++;
            }

            return result;
        }

        private List<RouteInDistressViewModel> GetRouteSpaScanData(DateTime date)
        {
            date = new DateTime(2022, 05, 10);
            var spaDetails = _context.Tspalocs
                .Where(o => o.RecUdtTs.Date == date.Date && !string.IsNullOrWhiteSpace(o.PlnPkgRteNr))
                .GroupBy(o => o.PlnPkgRteNr)
                .Select(o => new
                {
                    SpaRoute = o.Key,
                    TotalSpa = o.Count()
                });

            var scanDetails = _context.Tscanlocs
                .Where(o => o.RecUdtTs.Date == date.Date && !string.IsNullOrWhiteSpace(o.PlnPkgRteNr))
                .GroupBy(o => o.PlnPkgRteNr)
                .Select(o => new
                {
                    SpaRoute = o.Key,
                    TotalSpa = o.Count()
                });

            var result = new List<RouteInDistressViewModel>();

            foreach (var item in scanDetails)
            {
                var distressData = new RouteInDistressViewModel
                {
                    Position = item.SpaRoute,
                    TotalScanned = item.TotalSpa
                };

                var spaData = spaDetails.FirstOrDefault(o => o.SpaRoute.Equals(item.SpaRoute));
                if (spaData != null)
                    distressData.TotalSpa =
                        //spaData.SpaRoute == "34B" ? 33 : 
                        spaData.TotalSpa;
                else
                    distressData.TotalSpa = 1;

                distressData.ScannedPercentage = distressData.TotalScanned * 100 / distressData.TotalSpa;

                result.Add(distressData);
            }

            return result;
        }

        private static int GetLoadQualityMargin(int originalLoadQuality)
        {
            if (originalLoadQuality == 0) return -1;
            else if (originalLoadQuality >= 0 && originalLoadQuality <= 20) return (int)(originalLoadQuality * 0.6);
            else if (originalLoadQuality >= 21 && originalLoadQuality <= 40) return (int)(originalLoadQuality * 0.7);
            else if (originalLoadQuality >= 41 && originalLoadQuality <= 60) return (int)(originalLoadQuality * 0.72);
            else if (originalLoadQuality >= 61 && originalLoadQuality <= 80) return (int)(originalLoadQuality * 0.74);
            else if (originalLoadQuality >= 81 && originalLoadQuality <= 100) return (int)(originalLoadQuality * 0.74);
            else return originalLoadQuality;
        }

        private static string CalculateMargin(bool hasMisload, int MisloadNotificationReceivedTimeInterval)
        {
            if (!hasMisload) return "88%";

            return MisloadNotificationReceivedTimeInterval switch
            {
                < 2 => $"73%",
                < 5 => $"68%",
                < 8 => $"60%",
                < 12 => $"55%",
                < 20 => $"50%",
                < 40 => $"45%",
                < 60 => $"35%",
                < 70 => $"28%",
                < 80 => $"22%",
                < 90 => $"17%",
                < 100 => $"9%",
                < 110 => $"5%",
                _ => "0%"
            };
        }


        public List<TruckDetailViewModel> GetNewTruckDetails(string date)
        {
            List<PreliminaryTruckDetails> preliminaryTruckDetails = _dapper.GetUloDetail(date).ToList();
            var groupedScanLocs = preliminaryTruckDetails.GroupBy(o => o.EmpIdNr);
            var result = new List<TruckDetailViewModel>();

            foreach (var groupedScanLoc in groupedScanLocs)
            {
                var truckDetailViewModel = new TruckDetailViewModel
                {
                    Id = groupedScanLoc.Key,
                    //TotalMisloads = groupedScanLoc.DistinctBy(o => o.SnObjTckNr).Count(o => o.BcdEvtTypCd.Equals("05"))
                };

                foreach (var item in groupedScanLoc)
                {
                    var hasMisload = item.BcdEvtTypCd.Equals("05");
                    if (!hasMisload) continue;
                    //Check if it was resolved later
                    var getScannedEventType = preliminaryTruckDetails
                        .FirstOrDefault(o => o.SnObjTckNr.Equals(item.SnObjTckNr) && o.BcdEvtTypCd.Equals("24"));

                    if (getScannedEventType == null || item.RecUdtTs > getScannedEventType.RecUdtTs)
                        truckDetailViewModel.TotalMisloads++;
                }

                truckDetailViewModel.HasMisload = truckDetailViewModel.TotalMisloads > 0;
                // Change DateTime.Now to DateTime.UtcNow
                var possibleMisloadTimeInterval = (int)DateTime.UtcNow
                    .Subtract(groupedScanLoc.OrderByDescending(o => o.RecUdtTs)
                    .First().RecUdtTs)
                    .TotalMinutes;

                truckDetailViewModel.MisloadNotificationReceivedTimeInterval = truckDetailViewModel.HasMisload
                    ? possibleMisloadTimeInterval == 0 ? 1 : possibleMisloadTimeInterval
                    : 0;

                truckDetailViewModel.Margin = CalculateMargin(truckDetailViewModel.HasMisload, truckDetailViewModel.MisloadNotificationReceivedTimeInterval);

                var groupedUloList = groupedScanLoc.GroupBy(p => p.UloNr);
                var uloDetails = new List<UloDetailViewModel>();

                foreach (var item in groupedUloList)
                {
                    var latestEvent = item.OrderByDescending(p => p.RecUdtTs).First();
                    var detail = new UloDetailViewModel
                    {
                        // BeltBay = Random.Shared.Next(110, 119).ToString(),
                        BeltBay = latestEvent.BeltBay,
                        RouteId = latestEvent.PlnPkgRteNr,
                        PackageCar = item.Key,
                        HasMisload = latestEvent.BcdEvtTypCd.Equals("05")
                    };
                    uloDetails.Add(detail);
                }
                truckDetailViewModel.UloDetailViewModels.AddRange(uloDetails);
                result.Add(truckDetailViewModel);
            }

            return result;
        }

        public List<RouteInDistressViewModel> GetNewTopPerformersData(string date)
        {
            List<RouteInDistressViewModel> preliminaryPerformanceDetails = _dapper.GetNewTopPerformersData(date, 1).ToList();
            int rank = 1;
            foreach (var item in preliminaryPerformanceDetails)
            {
                item.Rank = rank;
                rank++;
            }

            return preliminaryPerformanceDetails;


        }

        public List<RouteInDistressViewModel> GetNewRouteInDistressData(string date)
        {
            List<RouteInDistressViewModel> preliminaryPerformanceDetails = _dapper.GetNewTopPerformersData(date, 2).OrderBy(x => x.ScannedPercentage).ToList();
            if (preliminaryPerformanceDetails == null || preliminaryPerformanceDetails.Count <= 0)
            {
                return new List<RouteInDistressViewModel>();
            }

            int lastRank = preliminaryPerformanceDetails.FirstOrDefault().TotalPosition;
            int rank = 1;
            foreach (var item in preliminaryPerformanceDetails)
            {
                item.Rank = rank;
                rank++;
            }
            return preliminaryPerformanceDetails;

        }
        public List<TruckDetailDashboardViewModel> GetTruckDetailsDashboardData(string date)
        {
            List<TruckDetailDashboardViewModel> truckDetailDashboardViewModels = new List<TruckDetailDashboardViewModel>();
            List<PreliminaryTruckDetailsForDashboard> preliminaryTruckDetailsForDashboard = new List<PreliminaryTruckDetailsForDashboard>();
            preliminaryTruckDetailsForDashboard = _dapper.GetDashboardDetail(date).ToList();
            if (preliminaryTruckDetailsForDashboard == null || preliminaryTruckDetailsForDashboard.Count <= 0)
            {
                return truckDetailDashboardViewModels;
            }
            foreach (var item in preliminaryTruckDetailsForDashboard)
            {
                var truckDetailDashboardData = new TruckDetailDashboardViewModel();
                truckDetailDashboardData.Id = item.UloNr;
                truckDetailDashboardData.TotalMisloadByEachRoute = item.TotalMisloadByEachRoute;
                truckDetailDashboardData.OldestMisload = item.OldestMisload;
                truckDetailDashboardData.TotalMisloads = item.OverAllTotalMisload;
                truckDetailDashboardViewModels.Add(truckDetailDashboardData);
            }
            return truckDetailDashboardViewModels;
        }
        public MisloadByWorkAreaMainViewModel GetNewMisoadQualityByWorkArea(string date)
        {
            List<PreliminaryMisloadByWorkAreaDetail> preliminaryMisloadByWorkAreaDetail = _dapper.GetNewMisoadQualityByWorkArea(date).ToList();
            var result = new MisloadByWorkAreaMainViewModel
            {
                TotalMisloadsForAllWorkArea = preliminaryMisloadByWorkAreaDetail.Count
            };
            List<string> priInstructions = preliminaryMisloadByWorkAreaDetail.DistinctBy(x => x.PriInstruction).Select(x => x.PriInstruction).ToList();

            foreach (var priInstruction in priInstructions)
            {
                var loadAreaWorkDetail = new MisloadByWorkAreaViewModel
                {
                    Id = priInstruction,
                    TotalMisloads = preliminaryMisloadByWorkAreaDetail.Where(x => x.PriInstruction == priInstruction).Count(),
                    WorkAreaName = $"{priInstruction} BELT",
                };

                var originalLoadQuality = (result.TotalMisloadsForAllWorkArea - loadAreaWorkDetail.TotalMisloads) * 100 / result.TotalMisloadsForAllWorkArea;
                loadAreaWorkDetail.QualityNumberOriginal = $"{originalLoadQuality}%";
                loadAreaWorkDetail.QualityNumber = GetLoadQualityMargin(originalLoadQuality);
                loadAreaWorkDetail.Quality = $"{loadAreaWorkDetail.QualityNumber}%";
                result.MisloadByWorkAreaViewModels.Add(loadAreaWorkDetail);
            }

            result.MisloadByWorkAreaViewModels = result.MisloadByWorkAreaViewModels.OrderByDescending(o => o.Quality).ToList();
            return result;

        }
    }

}
