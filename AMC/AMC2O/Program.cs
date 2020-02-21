using AMC2O.Entities;
using AMC2O.Entities.VM;
using AMC2O.Infrastructure.AutomapperConfiguration;
using AMC2O.Infrastructure.AutomapperConfiguration.MapActions;
using AMC2O.Infrastructure.AutomapperConfiguration.Profiles;
using AMC2O.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O
{
    class Program
    {
        public delegate void Tester(Object src, Object dst, ResolutionContext resolutionContext);
        static void Main(string[] args)
        {
			try
			{
                
                var mapper = Configuration.InitializeAutoMapper();
                ////IMapper mapper = new Mapper(config);

                foreach (var item in mapper.ConfigurationProvider.GetAllTypeMaps())
                {
                    ////var t = Action<object, object, ResolutionContext>;
                    Expression<Tester> beforeMapAction = (src, dst, context) => Test(src, dst, context);
                    beforeMapAction.Compile();
                    item.AddAfterMapAction(beforeMapAction);
                }

                var dest = mapper.Map<Student, StudentVM>(StudentService.GetStudent());
                

                var source = mapper.Map<StudentVM, Student>(dest);


                ////var test = new BaseService().GetMappingStudent();
            }
			catch (Exception ex)
			{
			}
        }
        public static void Test(Object src, Object dst, ResolutionContext resolutionContext)
        {

        }
    }

}
