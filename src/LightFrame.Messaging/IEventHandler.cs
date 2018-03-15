namespace LightFrame.Messaging
{
    public interface IEventHandler<in T> : IHandler<T> where T : class
    {
    }
}
