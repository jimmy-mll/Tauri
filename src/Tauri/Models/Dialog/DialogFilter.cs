using System.Text.Json.Serialization;

namespace Tauri.Models.Dialog;

public sealed class DialogFilter
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("extensions")]
    public required string[] Extensions { get; init; }
}