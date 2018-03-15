using LightFrame.SampleCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightFrame.SampleCore.Domain.Context
{
    public interface IInventoryContext
    {
        DbSet<Item> Items { get; }
    }
}
