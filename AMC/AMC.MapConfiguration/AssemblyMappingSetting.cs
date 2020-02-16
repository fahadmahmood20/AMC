using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMC.MapConfiguration
{
    public static class AssemblyMappingSetting
    {
        public static IMapper CreateMapper(params Assembly[] assembly)
        {
            
            var config = new MapperConfiguration(
                cfg =>
                {
                    GetProfiles(assembly).ToList().ForEach(type =>
                    {
                        ////cfg.CreateMap<typeof(type), type.Name>();
                    });
                    //cfg.CreateMap<Children, Setting>();
                    //cfg.CreateMap<SettingCollection, SettingCollection>();
                    //cfg.CreateMap<SettingElement, SettingElement>();
                });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
        private static IEnumerable<Type> GetProfiles(params Assembly[] assemblies)
        {
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (!type.IsAbstract && typeof(Profile).IsAssignableFrom(type))
                    {
                        types.Add(type);
                    }
                }
            }

            return types;
        }
    }
}
