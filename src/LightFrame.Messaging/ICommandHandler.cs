using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IEventHandle<in T>
    {
        Task Handle(T command);
    }
}
