using System.Text.Json.Serialization;

namespace Tauri.Models.Dialog;

public class SaveDialogOptions
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }
    
    [JsonPropertyName("filters")]
    public DialogFilter[]? Filters { get; init; }
    
    [JsonPropertyName("defaultPath")]
    public string? DefaultPath { get; init; }
}