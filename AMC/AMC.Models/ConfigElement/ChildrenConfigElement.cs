using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Models.ConfigElement
{
    public class ChildrenConfigElement : ConfigurationElement
    {
        public string SchoolName { get; set; }
        public string CityName { get; set; }
    }
}
