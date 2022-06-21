using Jumbotron.Services.Interfaces;
using Jumbotron.ViewModels;

namespace Jumbotron.Services
{
    public class DapperImplementor : IDapperImplementor
    {
        private readonly IDapperRepository _dapperRepository;
        public DapperImplementor(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public IEnumerable<RouteInDistressViewModel> GetNewTopPerformersData(string date, int orderBy = 1)
        {
            string sql = "USP_GetTopPerformersData @date=@date,@orderBy=@orderBy";
            var result = _dapperRepository.ExecuteQuery<RouteInDistressViewModel>(sql, new { date, orderBy });
            return result;
        }

        public IEnumerable<PreliminaryTruckDetails> GetUloDetail(string date)
        {
            string sql = "USP_GetTruckDetails @date=@date";
            var result = _dapperRepository.ExecuteQuery<PreliminaryTruckDetails>(sql, new { date });
            return result;
        }
        public IEnumerable<PreliminaryMisloadByWorkAreaDetail> GetNewMisoadQualityByWorkArea(string date)
        {
            string sql = "USP_GetMisloadByWorkArea @date=@date";
            var result = _dapperRepository.ExecuteQuery<PreliminaryMisloadByWorkAreaDetail>(sql, new { date });
            return result;
        }
        public IEnumerable<PreliminaryTruckDetailsForDashboard> GetDashboardDetail(string date)
        {
            string sql = "USP_GetTruckDetailsForDashboard @date=@date";
            var result = _dapperRepository.ExecuteQuery<PreliminaryTruckDetailsForDashboard>(sql, new { date });
            return result;
        }

    }
}
