using System.Threading.Tasks;

namespace LightFrame.Core.Messaging
{
    public interface IPublisher
    {
        Task PublishAsync(object message);
        void EnquePublish(object message);
    }
}
