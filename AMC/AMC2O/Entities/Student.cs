﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Entities
{
    public class Student
    {
        public Student()
        {
            address = new List<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        ////public string Address { get; set; }
        public string Phone { get; set; }
        public int SchoolId { get; set; }
        public School school { get; set; }
        public IList<Address> address{ get; set; }
    }
}
