using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Commands;

public class AttackCommand : ICommand
{
    private readonly IEntity self;
    private IEntity target;
    public AttackCommand(IEntity self, IEntity target)
    {
        this.self = self;
        this.target = target;
    }
    public void SetTarget(IEntity target)
    {
        this.target = target;
    }
    public void Execute()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{self.Name} attacks {target.Name}");
        Console.ResetColor();

        if (self is PlayerBase player && target is ILootable victim && !string.IsNullOrEmpty(victim.Treasure))
        {
            if (victim.Treasure != "None")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{player.Name} takes {victim.Treasure} from {target.Name}");
                Console.ResetColor();
                player.Equipment.Add(victim.Treasure); //Add treasure to player's equipment
                victim.Treasure = "None"; // Treasure is taken
            }
            else
            {
                Console.WriteLine($"{target.Name} has no treasure to take");
            }
        }
        else if (self is PlayerBase attacker && target is PlayerBase defender && defender.Gold > 0)
        {
            Console.WriteLine($"{attacker.Name} takes gold from {defender.Name}");
            attacker.Gold += defender.Gold;
            defender.Gold = 0; // Gold is taken
        }
    }
}