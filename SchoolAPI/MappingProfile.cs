using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SchoolAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(c => c.CourseName,
                    opt => opt.MapFrom(x => x.CourseName));
            CreateMap<CourseCreationDto, Course>();
            CreateMap<CourseUpdateDto, Course>();


            CreateMap<Student, StudentDto>()
                .ForMember(c => c.UserName,
                    opt => opt.MapFrom(x => x.UserName));
            CreateMap<UserCreationDto, Student>();
            CreateMap<UserUpdateDto, Student>();
        }
    }
}
