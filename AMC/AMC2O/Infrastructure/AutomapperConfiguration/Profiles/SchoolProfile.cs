using AMC2O.Entities;
using AMC2O.Entities.VM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Infrastructure.AutomapperConfiguration.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolVM>()
                .BeforeMap((s, d, c) =>
                {
                });
        }
    }
}
