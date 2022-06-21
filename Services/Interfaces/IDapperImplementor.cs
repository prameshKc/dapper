using Jumbotron.ViewModels;

namespace Jumbotron.Services.Interfaces
{
    public interface IDapperImplementor
    {
        IEnumerable<PreliminaryTruckDetails> GetUloDetail(string date);
        IEnumerable<PreliminaryTruckDetailsForDashboard> GetDashboardDetail(string date);
        IEnumerable<RouteInDistressViewModel> GetNewTopPerformersData(string date, int orderBy);

        IEnumerable<PreliminaryMisloadByWorkAreaDetail> GetNewMisoadQualityByWorkArea(string date);


    }
}
