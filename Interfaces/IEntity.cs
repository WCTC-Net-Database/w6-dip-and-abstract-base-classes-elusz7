using W6_assignment_template.Commands;

namespace W6_assignment_template.Interfaces
{
    public interface IEntity
    {
        string Name { get; set; }
        public void Move();
        public void Attack(IEntity target);
    }
}
