using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Repo.Interfaces;
using SchoolDemo.Data;

namespace SchoolDemo.Repo.Classes
{
    public class AcademicYearsRepo : Repo<AcademicYear>,IAcdemicYearRepo
    {
        public AcademicYearsRepo (SchoolDemoDbContext context) : base(context)
        {
        }

    }
}
