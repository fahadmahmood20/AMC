using AMC2O.Infrastructure.AutomapperConfiguration.Profiles;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
            });
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
