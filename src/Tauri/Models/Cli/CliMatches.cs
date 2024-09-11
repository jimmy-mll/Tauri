using System.Text.Json.Serialization;

namespace Tauri.Models.Cli;

public sealed class CliMatches
{
    [JsonPropertyName("args")]
    public required Dictionary<string, ArgMatch> Args { get; init; }
    
    [JsonPropertyName("subcommand")]
    public SubcommandMatch? Subcommand { get; init; }
}