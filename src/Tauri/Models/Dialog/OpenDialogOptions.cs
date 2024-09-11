using System.Text.Json.Serialization;

namespace Tauri.Models.Dialog;

public sealed class OpenDialogOptions : SaveDialogOptions
{
    [JsonPropertyName("multiple")]
    public bool? Multiple { get; init; }
    
    [JsonPropertyName("directory")]
    public bool? Directory { get; init; }
    
    [JsonPropertyName("recursive")]
    public bool? Recursive { get; init; }
}