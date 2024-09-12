using System.Text.Json.Serialization;

namespace Tauri.Models.Fs;

public sealed class FileEntry
{
    [JsonPropertyName("path")]
    public required string Path { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("children")]
    public FileEntry[]? Children { get; init; }
}