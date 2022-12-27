using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Repo.Interfaces;

namespace SchoolDemo.Repo.Classes
{
    public class StudentsRepo : Repo<Student>,IStudentsRepo
    {
        public StudentsRepo(SchoolDemoDbContext context) : base(context)
        {
        }

        public bool StudentExists(Guid StudentId)
        {
            if (StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(StudentId));
            }
            return context.Students.Any(a => a.Id == StudentId);
        }
    }
}
