using LightFrame.SampleCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightFrame.SampleCore.Domain.Context
{
    public class InventoryContext : DbContext, IInventoryContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}