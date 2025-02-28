using System.Reflection.Emit;
using System.Xml.Linq;
using W6_assignment_template.Data;
using W6_assignment_template.Entities;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Fighter _fighter;
        private readonly Goblin _goblin;

        public GameEngine(IContext context)
        {
            _context = context;
            _fighter = context.Characters.OfType<Fighter>().FirstOrDefault();
            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
        }

        public void Run()
        {
            if (_fighter == null || _goblin == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            Console.WriteLine($"Player Gold: {_fighter.Gold}");
            Console.WriteLine($"Player Equipment: {string.Join(", ", _fighter.Equipment)}");

            _goblin.Move();
            _goblin.Attack(_fighter);

            _fighter.Move();
            _fighter.Attack(_goblin);

            Console.WriteLine($"Player Gold: {_fighter.Gold}");
            Console.WriteLine($"Player Equipment: {string.Join(", ", _fighter.Equipment)}");

            // Example CRUD operations for Goblin
            var newGoblin = new Goblin("New Goblin", 1, 30, "None");
            _context.AddCharacter(newGoblin);

            newGoblin.Level = 2;
            _context.UpdateCharacter(newGoblin);

            _context.DeleteCharacter("New Goblin");


            Console.WriteLine("--------------------");
            //druid
            var _druid = new Druid("Elf", 3, 19, new List<string> { "staff", "scroll", "potion" }, 20);
            _context.AddCharacter(_druid);
            _druid.Shift("Bear");
            _druid.Form = "Human";
            _druid.UniqueBehavior();
            Console.WriteLine($"{_druid.Name} Gold: {_druid.Gold}");

            _druid.Move();
            _druid.Attack(_fighter);

            Console.WriteLine($"Player Gold: {_fighter.Gold}");
            Console.WriteLine($"{_druid.Name} Gold: {_druid.Gold}");


            Console.WriteLine("--------------------");
            //mage
            var _mage = new Mage("Wizard", 4, 25, new List<string> { "orb", "wand", "dagger" }, 30);
            _context.AddCharacter(_mage);
            Console.WriteLine($"{_mage.Name} Gold: {_mage.Gold}");
            Console.WriteLine($"{_mage.Name} Equipment: {string.Join(", ", _mage.Equipment)}");

            _mage.Move();
            _mage.Attack(_druid);
            _mage.Spell = "Ice Bolt";

            var _ghost = _context.Characters.OfType<Ghost>().FirstOrDefault();
            _ghost.Move();
            _ghost.Fly();
            _mage.Cast(_ghost);

            _mage.Spell = "Lightning Bolt";
            _mage.UniqueBehavior();

            Console.WriteLine($"{_druid.Name} Gold: {_druid.Gold}");
            Console.WriteLine($"{_mage.Name} Gold: {_mage.Gold}");
            Console.WriteLine($"{_mage.Name} Equipment: {string.Join(", ", _mage.Equipment)}");


            _context.UpdateCharacter(_goblin);
            _context.UpdateCharacter(_ghost);
            _context.UpdateCharacter(_fighter);
            _context.UpdateCharacter(_druid);
            _context.UpdateCharacter(_mage);
        }
    }
}
