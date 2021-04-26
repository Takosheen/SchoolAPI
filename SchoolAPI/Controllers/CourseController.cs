using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CoursesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllCourses")]
        public IActionResult GetCourses()
        {
            var courses = _repository.Course.GetAllCourses(trackChanges: false);
            var courseDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(courseDto);
        }

        [HttpGet("{id}", Name = "getCourseById")]
        public IActionResult GetCourse(Guid id)
        {
            var course = _repository.Course.GetCourse(id, trackChanges: false); if (course == null)
            {
                _logger.LogInfo($"Course with id: {id} does not exist in the database.");
                return NotFound();
            }
            else
            {
                var courseDto = _mapper.Map<CourseDto>(course);
                return Ok(courseDto);
            }
        }
    }
}