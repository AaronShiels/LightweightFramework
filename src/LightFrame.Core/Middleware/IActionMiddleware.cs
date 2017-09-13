using System.Threading.Tasks;

namespace LightFrame.Core.Middleware
{
    public delegate Task ActionDelegate(ActionMetadata message);

    public interface IActionMiddleware
    {
        Task Invoke(ActionMetadata message, ActionDelegate next);
        int Priority { get; }
    }
}
