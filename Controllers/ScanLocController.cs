using Jumbotron.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jumbotron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanLocController : ControllerBase
    {
        private readonly IScanLoc _scanLoc;
        private readonly IDapperImplementor _dapper;

        public ScanLocController(IScanLoc scanLoc,IDapperImplementor dapper)
        {
            _scanLoc = scanLoc;
            _dapper = dapper;
        }

        [HttpGet, Route("GetTruckDetails/{date}")]
        public IActionResult GetTruckDetails(DateTime date)
        {
          return Ok(_scanLoc.GetNewTruckDetails(date.ToString("yyyy-MM-dd")));

          // return Ok(_scanLoc.GetTruckDetails(date));
        }
        

        [HttpGet, Route("GetLoadQualityByWorkAreaDetails/{date}")]
        public IActionResult GetLoadQualityByWorkAreaDetails(DateTime date)
        {
            return Ok(_scanLoc.GetLoadQualityByWorkArea(date));
        }

        [HttpGet, Route("GetMisoadQualityByWorkArea/{date}")]
        public IActionResult GetMisoadQualityByWorkArea(DateTime date)
        {
            // return Ok(_scanLoc.GetMisoadQualityByWorkArea(date));
            return Ok(_scanLoc.GetNewMisoadQualityByWorkArea(date.ToString("yyyy-MM-dd")));
        }

        [HttpGet, Route("GetRouteInDistressData/{date}")]
        public IActionResult GetRouteInDistressData(DateTime date)
        {
            return Ok(_scanLoc.GetNewRouteInDistressData(date.ToString("yyyy-MM-dd")));

          //  return Ok(_scanLoc.GetRouteInDistressData(date));
        }
       
        [HttpGet, Route("GetTopPerformersData/{date}")]
        public IActionResult GetTopPerformersData(DateTime date)
        {
            return Ok(_scanLoc.GetNewTopPerformersData(date.ToString("yyyy-MM-dd")));

          //  return Ok(_scanLoc.GetTopPerformersData(date));
        }

        [HttpGet, Route("GetDashboardData/{date}")]
        public IActionResult GetTruckDetailsDashboardData(DateTime date)
        {
            return Ok(_scanLoc.GetTruckDetailsDashboardData(date.ToString("yyyy-MM-dd")));
        }
    }
}
