using System;
using System.Threading.Tasks;

namespace LightFrame.Core
{
    public interface IHook
    {
        Task Before(object message);
        Task After(object message, Exception exception);
        int Order { get; }
    }
}
