using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Entities.VM
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SchoolVM school { get; set; }
    }
}
