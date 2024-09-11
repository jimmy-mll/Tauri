using System.Text.Json.Serialization;

namespace Tauri.Models.Dialog;

public sealed class ConfirmDialogOptions : MessageDialogOptions
{
    [JsonPropertyName("cancelLabel")]
    public string? CancelLabel { get; init; }
}