using FleetManagement.Models;
using FleetManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TrackingController : ControllerBase
{
    private static Random _random = new Random();

    //[Authorize(Roles = "Manager")]
    //[HttpGet("gps")]
    //public IActionResult GetGps()
    //{
    //    //double baseLat = 30.7333;
    //    //double baseLng = 76.7794;

    //    var gpsData = new
    //    {
    //        TruckId = "TRK123",
    //        Latitude = 30.7333,   
    //        Longitude = 76.7794,
    //        Speed = _random.Next(40, 80),
    //        Timestamp = DateTime.UtcNow
    //    };

    //    return Ok(gpsData);
    //}
    [HttpPost("update")]
    public IActionResult UpdateLocation([FromBody] GpsModel model)
    {
        return Ok();
    }
    [Authorize(Roles = "Manager")]
    [HttpGet("gps")]
    public IActionResult GetGps()
    {
        var latest = GpsBackgroundService.GpsDataStore.LastOrDefault();

        return Ok(latest);
    }
   
    [Authorize(Roles = "Manager")]
    [HttpGet("history")]
    public IActionResult GetHistory()
    {
        return Ok(GpsBackgroundService.GpsDataStore);
    }
}