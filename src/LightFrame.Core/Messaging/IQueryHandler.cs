using System.Threading.Tasks;

namespace LightFrame.Core.Messaging
{
    public interface IQueryHandler<in T1, T2> where T1 : class where T2 : class
    {
        Task<T2> Handle(T1 query);
    }
}
