using System.Text.Json.Serialization;

namespace Tauri.Models.Fs;

public sealed class FsOptions
{
    [JsonPropertyName("dir")]
    public BaseDirectory? Dir { get; init; }
    
    [JsonPropertyName("append")]
    public bool? Append { get; init; }
}