using System;

namespace LightFrame.SampleApi.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}
