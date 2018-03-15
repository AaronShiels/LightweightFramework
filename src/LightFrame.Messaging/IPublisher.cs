using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IPublisher
    {
        Task PublishAsync(object message);
        void EnquePublish(object message);
    }
}
