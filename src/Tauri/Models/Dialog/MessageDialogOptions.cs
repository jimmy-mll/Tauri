using System.Text.Json.Serialization;
using Tauri.Json.Converters;

namespace Tauri.Models.Dialog;

public class MessageDialogOptions
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }
    
    [JsonConverter(typeof(DialogTypeConverter))]
    [JsonPropertyName("type")]
    public DialogType? Type { get; init; }
    
    [JsonPropertyName("okLabel")]
    public string? OkLabel { get; init; }
}