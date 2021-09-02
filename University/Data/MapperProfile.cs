using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Entities;
using University.Models.ViewModels.Students;

namespace University.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentsIndexViewModel>();
            CreateMap<Student, StudentCreateViewModel>().ReverseMap();

            CreateMap<Student, StudentsDetailsViewModel>()
                .ForMember(
                        dest => dest.Attending,
                        from => from.MapFrom(s => s.Enrollments.Count));
                //.ForMember(
                //        dest => dest.Courses,
                //        from => from.MapFrom(s => s.Enrollments.Select(e => e.Course).ToList()));
        }
    }
}
