using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IHandler
    {
    }

    public interface IHandler<in T> : IHandler where T : class
    {
        Task Handle(T message);
    }
}
