using Microsoft.EntityFrameworkCore;
using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Data
{
    public class SchoolDemoDbContext : DbContext
    {
        public SchoolDemoDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Berry",
                    LastName = "Griffin Beak Eldritch",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    Email = "Ships",
                    AcademicYearId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                },
                new Student()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Nancy",
                    LastName = "Swashbuckler Rye",
                    DateOfBirth = new DateTime(1668, 5, 21),
                    Email = "Rum",
                    AcademicYearId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                }
                );

            modelBuilder.Entity<Subject>().HasData(
               new Subject
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   Name = "Physics"
               },
               new Subject
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   Name = "Math"
               },
               new Subject
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   Name = "English",
               }
               );

            modelBuilder.Entity<AcademicYear>().HasData(
             new AcademicYear
             {
                 Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
             },
             new AcademicYear
             {
                 Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
             },
             new AcademicYear
             {
                 Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
             }
             );

            modelBuilder.Entity<Grade>().HasData(
            new Grade
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                SubjectId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                Marks = 100

            },
            new Grade
            {
                Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                StudentId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                SubjectId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                Marks = 80
            }
            );



            base.OnModelCreating(modelBuilder);
        }







    }
}
