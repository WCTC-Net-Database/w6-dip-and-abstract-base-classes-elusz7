using System.Text.Json;
using System.Text.Json.Serialization;
using W6_assignment_template.Entities;
using W6_assignment_template.Models;

namespace W6_assignment_template.Data;

public class CharacterBaseConverter : JsonConverter<CharacterBase>
{
    public override CharacterBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            var typeProperty = root.GetProperty("$type").GetString();
            var classProperty = root.TryGetProperty("Type", out JsonElement classElement) ? classElement.GetString() : null;
            Type type = typeProperty switch
            {
                "W6_assignment_template.Models.PlayerBase" when classProperty.Equals("Fighter") => typeof(Fighter),
                "W6_assignment_template.Models.PlayerBase" when classProperty.Equals("Mage") => typeof(Mage),
                "W6_assignment_template.Models.PlayerBase" when classProperty.Equals("Druid") => typeof(Druid),
                "W6_assignment_template.Models.Goblin" => typeof(Goblin),
                "W6_assignment_template.Models.Ghost" => typeof(Ghost),
                _ => throw new NotSupportedException($"Type {typeProperty} is not supported")
            };

            return (CharacterBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, CharacterBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
