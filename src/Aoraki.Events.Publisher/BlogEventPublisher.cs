using System;
using System.Threading.Tasks;
using Aoraki.Events.Contracts;
using Aoraki.Events.Contracts.Blog;
using Azure.Messaging.EventGrid;

namespace Aoraki.Events.Publisher;

public class BlogEventPublisher : IBlogEventPublisher
{
    private const string BlogEventTopic = "blog";

    private readonly EventGridPublisherClient _client;

    public BlogEventPublisher(EventGridPublisherClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    private async Task SendEvent<TEvent>(string subject, string eventType, string dataVersion, TEvent data) =>
        await _client.SendEventAsync(new EventGridEvent(subject, eventType, dataVersion, data)
            { Topic = BlogEventTopic });

    public async Task SendCommentCreatedEventAsync(string subject, CommentCreatedEvent data) =>
        await SendEvent(subject, CommentCreatedEvent.EventType, CommentCreatedEvent.EventVersionLatest, data);

    public async Task SendReactionCreatedEventAsync(string subject, ReactionCreatedEvent data) =>
        await SendEvent(subject, ReactionCreatedEvent.EventType, ReactionCreatedEvent.EventVersionLatest, data);

    public async Task SendReactionRemovedEventAsync(string subject, ReactionRemovedEvent data) =>
        await SendEvent(subject, ReactionRemovedEvent.EventType, ReactionRemovedEvent.EventVersionLatest, data);
}