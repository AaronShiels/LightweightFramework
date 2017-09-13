using System.Threading.Tasks;

namespace LightFrame.Core.Messaging
{
    public interface IEventHandle<in T>
    {
        Task Handle(T command);
    }
}
