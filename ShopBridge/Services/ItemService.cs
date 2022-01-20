using Microsoft.Extensions.Logging;
using ShopBridge.Models;
using ShopBridge.Repositories.Interfaces;
using ShopBridge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Services
{
    public class ItemService : IItemService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly IItemRepository _itemRepo;

        public ItemService(
            ILogger<ItemService> logger,
            IItemRepository itemRepo)
        {
            _logger = logger;
            _itemRepo = itemRepo;
        }

        public async Task<bool> AddItem(Item item)
        {
            try
            {
                bool isAdded = await _itemRepo.AddItem(item);
                return isAdded;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured ItemService.AddItem. Error : {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteItem(Guid itemId)
        {
            try
            {
                bool isDeleted = await _itemRepo.DeleteItem(itemId);
                return isDeleted;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemService.DeleteItem. Error : {ex.Message}");
                throw;
            }
        }

        public async Task<List<Item>> GetItems()
        {
            try
            {
                var items = await _itemRepo.GetItems();
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemService.GetItems. Error : {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateItem(Guid itemId, Item item)
        {
            try
            {
                var oldItem = await _itemRepo.GetById(itemId);

                // Add Custom class to do mapping

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Price = item.Price;
                oldItem.IsNew = item.IsNew;


                bool isUpdated = await _itemRepo.UpdateItem(item);
                return isUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemService.UpdateItem. Error : {ex.Message}");
                throw;
            }
        }
    }
}
