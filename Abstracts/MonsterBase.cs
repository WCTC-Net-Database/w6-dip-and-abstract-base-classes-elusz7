using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public abstract class MonsterBase : CharacterBase, ILootable
    {
        public string Treasure { get; set; }
        public MonsterBase() { }
        protected MonsterBase(string name, int level, int hp, string treasure)
            : base(name, level, hp)
        {
            Treasure = treasure;
        }
    }
}
