using W6_assignment_template.Interfaces;
using W6_assignment_template.Commands;
using W6_assignment_template.Models;
using System.Text.Json.Serialization;

namespace W6_assignment_template.Entities
{
    public class Ghost : MonsterBase, IFlyable
    {
        private string Type;
        private readonly FlyCommand FlyCommand;
        public Ghost() { 
            FlyCommand = new(this);
        }
        public Ghost(string name, int level, int hp, string treasure) 
            : base(name, level, hp, treasure)
        {
            FlyCommand = new(this);
        }

        public override void Move()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} tries to move, but ghosts can't walk.");
            Console.ResetColor();
        }

        public void Fly()
        {
            FlyCommand.Execute();
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }

        [JsonPropertyName("Type")]
        public string TypeString
        {
            get => Type;
            set
            {
                Type = typeof(Ghost).Name;
            }
        }
    }
}
