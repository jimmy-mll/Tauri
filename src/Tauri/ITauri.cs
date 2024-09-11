using Tauri.Services.App;
using Tauri.Services.Cli;

namespace Tauri;

/// <summary>
/// Represents the Tauri API.
/// </summary>
public interface ITauri
{
    /// <inheritdoc cref="IAppService" />
    IAppService App { get; }
    
    /// <inheritdoc cref="ICliService" />
    ICliService Cli { get; }
}