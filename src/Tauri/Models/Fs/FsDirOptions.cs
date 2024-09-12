using System.Text.Json.Serialization;

namespace Tauri.Models.Fs;

public sealed class FsDirOptions
{
    [JsonPropertyName("dir")]
    public BaseDirectory? Dir { get; init; }
    
    [JsonPropertyName("recursive")]
    public bool? Recursive { get; init; }
}