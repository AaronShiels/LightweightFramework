using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IEventHandler<in T>
    {
        Task Handle(T command);
    }
}
