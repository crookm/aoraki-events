using Aoraki.Events.Contracts;

namespace Aoraki.Events.Publisher;

public class EventPublisher : IEventPublisher
{
    public EventPublisher(IBlogEventPublisher blogEventPublisher)
    {
        Blog = blogEventPublisher;
    }

    public IBlogEventPublisher Blog { get; }
}