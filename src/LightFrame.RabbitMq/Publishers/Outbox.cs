using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightFrame.RabbitMq.Publishers
{
    internal class Outbox : Queue<Func<Task>>, IOutbox
    {
    }
}
