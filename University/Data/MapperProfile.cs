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
        }
    }
}
