using System.Text.Json.Serialization;
using OneOf;
using Tauri.Json.Converters;
using Tauri.Json.Nodes;

namespace Tauri.Models.Cli;

public sealed class ArgMatch
{
    [JsonConverter(typeof(ArgMatchValueConverter))]
    [JsonPropertyName("value")]
    public required OneOf<NullValue, string, bool, string[]> Value { get; init; }
    
    [JsonPropertyName("occurrences")]
    public required int Occurrences { get; init; }
}