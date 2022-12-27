using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Models;

namespace SchoolDemo.Repo.Interfaces
{
    interface IStudentsRepo : IRepo<Student>
    {
       
        bool StudentExists(Guid StudentId);
    }
}
