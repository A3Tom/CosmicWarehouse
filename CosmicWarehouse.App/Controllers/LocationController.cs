using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger,
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations(int? warehouseId = null)
        {
            var loggerMessage = "Getting locations";

            loggerMessage += warehouseId.HasValue ? 
                $" for warehouse: {warehouseId}" : 
                string.Empty;

            _logger.LogInformation(loggerMessage);

            var result = await _locationService.GetLocations(warehouseId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto newLocation)
        {
            _logger.LogInformation($"Adding new location, {newLocation.Name}");

            var result = await _locationService.AddLocation(newLocation);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RenameLocation([FromBody] LocationDto location)
        {
            _logger.LogInformation($"Renaming location: {location.Id}");

            var result = await _locationService.RenameLocation(location);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleActive(int locationId, bool active)
        {
            _logger.LogInformation($"Toggling location {locationId} to {active}");

            var result = await _locationService.ToggleActive(locationId, active);

            return Ok(result);
        }
    }

}
