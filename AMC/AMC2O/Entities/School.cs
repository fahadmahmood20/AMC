using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Room room { get; set; }
        
    }
}
