using W6_assignment_template.Interfaces;
using W6_assignment_template.Commands;
using W6_assignment_template.Models;
using System.Text.Json.Serialization;

namespace W6_assignment_template.Entities
{
    public class Fighter : PlayerBase
    {
        private string Type;
        public Fighter() { }
        public Fighter(string name, int level, int hp, List<string> equipment, int gold)
            : base(name, level, hp, equipment, gold)
        {
        }

        public override void UniqueBehavior()
        {
            throw new System.NotImplementedException();
        }

        [JsonPropertyName("Type")]
        public string TypeString
        {
            get => Type;
            set
            {
                Type = typeof(Fighter).Name;
            }
        }
    }
}
