
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
    [Route("api/grades")]
    public class GradeController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public GradeController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
               
        }

        [HttpGet]
        public IEnumerable<Grade> GetGrades()
        {
            var GradesFromRepo = _schoolRepository.GetGrades();
            return GradesFromRepo;
        }

        // GET api/grades/5
        [HttpGet("{GradeId}", Name ="GetGrade")]
        public IActionResult GetGrade(Guid GradeId)
        {
            var GradeFromRepo = _schoolRepository.GetStudent(GradeId);

            if (GradeFromRepo == null)
            {
                return NotFound();
            }
             
            return Ok(GradeFromRepo);
        }

      

        [HttpPost]
        public ActionResult<Grade> CreateGrade([FromBody] Grade value)
        {
            _schoolRepository.AddGrade(value);
            _schoolRepository.Save();

            var GradeToReturn = _schoolRepository.GetGrade(value.Id);
            return Ok(GradeToReturn);
        }

        [HttpPut("{GradeId}")]
        public IActionResult  UpdateStudent(Guid GradeId, [FromBody] Grade value)
        {
            var grade = _schoolRepository.UpdateGrade(GradeId, value);
            return Ok(grade);

        }



        [HttpOptions]
        public IActionResult GetGradesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{GradeId}")]
        public ActionResult DeleteStudent(Guid GradeId)
        {
            var grade = _schoolRepository.GetGrade(GradeId);

            if (grade == null)
            {
                return NotFound();
            }

            _schoolRepository.DeleteGrade(grade);

            _schoolRepository.Save();

            return NoContent();
        }


       
        [HttpGet("subject/{SubjectId}", Name = "GetGradesBySubjectId")] 
        public IEnumerable<Grade> GetGradesBySubjectId(Guid SubjectID)
        {

            return _schoolRepository.GetGradesBySubjectId(SubjectID);
        }
    }
}
