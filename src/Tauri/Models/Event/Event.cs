using System.Text.Json.Serialization;
using Tauri.Json.Converters;

namespace Tauri.Models.Event;

public sealed class Event<T>
{
    [JsonConverter(typeof(EventNameConverter))]
    [JsonPropertyName("event")]
    public required EventName Name { get; init; }
    
    [JsonPropertyName("windowLabel")]
    public required string WindowLabel { get; init; }
    
    [JsonPropertyName("id")]
    public required int Id { get; init; }
    
    [JsonPropertyName("payload")]
    public required T Payload { get; init; }
}