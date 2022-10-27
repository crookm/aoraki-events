using System.Threading.Tasks;
using Aoraki.Events.Contracts.Blog;

namespace Aoraki.Events.Contracts;

public interface IBlogEventPublisher
{
    Task SendCommentCreatedEventAsync(string subject, CommentCreatedEvent data);
    Task SendReactionCreatedEventAsync(string subject, ReactionCreatedEvent data);
    Task SendReactionRemovedEventAsync(string subject, ReactionRemovedEvent data);
}