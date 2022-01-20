using ShopBridge.Context;
using ShopBridge.Models;
using ShopBridge.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(IApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync(System.Threading.CancellationToken.None);

            return true;

        }

        public async Task<bool> DeleteItem(Guid itemId)
        {
            var item = _context.Items.Where(i => i.Id == itemId).FirstOrDefault();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync(System.Threading.CancellationToken.None);

            return true;
        }

        public async Task<List<Item>> GetItems()
        {
            var items = _context.Items.ToList();
            return items;
        }

        public async Task<bool> UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync(System.Threading.CancellationToken.None);

            return true;
        }
    }
}
