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
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressVM>()
                .BeforeMap((s, d, c) =>
                {
                });
        }
    }
}
