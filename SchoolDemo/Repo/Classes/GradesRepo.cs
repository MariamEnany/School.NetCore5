using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Repo.Interfaces;

namespace SchoolDemo.Repo.Classes
{
    public class GradesRepo : Repo<Grade> , IGradesRepo
    {
        public GradesRepo(SchoolDemoDbContext context) : base(context)
        {
        }
    }
}
