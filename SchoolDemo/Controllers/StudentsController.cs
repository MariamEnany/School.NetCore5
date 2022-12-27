
using SchoolDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Repo;

namespace SchoolDemo.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public StudentsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
               
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var StudentsFromRepo = _schoolRepository.GetStudents();
            return StudentsFromRepo;
        }

        // GET api/students/5
        [HttpGet("{studentId}", Name ="GetStudent")]
        public IActionResult GetStudent(Guid studentId)
        {
            var authorFromRepo = _schoolRepository.GetStudent(studentId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }
             
            return Ok(authorFromRepo);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student value)
        {
            _schoolRepository.AddStudent(value);
            _schoolRepository.Save();

            var authorToReturn = _schoolRepository.GetStudent(value.Id);
            return CreatedAtRoute("GetStudent", new { studentId = authorToReturn.Id },authorToReturn);
        }

        [HttpPut("{studentId}")]
        public IActionResult  UpdateStudent(Guid StudentId, [FromBody] Student value)
        {
            var student = _schoolRepository.UpdateStudent(StudentId, value);
            return Ok(student);

        }



        [HttpOptions]
        public IActionResult GetStudentsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(Guid StudentId)
        {
            var student = _schoolRepository.GetStudent(StudentId);

            if (student == null)
            {
                return NotFound();
            }

            _schoolRepository.DeleteStudent(student);

            _schoolRepository.Save();

            return NoContent();
        }
    }
}
