﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Entities.VM
{
    public class SchoolVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomVM room { get; set; }
    }
}
