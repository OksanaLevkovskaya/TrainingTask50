using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task50
{
    public class EmployeeData
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }

        public EmployeeData (string name, string position, string office)
        {
            Name = name;
            Position = position;
            Office = office;
        }
    }

    
}
