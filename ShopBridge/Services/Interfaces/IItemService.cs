using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Services.Interfaces
{
    public interface IItemService
    {
        Task<bool> AddItem(Item item);
        Task<bool> DeleteItem(Guid itemId);
        Task<bool> UpdateItem(Guid itemId, Item item);
        Task<List<Item>> GetItems();
    }
}
