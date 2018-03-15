using System;
using System.Threading.Tasks;
using LightFrame.Messaging;
using LightFrame.SampleMessages;

namespace LightFrame.SampleCore.Handlers
{
    public class AddItemHandler : ICommandHandler<AddItemCommand>
    {
        public async Task Handle(AddItemCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
