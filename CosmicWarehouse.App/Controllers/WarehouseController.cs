using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(ILogger<WarehouseController> logger,
            IWarehouseService warehouseService)
        {
            _logger = logger;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehouse(int warehouseId)
        {
            _logger.LogInformation($"Getting warehouse Id : {warehouseId}");

            var result = await _warehouseService.GetWarehouse(warehouseId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouses(bool includeInactive = false)
        {
            _logger.LogInformation($"Getting all warehouses");

            var result = await _warehouseService.GetAllWarehouses(includeInactive);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody] WarehouseDto newWarehouse)
        {
            _logger.LogInformation($"Adding new location, {newWarehouse.Name}");

            var result = await _warehouseService.AddWarehouse(newWarehouse);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] WarehouseDto warehouse)
        {
            _logger.LogInformation($"Renaming warehouse: {warehouse.Id} to {warehouse.Name}");

            var result = await _warehouseService.RenameWarehouse(warehouse);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleActive(int warehouseId, bool active)
        {
            _logger.LogInformation($"Toggling warehouse {warehouseId} to {active}");

            var result = await _warehouseService.ToggleActive(warehouseId, active);

            return Ok(result);
        }
    }
}
