using AMC.CollectionHolder;
using AMC.Models.ConfigElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Models.InnerCollection
{
    public class ChildrenCollection : BaseWithICollection<ChildrenConfigElement>
    {
        public int DefaultValue { get; set; }
    }
}
