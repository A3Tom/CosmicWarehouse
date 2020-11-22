using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
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
        public async Task<IActionResult> AddLocationAsync([FromBody] LocationDto newLocation)
        {
            _logger.LogInformation($"Adding new location, {newLocation.Name}");

            var result = await _locationService.AddLocation(newLocation);

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Update([FromBody] LocationDto location)
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
