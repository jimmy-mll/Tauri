using System.Text.Json.Serialization;

namespace Tauri.Models.Cli;

public sealed class SubcommandMatch
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("matches")]
    public required CliMatches Matches { get; init; }
}