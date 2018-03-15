using System;

namespace LightFrame.SampleCore.Domain.Entities
{
    public class Item
    {
        protected Item()
        { }

        public Item(string name, decimal cost, int quantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}
