using AutoMapper;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Areas.Identity.Pages.Account;
using University.Models.Entities;
using University.Models.ViewModels.Students;

namespace University.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            var faker = new Faker();

            CreateMap<RegisterModel.InputModel, Student>()
                .ForMember(dest => dest.UserName, from => from.MapFrom(i => i.Email))
                .AfterMap((source, destination, context) =>
                {
                    destination.Avatar = string.IsNullOrWhiteSpace(source.Avatar) ? faker.Internet.Avatar() : source.Avatar;
                    destination.Adress = context.Mapper.Map<Adress>(source);
                
                }).ReverseMap();


            CreateMap<RegisterModel.InputModel, Adress>();

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
