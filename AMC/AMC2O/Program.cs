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
                Action<IMappingOperationOptions> action = GetMappingOperationOptionsAction();
                var dest = mapper.Map<StudentVM>(StudentService.GetStudent(), action);
                var dest2 = mapper.Map<StudentVM>(StudentService.GetStudent2(), action);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
            }
        }
        private static Action<IMappingOperationOptions> GetMappingOperationOptionsAction()
        {
            return new Action<IMappingOperationOptions>((x) =>
            {
                x.Items.Add("SkipRefrential", true);
            });
        }

    }

}
