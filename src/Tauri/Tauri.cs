using Microsoft.JSInterop;
using Tauri.Services.App;
using Tauri.Services.Cli;

namespace Tauri;

/// <inheritdoc />
public sealed class Tauri : ITauri
{
    private readonly Lazy<IAppService> _app;
    private readonly Lazy<ICliService> _cli;
    
    /// <inheritdoc />
    public IAppService App =>
        _app.Value;
    
    /// <inheritdoc />
    public ICliService Cli =>
        _cli.Value;
    
    public Tauri(IJSRuntime jsRuntime)
    {
        _app = new Lazy<IAppService>(() => new AppService(jsRuntime));
        _cli = new Lazy<ICliService>(() => new CliService(jsRuntime));
    }
}