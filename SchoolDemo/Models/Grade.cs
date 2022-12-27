using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
    public class Grade
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("StudentId")]
        public Guid StudentId { get; set; }
       
        public Student Student { get; set; }

        [ForeignKey("SubjectId")]
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Range(0, 100)]
        public int Marks { get; set; }
    }
}
