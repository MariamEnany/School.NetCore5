using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Repo.Interfaces;

namespace SchoolDemo.Repo.Classes
{
    public class SubjectsRepo : Repo<Subject>  , ISubjectsRepo
    {
        public SubjectsRepo(SchoolDemoDbContext context) : base(context)
        {
        }
    }
}
