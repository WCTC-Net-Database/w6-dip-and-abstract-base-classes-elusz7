using System.Text.Json.Serialization;
using W6_assignment_template.Commands;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Entities
{
    public class Druid : PlayerBase, IShiftable
    {
        public string Form { get; set; }
        private string Type;
        private readonly ShiftCommand ShiftCommand;
        public Druid()
        {
            this.Form = "Human";
            ShiftCommand = new ShiftCommand(this);
        }
        public Druid(string name, int level, int hp, List<string> equipment, int gold)
            : base(name, level, hp, equipment, gold)
        {
            this.Form = "Human";
            ShiftCommand = new ShiftCommand(this);
        }
        public void Shift(string form)
        {
            this.Form = form;
            ShiftCommand.SetNewForm(form);
            ShiftCommand.Execute();
        }
        public override void UniqueBehavior()
        {
            ShiftCommand.Execute();
        }

        [JsonPropertyName("Type")]
        public string TypeString
        {
            get => Type;
            set
            {
                Type = typeof(Druid).Name;
            }
        }
    }
}
