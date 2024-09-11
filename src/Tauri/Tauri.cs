using Microsoft.JSInterop;
using Tauri.Services.App;

namespace Tauri;

/// <inheritdoc />
public sealed class Tauri : ITauri
{
    private readonly Lazy<IAppService> _app;
    
    /// <inheritdoc />
    public IAppService App =>
        _app.Value;
    
    public Tauri(IJSRuntime jsRuntime)
    {
        _app = new Lazy<IAppService>(() => new AppService(jsRuntime));
    }
}