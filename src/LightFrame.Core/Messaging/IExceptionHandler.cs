using System;
using System.Threading.Tasks;

namespace LightFrame.Core.Messaging
{
    public interface IExceptionHandler
    {
        Task HandleException(Exception ex);
    }
}
