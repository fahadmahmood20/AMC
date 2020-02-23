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
        ////public delegate void Tester(Object src, Object dst, ResolutionContext resolutionContext);
        static void Main(string[] args)
        {
            try
            {

                var mapper = Configuration.InitializeAutoMapper();
                ////IMapper mapper = new Mapper(config);

                foreach (var item in mapper.ConfigurationProvider.GetAllTypeMaps())
                {
                    ////var t = Action<object, object, ResolutionContext>;
                    Expression<Action<object, object, ResolutionContext>> beforeMapAction = (src, dst, context) => Test(src, dst, context);
                    ////Expression<Action<int>> beforeMapAction = (x) => Console.WriteLine("Test");
                    ////beforeMapAction.Compile().Invoke(10);
                    item.AddAfterMapAction(beforeMapAction);
                    ////item.AfterMapActions<NameMeJohnActionInterface>();
                }

                foreach (var item in mapper.ConfigurationProvider.GetAllTypeMaps())
                {
                }

                var dest = mapper.Map<Student, StudentVM>(StudentService.GetStudent());


                var source = mapper.Map<StudentVM, Student>(dest);

                Console.ReadLine();
                ////var test = new BaseService().GetMappingStudent();
            }
            catch (Exception ex)
            {
            }
        }
        ////public static void Test(int x)
        ////{
        ////    Console.WriteLine("X = {0}", x);
        ////}
        public static void Test(Object src, Object dst, ResolutionContext context)
        {
            // do not map properties for refrence entities - otherwise nhibernate will try to update parent object and will give error
            foreach (var propertyMap in context.ConfigurationProvider.GetAllTypeMaps().SelectMany(c => c.PropertyMaps))
            {
                propertyMap.Ignored = true;
            }
        }
    }

}
