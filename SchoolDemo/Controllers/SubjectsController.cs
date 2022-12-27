
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
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public SubjectsController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
               
        }

        [HttpGet]
        public IEnumerable<Subject> GetSubjects()
        {
            var Subjects = _schoolRepository.GetSubjects();
            return Subjects;
        }

        // GET api/students/5
        [HttpGet("{studentId}", Name ="GetSubject")]
        public IActionResult GetSubject(Guid SubjectId)
        {
            var subjectFromRepo = _schoolRepository.GetSubject(SubjectId);

            if (subjectFromRepo == null)
            {
                return NotFound();
            }
             
            return Ok(subjectFromRepo);
        }


        [HttpPost]
        public ActionResult<Subject> CreateSubject([FromBody] Subject value)
        {
            _schoolRepository.AddSubject(value);
            _schoolRepository.Save();

            var subjectToReturn = _schoolRepository.GetSubject(value.Id);
            return CreatedAtRoute("GetSubject", new { studentId = subjectToReturn.Id }, subjectToReturn);
        }

        [HttpPut("{studentId}")]
        public IActionResult  UpdateSubject(Guid SubjectID, [FromBody] Subject value)
        {
            var student = _schoolRepository.UpdateSubject(SubjectID, value);
            return Ok(student);

        }



        [HttpOptions]
        public IActionResult GetSubjectOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{SubjectId}")]
        public ActionResult DeleteStudent(Guid SubjectId)
        {
            var subject = _schoolRepository.GetSubject(SubjectId);

            if (subject == null)
            {
                return NotFound();
            }

            _schoolRepository.DeleteSubject(subject);

            _schoolRepository.Save();

            return NoContent();
        }
    }
}
