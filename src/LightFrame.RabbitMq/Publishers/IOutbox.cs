using System;
using System.Threading.Tasks;

namespace LightFrame.RabbitMq.Publishers
{
    internal interface IOutbox
    {
        void Enqueue(Func<Task> action);
        Func<Task> Dequeue();
        int Count { get; }
    }
}
