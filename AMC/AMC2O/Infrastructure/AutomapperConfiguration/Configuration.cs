using AMC2O.Entities;
using AMC2O.Entities.VM;
using AMC2O.Infrastructure.AutomapperConfiguration.Profiles;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Infrastructure.AutomapperConfiguration
{
    public static class Configuration
    {
        public static IMapper InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StudentProfile());
                cfg.AddProfile(new SchoolProfile());
                cfg.AddProfile(new AddressProfile());
                cfg.AddProfile(new RoomProfile());
                cfg.ForAllMaps((typeMap, mappingExpression) =>
                {
                    mappingExpression.PreserveReferences();
                    mappingExpression.ForAllMembers(s => s.MapAtRuntime());

                    if (typeMap.SourceType.Name == "Student")
                    {
                        

                        mappingExpression.ConstructUsing((source, context) =>
                        {
                            object value = null;
                            if (source.GetType().Name == "Student")
                            {
                                if (typeMap.PropertyMaps != null)
                                {
                                    // do not map properties for refrence entities - otherwise nhibernate will try to update parent object and will give error
                                    foreach (var propertyMap in typeMap.PropertyMaps)
                                    {
                                        if (propertyMap.DestinationName == "Phone")
                                        {
                                            propertyMap.Ignored = true;
                                        }
                                    }
                                }
                                value = new StudentVM() { Id = 1, Name = "Fahad Mahmood", Phone = "+9203218899644", SchoolId = 1, school = new SchoolVM() { Id = 1, Name = "Boys High School" } };
                            }
                            return value;
                        });
                    }


                    //mappingExpression.ConvertUsing((src, dst) => 
                    //{
                    //    return null;
                    //});
                    //mappingExpression.ConvertUsing((src, dst, ctx) => 
                    //{
                    //    return null;
                    //});

                    ////mappingExpression.ConstructUsing((src, context) => 
                    ////{
                    ////    return null;
                    ////});
                });
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;
                cfg.Advanced.AllowAdditiveTypeMapCreation = true;
            });
            config.AssertConfigurationIsValid();
            ////config.CompileMappings();
            return config.CreateMapper();
        }
        public static void BeforeMapActionFunc(object source, object destination, ResolutionContext resolutionContext)
        {

        }

        ////private static void AssignPropertyValue(object value, ResolutionContext context, Dictionary<ContextCacheKey, object> cache)
        ////{
        ////    var key = new ContextCacheKey(value, value.GetType());
        ////    if (cache.ContainsKey(key))
        ////    {
        ////        var parent = cache[key];

        ////        var parentProperty = value.GetType().GetProperty(parent.GetType().Name, parent.GetType());

        ////        if (parentProperty != null && parentProperty.CanWrite)
        ////        {
        ////            parentProperty.SetValue(value, parent, null);
        ////        }
        ////    }

        ////    //if (context != null)
        ////    //{
        ////    //    AssignPropertyValue(value, context, cache);
        ////    //}
        ////}
    }
}
