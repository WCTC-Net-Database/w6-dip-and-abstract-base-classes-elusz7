using System.Text.Json.Serialization;
using W6_assignment_template.Commands;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public abstract class CharacterBase : IEntity
    {
        [JsonIgnore]
        public string Name { get; set; }
        [JsonPropertyName("Name")]
        public string NameString
        {
            get
            {
                if (Name.Contains(" "))
                {
                    int index = Name.IndexOf(" ");
                    return $"{Name.Substring(index + 1)}, {Name.Substring(0, index)}";
                }
                return Name;
            }
            set
            {
                if (value.Contains(","))
                {
                    string[] names = value.Split(", ");
                    value = $"{names[1]} {names[0]}";
                }
                Name = value;
            }
        }
        public int Level { get; set; }
        public int HP { get; set; }

        private readonly MoveCommand MoveCommand;
        private readonly AttackCommand AttackCommand;

        protected CharacterBase(string name, int level, int hp)
        {
            Name = name;
            Level = level;
            HP = hp;
            MoveCommand = new MoveCommand(this);
            AttackCommand = new AttackCommand(this, null);
        }

        protected CharacterBase() 
        {
            MoveCommand = new MoveCommand(this);
            AttackCommand = new AttackCommand(this, null);
        }

        public virtual void Attack(IEntity target)
        {
            AttackCommand.SetTarget(target);
            AttackCommand.Execute();
        }

        public virtual void Move()
        {
            MoveCommand.Execute();
        }

        // Abstract method for unique behavior to be implemented by derived classes
        public abstract void UniqueBehavior();
    }
}
