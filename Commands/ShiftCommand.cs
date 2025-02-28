using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Commands
{
    public class ShiftCommand : ICommand
    {
        private readonly IEntity Self;
        private string CurrentForm;
        private string NewForm;

        public ShiftCommand(IEntity self)
        {
            this.Self = self;
            this.CurrentForm = ((IShiftable)self).Form;
        }

        public ShiftCommand(IEntity self, string newForm)
        {
            this.Self = self;
            this.CurrentForm = ((IShiftable)self).Form;
            this.NewForm = newForm;
        }

        public void SetNewForm(string form)
        {
            this.NewForm = form;
        }

        public void Execute()
        {
            Console.WriteLine($"{Self.Name} shifts from {CurrentForm} into {NewForm}");
            ((IShiftable)Self).Form = NewForm;
            CurrentForm = NewForm;
            NewForm = "Human";
        }

    }
}
