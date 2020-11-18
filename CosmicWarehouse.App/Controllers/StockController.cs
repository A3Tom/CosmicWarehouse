using System.Collections.Generic;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly IStockService _stockService;

        public StockController(ILogger<StockController> logger,
            IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        [HttpGet]
        public IEnumerable<StockVM> GetAllInventory()
        {
            _logger.LogInformation("Getting all Stock items in inventory");

            return new List<StockVM>();
        }

        [HttpGet]
        public IEnumerable<StockVM> GetInventoryForWarehouse(int warehouseId)
        {
            _logger.LogInformation($"Getting all in Stock items in warehouse : {warehouseId}");

            return new List<StockVM>();
        }

        [HttpGet]
        public IEnumerable<StockVM> GetInventoryForLocation(int locationId)
        {
            _logger.LogInformation($"Getting all in Stock items in location : {locationId}");

            return new List<StockVM>();
        }

        [HttpGet]
        public IEnumerable<StockVM> GetInventoryForItem(int itemId)
        {
            _logger.LogInformation($"Getting all stock for item : {itemId}");

            return new List<StockVM>();
        }

        [HttpPost]
        public IActionResult AddStock([FromBody] IEnumerable<StockDto> newStock)
        {
            _stockService.AddStock(newStock);

            return Ok();
        }
    }
}
