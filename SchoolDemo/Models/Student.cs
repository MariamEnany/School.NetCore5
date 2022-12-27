using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public DateTimeOffset DateOfBirth { get; set; }


        [ForeignKey("AcademicYearId")]

        public AcademicYear AcademicYear;

        public Guid AcademicYearId { get; set; }




    }
}
