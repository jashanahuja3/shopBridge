using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopBridge.Context
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Item> Items { get; set; }
    }
}
