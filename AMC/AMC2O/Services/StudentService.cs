using AMC2O.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Services
{
    public class StudentService
    {
        public static Student GetStudents()
        {
            return new Student() { Id = 1, Name = "Fahad Mahmood", Phone = "+9203218899633", Address = "Tricon Tower" };
        }
    }
}
