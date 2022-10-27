using System.Net;
using System.Text.Json.Serialization;

namespace Aoraki.Events.Contracts.Blog;

public class CommentCreatedEvent : BlogEvent
{
    [JsonIgnore] public const string EventType = "Aoraki.Blog.Comment.Created";
    [JsonIgnore] public const string EventVersionLatest = "1.0";

    public string? AuthorName { get; set; }
    public string? Content { get; set; }
    public IPAddress? IpAddress { get; set; }
}