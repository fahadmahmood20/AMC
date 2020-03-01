using AMC2O.Infrastructure.AutomapperConfiguration.Profiles;
using AutoMapper;
using AutoMapper.Configuration;
using System;
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
                    mappingExpression.MaxDepth(10);
                    Expression<Action<object, object, ResolutionContext>> beforeMapAction = (src, dest, context) => BeforeMapActionFunc(src, dest, context);
                    typeMap.AddBeforeMapAction(beforeMapAction);
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
            ////resolutionContext.Items.Add(resolutionContext.InstanceCache.Count.ToString(), resolutionContext);
            ////var ttttt = resolutionContext
            AssignPropertyValue(destination, resolutionContext, resolutionContext.InstanceCache);
        }

        private static void AssignPropertyValue(object value, ResolutionContext context, Dictionary<ContextCacheKey, object> cache)
        {
            var key = new ContextCacheKey(value, value.GetType());
            if (cache.ContainsKey(key))
            {
                var parent = cache[key];

                var parentProperty = value.GetType().GetProperty(parent.GetType().Name, parent.GetType());

                if (parentProperty != null && parentProperty.CanWrite)
                {
                    parentProperty.SetValue(value, parent, null);
                }
            }

            //if (context != null)
            //{
            //    AssignPropertyValue(value, context, cache);
            //}
        }
    }
}
