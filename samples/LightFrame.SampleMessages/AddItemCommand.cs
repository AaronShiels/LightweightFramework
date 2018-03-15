using System;

namespace LightFrame.SampleMessages
{
    public class AddItemCommand
    {
        public AddItemCommand(string name, decimal cost, int quantity)
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}
