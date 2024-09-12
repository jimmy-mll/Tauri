using Microsoft.JSInterop;
using Tauri.Models.Fs;

namespace Tauri.Services.Fs;

/// <inheritdoc />
public sealed class FsService(IJSRuntime jsRuntime) : IFsService
{
    /// <inheritdoc />
    public ValueTask CopyFileAsync(string source, string destination, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.copyFile", source, destination)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.copyFile", source, destination, options);
    }

    /// <inheritdoc />
    public ValueTask CreateDirAsync(string dir, FsDirOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.createDir", dir)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.createDir", dir, options);
    }

    /// <inheritdoc />
    public ValueTask<bool> ExistAsync(string path, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeAsync<bool>("window.__TAURI__.fs.exists", path)
            : jsRuntime.InvokeAsync<bool>("window.__TAURI__.fs.exists", path, options);
    }

    /// <inheritdoc />
    public ValueTask<byte[]> ReadBinaryFileAsync(string filePath, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeAsync<byte[]>("window.__TAURI__.fs.readBinaryFile", filePath)
            : jsRuntime.InvokeAsync<byte[]>("window.__TAURI__.fs.readBinaryFile", filePath, options);
    }

    /// <inheritdoc />
    public ValueTask<FileEntry[]> ReadDirAsync(string dir, FsDirOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeAsync<FileEntry[]>("window.__TAURI__.fs.readDir", dir)
            : jsRuntime.InvokeAsync<FileEntry[]>("window.__TAURI__.fs.readDir", dir, options);
    }

    /// <inheritdoc />
    public ValueTask<string> ReadTextFileAsync(string filePath, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeAsync<string>("window.__TAURI__.fs.readTextFile", filePath)
            : jsRuntime.InvokeAsync<string>("window.__TAURI__.fs.readTextFile", filePath, options);
    }

    /// <inheritdoc />
    public ValueTask RemoveDirAsync(string dir, FsDirOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.removeDir", dir)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.removeDir", dir, options);
    }

    /// <inheritdoc />
    public ValueTask RemoveFileAsync(string file, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.removeFile", file)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.removeFile", file, options);
    }

    /// <inheritdoc />
    public ValueTask RenameFileAsync(string oldPath, string newPath, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.renameFile", oldPath, newPath)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.renameFile", oldPath, newPath, options);
    }

    /// <inheritdoc />
    public ValueTask WriteBinaryFileAsync(string path, byte[] contents, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeBinaryFile", path, contents)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeBinaryFile", path, contents, options);
    }

    /// <inheritdoc />
    public ValueTask WriteBinaryFileAsync(FsBinaryFileOptions file, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeBinaryFile", file.Path, file.Contents)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeBinaryFile", file.Path, file.Contents, options);
    }

    /// <inheritdoc />
    public ValueTask WriteTextFileAsync(string path, string contents, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeTextFile", path, contents)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeTextFile", path, contents, options);
    }

    /// <inheritdoc />
    public ValueTask WriteTextFileAsync(FsTextFileOptions file, FsOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeTextFile", file.Path, file.Contents)
            : jsRuntime.InvokeVoidAsync("window.__TAURI__.fs.writeTextFile", file.Path, file.Contents, options);
    }
}