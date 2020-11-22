using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> GetItemStock(int itemId)
        {
            _logger.LogInformation($"Getting stock for item: {itemId}");

            var result = await _stockService.GetItemStock(itemId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] IEnumerable<StockDto> newStock)
        {
            _logger.LogInformation($"Adding new stock entries for {newStock.Count()}");

            var result = await _stockService.AddStock(newStock);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantityAsync(int itemId, int quantityDiff)
        {
            _logger.LogInformation($"Updating stock Id {itemId} by {quantityDiff}");

            var result = await _stockService.UpdateQuantity(itemId, quantityDiff);

            return Ok(result);
        }
    }
}
