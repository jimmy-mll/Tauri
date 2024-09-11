using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Tauri.Json.Nodes;

namespace Tauri.Json.Converters;

public sealed class OpenDialogResultConverter : JsonConverter<OneOf<NullValue, string, string[]>>
{
    public override OneOf<NullValue, string, string[]> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.GetString() is { } stringValue
                    ? OneOf<NullValue, string, string[]>.FromT1(stringValue)
                    : OneOf<NullValue, string, string[]>.FromT0(new NullValue());
            case JsonTokenType.StartArray:
                var stringValues = new List<string>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        return OneOf<NullValue, string, string[]>.FromT2(stringValues.ToArray());
                    }

                    if (reader.TokenType == JsonTokenType.String)
                    {
                        if (reader.GetString() is { } arrayStringValue)
                        {
                            stringValues.Add(arrayStringValue);
                        }
                    }
                }

                return OneOf<NullValue, string, string[]>.FromT0(new NullValue());

            case JsonTokenType.None:
            case JsonTokenType.StartObject:
            case JsonTokenType.EndObject:
            case JsonTokenType.EndArray:
            case JsonTokenType.PropertyName:
            case JsonTokenType.Comment:
            case JsonTokenType.Number:
            case JsonTokenType.Null:
            case JsonTokenType.True:
            case JsonTokenType.False:
            default:
                return OneOf<NullValue, string, string[]>.FromT0(new NullValue());
        }
    }

    public override void Write(Utf8JsonWriter writer, OneOf<NullValue, string, string[]> value, JsonSerializerOptions options)
    {
        switch (value.Index)
        {
            case 0:
                writer.WriteNullValue();
                break;
            
            case 1:
                writer.WriteStringValue(value.AsT1);
                break;
            
            case 2:
                writer.WriteStartArray();

                foreach (var stringValue in value.AsT2)
                {
                    writer.WriteStringValue(stringValue);
                }

                writer.WriteEndArray();
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}