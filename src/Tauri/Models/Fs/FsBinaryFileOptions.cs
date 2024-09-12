using System.Text.Json.Serialization;

namespace Tauri.Models.Fs;

public sealed class FsBinaryFileOptions
{
    [JsonPropertyName("path")]
    public required string Path { get; set; }
    
    [JsonPropertyName("contents")]
    public required byte[] Contents { get; set; }
}