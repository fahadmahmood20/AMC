using AMC2O.Entities;
using AMC2O.Entities.VM;
using AMC2O.Infrastructure.AutomapperConfiguration.MapActions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Infrastructure.AutomapperConfiguration.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentVM>()
                .ForMember(d => d.Name, s => s.Ignore())
                .BeforeMap((src, dst, ctx) =>
                {
                })
                .AfterMap((src, dst, ctx) =>
                {
                });
                ////.ForMember(d => d.Phone, s => s.Condition((a, b, d, e, c) =>
                ////{
                ////    ////if(c.Items.ContainsKey()
                ////    return false;
                ////}));
        }
    }
}
