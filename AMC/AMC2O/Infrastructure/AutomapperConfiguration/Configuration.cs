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
                    Expression<Action<object, object, ResolutionContext>> beforeMapAction = (src, dest, context) => BeforeMapActionFunc(src, dest, context);
                    typeMap.AddBeforeMapAction(beforeMapAction);

                    ////mappingExpression.ConstructUsing((s, d) =>
                    //// {
                    ////     ////d.InstanceCache.Add(d, s);
                    ////     return d;
                    //// });
                });
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;
                cfg.Advanced.AllowAdditiveTypeMapCreation = true;
            });
            ////config.AssertConfigurationIsValid();
            ////config.CompileMappings();
            return config.CreateMapper();
        }
        public static void BeforeMapActionFunc(object source, object destination, ResolutionContext resolutionContext)
        {
        }
    }
}
