using System;

namespace LightFrame.Core.Messaging
{
    public interface IRetryHandler
    {
        bool ShouldRetry(Exception ex, int retries);
    }
}
