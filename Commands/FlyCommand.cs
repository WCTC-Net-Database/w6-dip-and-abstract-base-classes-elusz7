using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Commands;
public class FlyCommand : ICommand
{
    private readonly IEntity self;
    public FlyCommand(IEntity entity)
    {
        this.self = entity;
    }
    public void Execute()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"{self.Name} flies rapidly through the air.");
        Console.ResetColor();
    }
}

