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
            throw new Exception("Exception");
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
        [HttpPost(Name = "createCourse")]
        public IActionResult CreateCourse([FromBody] CourseCreationDto course)
        {
            if (course == null)
            {
                _logger.LogError("CourseCreationDto object sent from client is null");
                return BadRequest("CourseCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var courseEntity = _mapper.Map<Course>(course);

            _repository.Course.CreateCourse(courseEntity);
            _repository.Save();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute("getCourseById", new { id = courseToReturn.Id }, courseToReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseUpdateDto course)
        {
            if (course == null)
            {
                _logger.LogError("CourseUpdateDto object sent from client is null.");
                return BadRequest("CourseUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var courseEntity = _repository.Course.GetCourse(id, trackChanges: true);
            if (courseEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(course, courseEntity);
            _repository.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            var course = _repository.Course.GetCourse(id, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Course.DeleteCourse(course);
            _repository.Save();

            return NoContent();
        }
    }
}