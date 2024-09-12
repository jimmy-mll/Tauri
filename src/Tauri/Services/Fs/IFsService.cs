using Tauri.Models.Fs;

namespace Tauri.Services.Fs;

/// <summary>
/// Access the file system.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.fs</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
/// <example>
/// The APIs must be added to <a href="https://tauri.app/v1/api/config/#allowlistconfig.fs">tauri.allowlist.fs</a> in <c>tauri.conf.json</c>:
/// <code>
/// {
///     "tauri": {
///         "allowlist": {
///             "fs": {
///                 "all": true, // enable all fs APIs
///                 "readFile": true,
///                 "writeFile": true,
///                 "readDir": true,
///                 "copyFile": true,
///                 "createDir": true,
///                 "removeDir": true,
///                 "removeFile": true,
///                 "renameFile": true,
///                 "exists": true
///             }
///         }
///     }
/// }
/// </code>
/// It is recommended to allowlist only the APIs you use for optimal bundle size and security.
/// </example>
public interface IFsService
{
    /// <summary>
    /// Copies a file to a destination.
    /// </summary>
    /// <param name="source">The source file path.</param>
    /// <param name="destination">The destination file path.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Copy the `$APPCONFIG/app.conf` file to `$APPCONFIG/app.conf.bk`
    /// await Tauri.Fs.CopyFileAsync("app.conf", "app.conf.bk", new FsOptions { Dir: BaseDirectory.AppConfig });
    /// </code>
    /// </example>
    ValueTask CopyFileAsync(string source, string destination, FsOptions? options = null);
    
    /// <summary>
    /// Creates a directory.
    /// </summary>
    /// <remarks>
    /// If one of the path's parent components doesn't exist and the <c>recursive</c> option isn't set to true, the promise will be rejected.
    /// </remarks>
    /// <param name="dir">The directory path to create.</param>
    /// <param name="options">Directory options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Create the `$APPDATA/users` directory
    /// await Tauri.Fs.CreateDirAsync("users", new FsDirOptions { Dir = BaseDirectory.AppData, Recursive = true });
    /// </code>
    /// </example>
    ValueTask CreateDirAsync(string dir, FsDirOptions? options = null);
    
    /// <summary>
    /// Check if a path exists.
    /// </summary>
    /// <param name="path">The path to check.</param>
    /// <param name="options">File system options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving a bool indicating whether the path exists or not.</returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Check if the `$APPDATA/avatar.png` file exists
    /// await Tauri.Fs.ExistAsync("avatar.png", new FsOptions { Dir = BaseDirectory.AppData });
    /// </code>
    /// </example>
    ValueTask<bool> ExistAsync(string path, FsOptions? options = null);
    
    
    /// <summary>
    /// Reads a file as byte array.
    /// </summary>
    /// <param name="filePath">The path of the file to read.</param>
    /// <param name="options">File system options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving the file's binary content as a byte array.</returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Read the image file in the `$RESOURCEDIR/avatar.png` path
    /// var contents = await Tauri.Fs.ReadBinaryFileAsync("avatar.png", new FsOptions { Dir = BaseDirectory.Resource });
    /// </code>
    /// </example>
    ValueTask<byte[]> ReadBinaryFileAsync(string filePath, FsOptions? options = null);
    
    /// <summary>
    /// List directory files.
    /// </summary>
    /// <param name="dir">The directory path to find.</param>
    /// <param name="options">Directory options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving an array of <see cref="FileEntry"/>.</returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Reads the `$APPDATA/users` directory recursively
    /// var entries = await Tauri.Fs.ReadDirAsync("users", new FsDirOptions { Dir = BaseDirectory.AppData, Recursive = true });
    /// void ProcessEntries(FileEntry[] entries)
    /// {
    ///     foreach (var entry in entries)
    ///     {
    ///         Console.WriteLine($"Entry: {entry.Path}");
    ///
    ///         if (entry.Children != null)
    ///         {
    ///             ProcessEntries(entry.Children);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    ValueTask<FileEntry[]> ReadDirAsync(string dir, FsDirOptions? options = null);
    
