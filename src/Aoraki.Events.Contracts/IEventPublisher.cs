namespace Aoraki.Events.Contracts;

public interface IEventPublisher
{
    IBlogEventPublisher Blog { get; }
}