using System.Text.Json;
using System.Text.Json.Serialization;
using Tauri.Models.Dialog;

namespace Tauri.Json.Converters;

public sealed class DialogTypeConverter : JsonConverter<DialogType?>
{
    public override DialogType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() switch
        {
            "info" => DialogType.Information,
            "warning" => DialogType.Warning,
            "error" => DialogType.Error,
            _ => null
        };
    }

    public override void Write(Utf8JsonWriter writer, DialogType? value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case DialogType.Information:
                writer.WriteStringValue("info");
                break;
            case DialogType.Warning:
                writer.WriteStringValue("warning");
                break;
            case DialogType.Error:
                writer.WriteStringValue("error");
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }
}