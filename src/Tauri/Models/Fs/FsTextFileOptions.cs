using System.Text.Json.Serialization;

namespace Tauri.Models.Fs;

public sealed class FsTextFileOptions
{
    [JsonPropertyName("path")]
    public required string Path { get; set; }
    
    [JsonPropertyName("contents")]
    public required string Contents { get; set; }
}