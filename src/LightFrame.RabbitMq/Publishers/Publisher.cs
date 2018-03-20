using System.Threading.Tasks;
using LightFrame.Messaging;
using MassTransit;

namespace LightFrame.RabbitMq.Publishers
{
    internal class Publisher : IPublisher
    {
        private readonly IBus _bus;
        private readonly IOutbox _outbox;

        public Publisher(IBus bus, IOutbox outbox)
        {
            _bus = bus;
            _outbox = outbox;
        }

        public void Enqueue(object message)
        {
            _outbox.Enqueue(() => Publish(message));
        }

        public Task Publish(object message)
        {
            return _bus.Publish(message);
        }
    }
}
