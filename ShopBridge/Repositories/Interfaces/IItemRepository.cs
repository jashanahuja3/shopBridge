using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repositories.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<bool> AddItem(Item item);
        Task<bool> DeleteItem(Guid itemId);
        Task<bool> UpdateItem(Item item);
        Task<List<Item>> GetItems();
    }
}
