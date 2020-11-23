using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;
using CosmicWarehouse.Data.Repositories;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.Service.Classes
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ILogger<WarehouseService> _logger;

        private readonly ICosmicWarehouseRepository _cosmicWarehouseRepo;

        public WarehouseService(ILogger<WarehouseService> logger,
            ICosmicWarehouseRepository cosmicWarehouseRepository)
        {
            _logger = logger;
            _cosmicWarehouseRepo = cosmicWarehouseRepository;
        }

        public async Task<WarehouseVM> AddWarehouse(WarehouseDto newWarehouse)
        {
            var newEntity = new Warehouse()
            {
                Name = newWarehouse.Name,
                Description = newWarehouse.Description,
                Active = true
            };

            var result = await _cosmicWarehouseRepo.AddWarehouse(newEntity);

            return GetWarehouseAsViewModel(result);
        }

        public async Task<IEnumerable<WarehouseVM>> GetAllWarehouses()
        {
            var result = await _cosmicWarehouseRepo.GetAllWarehouses();

            return GetWarehouseListAsViewModel(result);
        }

        public async Task<WarehouseVM> GetWarehouse(int warehouseId)
        {
            var result = await GetWarehouseEntity(warehouseId);

            return GetWarehouseAsViewModel(result);
        }

        public async Task<WarehouseVM> RenameWarehouse(WarehouseDto warehouse)
        {
            var entity = await GetWarehouseEntity(warehouse.Id);

            entity.Name = warehouse.Name;
            entity.Description = warehouse.Description;

            var result = await _cosmicWarehouseRepo.UpdateWarehouse(entity);

            return GetWarehouseAsViewModel(result);
        }

        public async Task<WarehouseVM> ToggleActive(int warehouseId, bool active)
        {
            var entity = await GetWarehouseEntity(warehouseId);

            entity.Active = active;

            var result = await _cosmicWarehouseRepo.UpdateWarehouse(entity);

            return GetWarehouseAsViewModel(result);
        }

        private async Task<Warehouse> GetWarehouseEntity(int? warehouseId)
        {
            if (!warehouseId.HasValue)
                throw new InvalidOperationException($"No warehouse Id supplied.");

            var entity = await _cosmicWarehouseRepo.GetWarehouseById(warehouseId.Value);

            if (entity == null)
                throw new KeyNotFoundException($"No warehouse was found with the Id of {warehouseId}");

            return entity;
        }


        private static IEnumerable<WarehouseVM> GetWarehouseListAsViewModel(IEnumerable<Warehouse> warehouses)
        {
            return warehouses.Select(x => GetWarehouseAsViewModel(x));
        }

        private static WarehouseVM GetWarehouseAsViewModel(Warehouse warehouse)
        {
            return warehouse;
        }
    }
}
