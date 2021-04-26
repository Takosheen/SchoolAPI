using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Contracts;
using AutoMapper;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllStudents")]
        public IActionResult GetStudents()
        {
            var students = _repository.Student.GetAllStudents(trackChanges: false);

            var userDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            //uncomment the code below to test the global exception handling
            //throw new Exception("Exception");
            return Ok(userDto);
        }

        [HttpGet("{id}", Name = "getStudentById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _repository.Student.GetStudent(id, trackChanges: false); if (user == null)
            {
                _logger.LogInfo($"Student with id: {id} does not exist in the database.");
                return NotFound();
            }
            else
            {
                var studentDto = _mapper.Map<StudentDto>(user);
                return Ok(studentDto);
            }
        }
    }
}