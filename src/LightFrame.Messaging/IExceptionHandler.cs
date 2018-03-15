using System;
using System.Threading.Tasks;

namespace LightFrame.Messaging
{
    public interface IExceptionHandler
    {
        Task HandleException(Exception ex);
    }
}
