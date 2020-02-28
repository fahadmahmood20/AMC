using AMC2O.Entities;
using AMC2O.Entities.VM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Services
{
    public class BaseService
    {
        protected IMapper _mapper;
        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public StudentVM GetMappingStudent()
        {
            var stu = GetStudents();
            var result = _mapper.Map<StudentVM>(stu);
            return result;
        }
        public Student GetStudents()
        {
            return new Student() { Id = 1, Name = "Fahad Mahmood", Phone = "+9203218899633" };
        }
    }
}
