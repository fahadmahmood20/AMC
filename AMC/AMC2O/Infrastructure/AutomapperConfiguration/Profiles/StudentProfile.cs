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
                .ForMember(dest => dest.school, src => src.Ignore())
                .AfterMap((src, dst) =>
                {
                });
            CreateMap<StudentVM, Student>()
                .ForMember(dest => dest.Phone, src => src.Ignore())
                .ForMember(dest => dest.SchoolId, src => src.Ignore())
                .ForMember(dest => dest.Address, src => src.Ignore())
                .AfterMap((src, dst) =>
                {
                });
        }
    }
}
