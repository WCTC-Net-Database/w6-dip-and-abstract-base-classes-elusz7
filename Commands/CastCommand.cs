using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Commands
{
    class CastCommand : ICommand
    {
        private readonly IEntity Self;
        private IEntity Target;
        private string Spell;

        public CastCommand(IEntity self, IEntity target)
        {
            this.Self = self;
            this.Target = target;
            this.Spell = ((ICastable)Self).Spell;
        }

        public CastCommand(IEntity self, IEntity target, string spell)
        {
            this.Self = self;
            this.Target = target;
            this.Spell = spell;
        }

        public void SetSpell(string spell)
        {
            this.Spell = spell;
        }


        public void SetTarget(IEntity target)
        {
            this.Target = target;
        }

        public void Execute()
        {
            if (this.Target != null)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Self.Name} casts {Spell} at {Target.Name}");
                Console.ResetColor();

                if (Self is PlayerBase player && Target is ILootable victim && !string.IsNullOrEmpty(victim.Treasure))
                {
                    if (victim.Treasure != "None")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{player.Name} takes {victim.Treasure} from {Target.Name}");
                        Console.ResetColor();
                        player.Equipment.Add(victim.Treasure); //Add treasure to player's equipment
                        victim.Treasure = "None"; // Treasure is taken
                    }
                    else
                    {
                        Console.WriteLine($"{Target.Name} has no treasure to take");
                    }
                }
                else if (Self is PlayerBase attacker && Target is PlayerBase defender && defender.Gold > 0)
                {
                    Console.WriteLine($"{attacker.Name} takes gold from {defender.Name}");
                    attacker.Gold += defender.Gold;
                    defender.Gold = 0; // Gold is taken
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Self.Name} casts {Spell}");
                Console.ResetColor();
            }

            Target = null;
        }
    }
}
