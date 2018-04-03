# LightweightFramework

## Handlers
A very basic implementation of the mediator pattern, encapsulating business logic in handlers removes cross-cutting concerns HTTP or bus-specific code) which allows us to achieve two very important goals:
1. Logic encapsulated in the handler can be used in either implementation without issue, as it is implementation agnostic.
2. Unit testing is easier and can be restricted in scope to just business logic.

## Sample Handler
```
public class ExampleEventHandler : IEventHandler<SomethingHappenedEvent>
{
    private readonly IDbContext _db;
    private readonly IPublisher _bus;

    public ExampleEventHandler(IDbContext db, IPublisher bus)
    {
        _db = db;
        _bus = bus;
    }

    public async Task Handle(SomethingHappenedEvent ev)
    {
        var entity = Map(ev);
        _db.Insert(entity);
        
        var subsequentEvent = Map(entity);
        _bus.EnqueuePublish(subsequentEvent);
    }
    
    ...
}
```

## Usage as a Consumer
Register it in the container, and it will automatically:
* Subscribe to the topic that correlates to the message contract SomethingHappenedEvent.
* Created whenever a SomethingHappenedEvent is consumed.

The middleware available will handle:
* Debug diagnostics at the beginning and end of the action.
* Error handling if an unhandled exception is thrown (<QueueName>_error).
* Set message headers (correlation/conversation IDs).
* Publish enqueued messages explicitly after the database commit phase.

## Usage in a WebApi Controller
```
[Route("api/[controller]")]
public class ExampleController : Controller
{
    private readonly ExampleCommandHandler _exampleCommandHandler;

    public ExampleHandler(ExampleCommandHandler exampleCommandHandler)
    {
        _exampleCommandHandler = exampleCommandHandler;
    }

    [HttpPost]
    public async Task Post([FromBody]DoSomethingCommand command) => await _exampleCommandHandler.Handle(command);
}
```

AspNetCore will handle:
* Routing and controller creation based on the path convention.
* Debug diagnostics (AspNetCore default).
* Error handling if an unhandled exception is thrown (AspNetCore default).

The middleware available will handle:
* Publish enqueued messages explicitly after the database commit phase.
