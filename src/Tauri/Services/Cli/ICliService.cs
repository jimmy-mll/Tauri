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
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var matches = await Tauri.Cli.GetMatchesAsync();
    /// if (matches.Subcommand?.Name == "run")
    /// {
    ///     //`./your-app run $ARGS` was executed
    ///     var args = matches.Subcommand?.Matches.Args;
    ///     if (args != null &amp;&amp; args.ContainsKey("--debug"))
    ///     {
    ///         //`./your-app run --debug` was executed
    ///     }
    /// }
    /// else
    /// {
    ///     //`./your-app $ARGS` was executed
    /// }
    /// </code>
    /// </example>
    ValueTask<CliMatches> GetMatchesAsync();
}