namespace Jumbotron.ViewModels
{
    public class TruckDetailViewModel
    {
        public string Id { get; set; } = string.Empty;
        public int Pph { get; set; }
        public bool HasMisload { get; set; }
        public int TotalMisloads { get; set; }
        public int MisloadNotificationReceivedTimeInterval { get; set; } = 0;
        public string Margin { get; set; } = string.Empty;

        public List<UloDetailViewModel> UloDetailViewModels { get; set; } = new List<UloDetailViewModel>();
    }

    public class UloDetailViewModel
    {
        public string BeltBay { get; set; } = string.Empty;
        public string RouteId { get; set; } = string.Empty;
        public string PackageCar { get; set; } = string.Empty;
        public bool HasMisload { get; set; }
    }

    public class LoadQualityByWorkAreaViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Quality { get; set; } = string.Empty;
        public int QualityNumber { get; set; }
        public string QualityNumberOriginal { get; set; } = string.Empty;
        public string WorkAreaName { get; set; } = string.Empty;
        public int TotalMisloads { get; set; }
        public int TotalLoaded { get; set; }
    }

    public class MisloadByWorkAreaViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Quality { get; set; } = string.Empty;
        public int QualityNumber { get; set; }
        public string QualityNumberOriginal { get; set; } = string.Empty;
        public string WorkAreaName { get; set; } = string.Empty;
        public int TotalMisloads { get; set; }
        public int TotalLoaded { get; set; }
    }

    public class MisloadByWorkAreaMainViewModel
    {
        public MisloadByWorkAreaMainViewModel()
        {
            MisloadByWorkAreaViewModels = new List<MisloadByWorkAreaViewModel>();
        }

        public int TotalMisloadsForAllWorkArea { get; set; }
        public List<MisloadByWorkAreaViewModel> MisloadByWorkAreaViewModels { get; set; }
    }

    public class RouteInDistressViewModel
    {
        public int Rank { get; set; }
        public string Position { get; set; } = string.Empty;
        public int TotalSpa { get; set; }
        public int TotalScanned { get; set; }
        public int ScannedPercentage { get; set; }
        public int TotalPosition { get; set; }

    }
    public class PreliminaryTruckDetails
    {
        public string EmpIdNr { get; set; }
        public string BcdEvtTypCd { get; set; }
        public DateTime RecUdtTs { get; set; }
        public string UloNr { get; set; }
        public string BeltBay { get; set; }
        public string PlnPkgRteNr { get; set; }
        public string SnObjTckNr { get; set; }

    }
    public class PreliminaryMisloadByWorkAreaDetail    {        public string PriInstruction { get; set; }        public string SnObjTckNr { get; set; }        public string BcdEvtTypCd { get; set; }        public DateTime RecUdtTs { get; set; }    }

    public class PreliminaryTruckDetailsForDashboard
    {
        public string UloNr { get; set; }
        public int TotalMisloadByEachRoute { get; set; }
        public string OldestMisload { get; set; }
        public int OverAllTotalMisload { get; set; }

    }
    public class TruckDetailDashboardViewModel
    {
        public string Id { get; set; } = string.Empty;
        public int TotalMisloadByEachRoute { get; set; }
        public string OldestMisload { get; set; }
        public int TotalMisloads { get; set; }
        

    }

}
