using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_assignment_template.Interfaces
{
    public interface IShiftable : IEntity
    {
        public string Form { get; set; }
        public void Shift(string form);
    }
}
