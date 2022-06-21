using Jumbotron.ViewModels;

namespace Jumbotron.Services.Interfaces
{
    public interface IScanLoc
    {
        List<TruckDetailViewModel> GetTruckDetails(DateTime date);
        List<TruckDetailViewModel> GetNewTruckDetails(string date);
        List<LoadQualityByWorkAreaViewModel> GetLoadQualityByWorkArea(DateTime date);
        MisloadByWorkAreaMainViewModel GetMisoadQualityByWorkArea(DateTime date);
        List<RouteInDistressViewModel> GetRouteInDistressData(DateTime date);
        List<RouteInDistressViewModel> GetTopPerformersData(DateTime date);
        List<RouteInDistressViewModel> GetNewTopPerformersData(string date);
        List<RouteInDistressViewModel> GetNewRouteInDistressData(string date);
        MisloadByWorkAreaMainViewModel GetNewMisoadQualityByWorkArea(string date);
        List<TruckDetailDashboardViewModel> GetTruckDetailsDashboardData(string date);

    }

}
