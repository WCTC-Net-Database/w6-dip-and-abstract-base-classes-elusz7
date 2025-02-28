using W6_assignment_template.Interfaces;
using W6_assignment_template.Commands;
using W6_assignment_template.Models;
using System.Text.Json.Serialization;

namespace W6_assignment_template.Entities
{
    public class Mage : PlayerBase, ICastable
    {
        private string Type;
        public string Spell { get; set; }
        private readonly CastCommand CastCommand;
        public Mage()
        {
            Spell = "Fire Bolt";
            CastCommand = new(this, null);
        }
        public Mage(string name, int level, int hp, List<string> equipment, int gold)
            : base(name, level, hp, equipment, gold)
        {
            Spell = "Fire Bolt";
            CastCommand = new(this, null);
        }
        public void Cast(IEntity target)
        {
            CastCommand.SetSpell(Spell);
            CastCommand.SetTarget(target);
            CastCommand.Execute();
        }
        public override void Attack(IEntity target)
        {
            CastCommand.SetSpell(Spell);
            CastCommand.SetTarget(target);
            CastCommand.Execute();
        }
        public override void UniqueBehavior()
        {
            CastCommand.SetSpell(Spell);
            CastCommand.Execute();
        }

        [JsonPropertyName("Type")]
        public string TypeString
        {
            get => Type;
            set
            {
                Type = typeof(Mage).Name;
            }
        }
    }
}
