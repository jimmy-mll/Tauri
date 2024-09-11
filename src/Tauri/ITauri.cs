using Tauri.Services.App;

namespace Tauri;

/// <summary>
/// Represents the Tauri API.
/// </summary>
public interface ITauri
{
    /// <inheritdoc cref="IAppService" />
    IAppService App { get; }
}