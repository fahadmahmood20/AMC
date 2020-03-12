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
        ////public string Address { get; set; }
        public string Phone { get; set; }
        public int SchoolId { get; set; }
        public SchoolVM school { get; set; }
        public IList<AddressVM> address { get; set; }
    }
}
