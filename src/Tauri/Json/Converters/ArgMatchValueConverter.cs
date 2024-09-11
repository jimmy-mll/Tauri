using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Tauri.Json.Nodes;

namespace Tauri.Json.Converters;

public sealed class ArgMatchValueConverter : JsonConverter<OneOf<NullValue, string, bool, string[]>>
{
    public override OneOf<NullValue, string, bool, string[]> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.GetString() is { } stringValue
                    ? OneOf<NullValue, string, bool, string[]>.FromT1(stringValue)
                    : OneOf<NullValue, string, bool, string[]>.FromT0(new NullValue());
            
            case JsonTokenType.True:
            case JsonTokenType.False:
                return OneOf<NullValue, string, bool, string[]>.FromT2(reader.GetBoolean());
            
            case JsonTokenType.StartArray:
                var stringValues = new List<string>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        return OneOf<NullValue, string, bool, string[]>.FromT3(stringValues.ToArray());
                    }

                    if (reader.TokenType == JsonTokenType.String)
                    {
                        if (reader.GetString() is { } arrayStringValue)
                        {
                            stringValues.Add(arrayStringValue);
                        }
                    }
                }

                return OneOf<NullValue, string, bool, string[]>.FromT0(new NullValue());

            case JsonTokenType.None:
            case JsonTokenType.StartObject:
            case JsonTokenType.EndObject:
            case JsonTokenType.EndArray:
            case JsonTokenType.PropertyName:
            case JsonTokenType.Comment:
            case JsonTokenType.Number:
            case JsonTokenType.Null:
            default:
                return OneOf<NullValue, string, bool, string[]>.FromT0(new NullValue());
        }
    }

    public override void Write(Utf8JsonWriter writer, OneOf<NullValue, string, bool, string[]> value, JsonSerializerOptions options)
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
                writer.WriteBooleanValue(value.AsT2);
                break;
            
            case 3:
                writer.WriteStartArray();

                foreach (var stringValue in value.AsT3)
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