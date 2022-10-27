using System.Net;
using System.Text.Json.Serialization;

namespace Aoraki.Events.Contracts.Blog;

public class ReactionRemovedEvent : BlogEvent
{
    [JsonIgnore] public const string EventType = "Aoraki.Blog.Reaction.Removed";
    [JsonIgnore] public const string EventVersionLatest = "1.0";

    public int? ReactionTypeId { get; set; }
    public string? ReactionTypeName { get; set; }
    public IPAddress? IpAddress { get; set; }
}