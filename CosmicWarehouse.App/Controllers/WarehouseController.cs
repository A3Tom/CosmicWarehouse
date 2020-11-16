using System.Collections.Generic;
using CosmicWarehouse.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(ILogger<WarehouseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WarehouseDto> Get()
        {
            _logger.LogInformation("Getting All Warehouses");

            return new List<WarehouseDto>();
        }
    }
}
