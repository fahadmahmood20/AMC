using AMC2O.Entities;
using AMC2O.Entities.VM;
using AMC2O.Infrastructure.AutomapperConfiguration;
using AMC2O.Infrastructure.AutomapperConfiguration.Profiles;
using AMC2O.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
                                
                var mapper = Configuration.InitializeAutoMapper();
                ////IMapper mapper = new Mapper(config);

                var dest = mapper.Map<Student, StudentVM>(StudentService.GetStudents());


                var source = mapper.Map<StudentVM, Student>(dest);


                ////var test = new BaseService().GetMappingStudent();
            }
			catch (Exception ex)
			{
			}
        }
    }
}
