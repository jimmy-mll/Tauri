using System.Text.Json;
using System.Text.Json.Serialization;
using Tauri.Extensions;
using Tauri.Models.Event;

namespace Tauri.Json.Converters;

public sealed class EventNameConverter : JsonConverter<EventName>
{
    public override EventName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var eventName = reader.GetString();
        
        if (string.IsNullOrEmpty(eventName))
            throw new JsonException("Event name cannot be null or empty.");

        return eventName.StartsWith("tauri://")
            ? new EventName(eventName.ToTauriEvent())
            : new EventName(eventName);
    }

    public override void Write(Utf8JsonWriter writer, EventName value, JsonSerializerOptions options)
    {
        var eventName = value.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);
        
        writer.WriteStringValue(eventName);
    }
}