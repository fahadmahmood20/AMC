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
        public static Student GetStudent()
        {
            return new Student() { Id = 1, Name = "Fahad Mahmood", Phone = "+9203218899633", Address = "Tricon Tower", SchoolId = 1, school = new School() { Id = 1, Name = "Boys High School", Address = "Dharampura, Lahore" } };
        }
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student() { Id = 1, Name = "Amir Mahmood", Phone = "+923217776661", Address = "Tricon Tower",SchoolId = 1, school = new School() { Id=1, Name="Boys High School", Address = "Dharampura, Lahore" } },
                new Student() { Id = 2, Name = "Fahad Mahmood", Phone = "+923218899633", Address = "Tricon Tower",SchoolId = 1, school = new School() { Id=1, Name="Boys High School", Address = "Dharampura, Lahore" } },
                new Student() { Id = 3, Name = "Zahid Mahmood", Phone = "+923217678442", Address = "Tricon Tower",SchoolId = 1, school = new School() { Id=1, Name="Boys High School", Address = "Dharampura, Lahore" } }
            };
        }
    }
}
