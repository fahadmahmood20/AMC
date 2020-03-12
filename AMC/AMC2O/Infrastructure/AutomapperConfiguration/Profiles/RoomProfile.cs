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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomVM>()
                .BeforeMap((s, d, c) =>
                {
                });
        }
    }
}
