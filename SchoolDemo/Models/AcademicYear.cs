using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
    public class AcademicYear
    {
        [Key]
        public Guid Id { get; set; }

        public ICollection<Student> Students { get; set; }
           = new List<Student>();

        public ICollection<Subject> Subjects { get; set; }
          = new List<Subject>();


    }
}
