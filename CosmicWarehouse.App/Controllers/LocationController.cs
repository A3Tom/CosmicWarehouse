using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetLocations(int? warehouseId = null)
        {
            var loggerMessage = "Getting locations";

            loggerMessage += warehouseId.HasValue ? 
                $" for warehouse: {warehouseId}" : 
                string.Empty;

            _logger.LogInformation(loggerMessage);

            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] object newLocation)
        {
            _logger.LogInformation("Adding new location");

            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Update([FromBody] object location)
        {
            _logger.LogInformation($"Updating location: ");

            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult ToggleActive(int locationId, bool active)
        {
            _logger.LogInformation($"Toggling location {locationId} to {active}");

            throw new NotImplementedException();
        }
    }

}
