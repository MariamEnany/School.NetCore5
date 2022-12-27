
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
    [Route("api/acdemicYear")]
    public class AcdemicYearController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;

        public AcdemicYearController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
               
        }

        [HttpGet]
        public IEnumerable<AcademicYear> GetAcademicYears()
        {
            var AcademicYearsFromRepo = _schoolRepository.GetAcademicYears();
            return AcademicYearsFromRepo;
        }

        // GET api/students/5
        [HttpGet("{AcademicYearId}", Name = "GetAcademicYear")]
        public IActionResult GetAcademicYear(Guid AcademicYearId)
        {
            var AcademicYearFromRepo = _schoolRepository.GetAcademicYear(AcademicYearId);

            if (AcademicYearFromRepo == null)
            {
                return NotFound();
            }
             
            return Ok(AcademicYearFromRepo);
        }

        [HttpPost]
        public ActionResult<AcademicYear> CreateStudent([FromBody] AcademicYear value)
        {
            _schoolRepository.AddAcademicYear(value);
            _schoolRepository.Save();

            var AcademicYearToReturn = _schoolRepository.GetAcademicYear(value.Id);
            return CreatedAtRoute("GetStudent", new { studentId = AcademicYearToReturn.Id }, AcademicYearToReturn);
        }

        [HttpPut("{studentId}")]
        public IActionResult UpdateAcademicYearToReturn(Guid AcademicYearID, [FromBody] AcademicYear value)
        {
            var AcademicYear = _schoolRepository.UpdateAcademicYear(AcademicYearID, value);
            return Ok(AcademicYear);

        }



        [HttpOptions]
        public IActionResult GetAcademicYearsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{AcademicYearId}")]
        public ActionResult DeleteStudent(Guid AcademicYearId)
        {
            var AcademicYear = _schoolRepository.GetAcademicYear(AcademicYearId);

            if (AcademicYear == null)
            {
                return NotFound();
            }

            _schoolRepository.DeleteAcademicYear(AcademicYear);

            _schoolRepository.Save();

            return NoContent();
        }
    }
}
