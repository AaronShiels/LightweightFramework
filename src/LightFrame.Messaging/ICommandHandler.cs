namespace LightFrame.Messaging
{
    public interface ICommandHandler<in T> : IHandler<T> where T : class
    {
    }
}
