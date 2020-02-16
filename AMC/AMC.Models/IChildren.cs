using AMC.Models.InnerCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Models
{
    public interface IChildren
    {
        string Name { get; set; }
        string FatherName { get; set; }
        ChildrenCollection childrenCollection { get; set; }
    }
}