    /// <summary>
    /// Reads a file as an UTF-8 encoded string.
    /// </summary>
    /// <param name="filePath">The path of the file to read.</param>
    /// <param name="options">File system options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving the file's text content as a string.</returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Read the text file in the `$APPCONFIG/app.conf` path
    /// var contents = await Tauri.Fs.ReadTextFileAsync("app.conf", new FsOptions { Dir = BaseDirectory.AppConfig });
    /// </code>
    /// </example>
    ValueTask<string> ReadTextFileAsync(string filePath, FsOptions? options = null);
    
    /// <summary>
    /// Removes a directory.
    /// </summary>
    /// <remarks>
    /// If the directory is not empty and the <c>recursive</c> option isn't set to true, the promise will be rejected.
    /// </remarks>
    /// <param name="dir">The directory path to remove.</param>
    /// <param name="options">Directory options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Remove the directory `$APPDATA/users`
    /// await Tauri.Fs.RemoveDirAsync("users", new FsDirOptions { Dir = BaseDirectory.AppData });
    /// </code>
    /// </example>
    ValueTask RemoveDirAsync(string dir, FsDirOptions? options = null);
    
    /// <summary>
    /// Removes a file.
    /// </summary>
    /// <param name="file">The file to remove.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Remove the `$APPConfig/app.conf` file
    /// await Tauri.Fs.RemoveFileAsync("app.conf", new FsOptions { Dir = BaseDirectory.AppConfig });
    /// </code>
    /// </example>
    ValueTask RemoveFileAsync(string file, FsOptions? options = null);
    
    /// <summary>
    /// Renames a file.
    /// </summary>
    /// <param name="oldPath">The current file path.</param>
    /// <param name="newPath">The new file path.</param>
    /// <param name="options">File system options.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Rename the `$APPDATA/avatar.png` file
    /// await Tauri.Fs.RenameFileAsync("avatar.png", "deleted.png", new FsOptions { Dir = BaseDirectory.AppData });
    /// </code>
    /// </example>
    ValueTask RenameFileAsync(string oldPath, string newPath, FsOptions? options = null);
    
    /// <summary>
    /// Writes a byte array content to a file.
    /// </summary>
    /// <param name="path">The path of the file to write to.</param>
    /// <param name="contents">The binary content to write.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Write a binary file to the `$APPDATA/avatar.png` path
    /// await Tauri.Fs.WriteBinaryFileAsync("avatar.png", [], new FsOptions { Dir = BaseDirectory.AppData });
    /// </code>
    /// </example>
    ValueTask WriteBinaryFileAsync(string path, byte[] contents, FsOptions? options = null);

    /// <summary>
    /// Writes a byte array content to a file.
    /// </summary>
    /// <param name="file">The file options containing the path and content.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Write a binary file to the `$APPDATA/avatar.png` path
    /// await Tauri.Fs.WriteBinaryFileAsync(new FsBinaryFileOptions { Path = "avatar.png", Contents = [] }, new FsOptions { Dir = BaseDirectory.AppData });
    /// </code>
    /// </example>
    ValueTask WriteBinaryFileAsync(FsBinaryFileOptions file, FsOptions? options = null);
    
    /// <summary>
    /// Writes a UTF-8 text file.
    /// </summary>
    /// <param name="path">The path of the file to write to.</param>
    /// <param name="contents">The text content to write.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Write a text file to the `$APPCONFIG/app.conf` path
    /// await Tauri.Fs.WriteTextFileAsync("app.conf", "file contents", new FsOptions { Dir = BaseDirectory.AppConfig });
    /// </code>
    /// </example>
    ValueTask WriteTextFileAsync(string path, string contents, FsOptions? options = null);

    /// <summary>
    /// Writes a UTF-8 text file.
    /// </summary>
    /// <param name="file">The file options containing the path and content.</param>
    /// <param name="options">File system options.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Write a text file to the `$APPCONFIG/app.conf` path
    /// await Tauri.Fs.WriteTextFileAsync(new FsTextFileOptions { Path = "app.conf", Contents = "file contents" }, new FsOptions { Dir = BaseDirectory.AppConfig });
    /// </code>
    /// </example>
    ValueTask WriteTextFileAsync(FsTextFileOptions file, FsOptions? options = null);
}