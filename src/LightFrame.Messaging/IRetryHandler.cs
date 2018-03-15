using System;

namespace LightFrame.Messaging
{
    public interface IRetryHandler
    {
        bool ShouldRetry(Exception ex, int retries);
    }
}
