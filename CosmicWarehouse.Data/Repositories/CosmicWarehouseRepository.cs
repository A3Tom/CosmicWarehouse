using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Contexts;
using CosmicWarehouse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmicWarehouse.Data.Repositories
{
    public class CosmicWarehouseRepository : ICosmicWarehouseRepository
    {
        private readonly CosmicWarehouseDbContext _dbContext;

        public CosmicWarehouseRepository(CosmicWarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Items

        public async Task<IEnumerable<Item>> AddStock(IEnumerable<Item> itemStock)
        {
            var stockTransactions = new List<StockTransaction>();

            _dbContext.Items.AddRange(itemStock);

            await _dbContext.SaveChangesAsync();

            foreach (var item in itemStock)
            {
                stockTransactions.Add(BuildStockTransaction(item.Id, 0, item.Quantity));
            }

            _dbContext.StockTransactions.AddRange(stockTransactions);

            await _dbContext.SaveChangesAsync();

            return await GetStockForItems(itemStock.Select(x => x.Id));
        }

        public async Task<Item> GetStockForItem(int itemId)
        {
            return await _dbContext.Items
                .Include(x => x.Location.Warehouse)
                .AsNoTracking()
                .Where(x => x.Id == itemId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetStockForItems(IEnumerable<int> itemIds)
        {
            return await _dbContext.Items
                .Include(x => x.Location.Warehouse)
                .AsNoTracking()
                .Where(x => itemIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetStockInLocation(int locationId)
        {
            return await _dbContext.Locations
                .Where(x => x.Id == locationId)
                .SelectMany(l => l.Items)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetStockInWarehouse(int warehouseId)
        {
            return await _dbContext.Items
                .Include(x => x.Location.Warehouse)
                .Where(x => x.Location.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<Item> UpdateQuantity(int itemId, int quantityDiff)
        {
            var item = await _dbContext.Items
                .Include(x => x.Location.Warehouse)
                .Where(x => x.Id == itemId)
                .SingleOrDefaultAsync();

            var previousQuantity = item.Quantity;
            var newQuantity = item.Quantity + quantityDiff;

            item.Quantity = newQuantity;

            var stockTransaction = BuildStockTransaction(item.Id, previousQuantity, newQuantity);

            _dbContext.StockTransactions.Add(stockTransaction);

            await _dbContext.SaveChangesAsync();

            return item;
        }

        #endregion

        #region Locations

        public async Task<Location> AddLocation(Location newEntity)
        {
            _dbContext.Locations.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return newEntity;
        }

        public async Task<Location> GetLocation(int locationId)
        {
            return await _dbContext.Locations
                .Include(x => x.Warehouse)
                .Where(x => x.Id == locationId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Location>> GetLocationsForWarehouse(int? warehouseId)
        {
            return await _dbContext.Locations
                .Include(x => x.Warehouse)
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        //TODO : Revise this abomination
        public async Task<Location> UpdateLocation(Location entity)
        {
            await _dbContext.SaveChangesAsync();

            return await GetLocation(entity.Id);
        }

        #endregion


        #region Warehouse

        public async Task<Warehouse> AddWarehouse(Warehouse newEntity)
        {
            _dbContext.Warehouses.Add(newEntity);

            await _dbContext.SaveChangesAsync();

            return newEntity;
        }

        public async Task<Warehouse> GetWarehouseById(int warehouseId)
        {
            return await _dbContext.Warehouses
                .Where(x => x.Id == warehouseId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehouses()
        {
            return await _dbContext.Warehouses.ToListAsync();
        }

        //TODO : Revise this abomination
        public async Task<Warehouse> UpdateWarehouse(Warehouse entity)
        {
            await _dbContext.SaveChangesAsync();

            return await GetWarehouseById(entity.Id);
        }

        #endregion

        private StockTransaction BuildStockTransaction(int itemId, int previousQuantity, int newQuantity)
        {
            return new StockTransaction()
            {
                ItemId = itemId,
                PreviousQuantity = previousQuantity,
                NewQuantity = newQuantity,
                TransactionDateTime = DateTime.Now
            };
        }
    }
}
