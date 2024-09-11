using Tauri.Models.Cli;

namespace Tauri.Services.Cli;

/// <summary>
/// Parse arguments from your Command Line Interface.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.cli</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
public interface ICliService
{
    /// <summary>
    /// Parse the arguments provided to the current process and get the matches using the configuration defined in
    /// <a href="https://tauri.app/v1/api/config/#tauriconfig.cli">tauri.cli</a> in <c>tauri.conf.json</c>
    /// </summary>
    ValueTask<CliMatches> GetMatchesAsync();
}