using Microsoft.JSInterop;
using Tauri.Models.Cli;

namespace Tauri.Services.Cli;

/// <inheritdoc />
public sealed class CliService(IJSRuntime jsRuntime) : ICliService
{
    /// <inheritdoc />
    public ValueTask<CliMatches> GetMatchesAsync()
    {
        return jsRuntime.InvokeAsync<CliMatches>("window.__TAURI__.cli.getMatches");
    }
}