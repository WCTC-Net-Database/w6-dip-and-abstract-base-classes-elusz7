using System.Text.Json.Serialization;

namespace W6_assignment_template.Models
{
    public abstract class PlayerBase : CharacterBase
    {
        public int Gold { get; set; }
        [JsonIgnore]
        public List<string> Equipment { get; set; }
        [JsonPropertyName("Equipment")]
        public string EquipmentString
        {
            get => string.Join("|", Equipment);
            set
            {
                Equipment = value.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
        public PlayerBase() {}
        protected PlayerBase(string name, int level, int hp, List<string> equipment, int gold)
            : base(name, level, hp)
        {
            Equipment = equipment;
            Gold = gold;
        }
    }
}
