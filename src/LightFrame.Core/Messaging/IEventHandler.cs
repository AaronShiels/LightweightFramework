using System.Threading.Tasks;

namespace LightFrame.Core.Messaging
{
    public interface IEventHandler<in T>
    {
        Task Handle(T command);
    }
}
