using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightFrame.SampleApi.Models;
using LightFrame.SampleCore.Domain.Context;
using LightFrame.SampleCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightFrame.SampleApi.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IInventoryContext _db;

        public ItemsController(IInventoryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemModel>> Get()
        {
            var items = await _db.Items
                .ToListAsync();

            return items
                .Select(i => new ItemModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Cost = i.Cost,
                    Quantity = i.Quantity
                });
        }
        
        [HttpGet("{id}")]
        public async Task<ItemModel> Get(Guid id)
        {
            var item = await _db.Items
                .Where(i => i.Id == id)
                .SingleAsync();

            return new ItemModel
            {
                Id = item.Id,
                Name = item.Name,
                Cost = item.Cost,
                Quantity = item.Quantity
            };
        }
        
        [HttpPost]
        public async Task Post([FromBody]AddItemModel model)
        {
            var item = new Item(model.Name, model.Cost, model.Quantity);

            await _db.Items.AddAsync(item);
        }
    }
}
