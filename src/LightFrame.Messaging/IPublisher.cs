using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IPublisher
    {
        Task Publish(object message);
        void Enqueue(object message);
    }
}
