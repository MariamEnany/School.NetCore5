using SchoolDemo.Data;
using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace SchoolDemo.Repo
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDemoDbContext context;

        public SchoolRepository( SchoolDemoDbContext context)
        {
            this.context = context;
        }

        public void AddAcademicYear(AcademicYear AcademicYear)
        {
            if (AcademicYear == null)
            {
                throw new ArgumentNullException(nameof(AcademicYear));
            }

            // the repository fills the id (instead of using identity columns)
            AcademicYear.Id = Guid.NewGuid();
            context.AcademicYears.Add(AcademicYear);
        }


        public void AddGrade(Grade Grade)
        {
            if (Grade == null)
            {
                throw new ArgumentNullException(nameof(Grade));
            }

            // the repository fills the id (instead of using identity columns)
            Grade.Id = Guid.NewGuid();
            context.Grades.Add(Grade);
        }

        public void AddStudent(Student Student)
        {
            if (Student == null)
            {
                throw new ArgumentNullException(nameof(Student));
            }

            // the repository fills the id (instead of using identity columns)
            Student.Id = Guid.NewGuid();
            if (Student.AcademicYearId == null)
            {
                Student.AcademicYearId = Guid.NewGuid();
            }
          
            context.Students.Add(Student);
        }

        public void AddSubject(Subject Subject)
        {
            if (Subject == null)
            {
                throw new ArgumentNullException(nameof(Subject));
            }

            // the repository fills the id (instead of using identity columns)
            Subject.Id = Guid.NewGuid();

            foreach (var academicYear in Subject.AcademicYears)
            {
                if (academicYear.Id == null) { academicYear.Id = Guid.NewGuid(); }
               

            }


            context.Subjects.Add(Subject);
        }

        public void DeleteAcademicYear(AcademicYear AcademicYear)
        {
            if (AcademicYear == null)
            {
                throw new ArgumentNullException(nameof(AcademicYear));
            }

            context.AcademicYears.Remove(AcademicYear);
        }

        public void DeleteGrade(Grade Grade)
        {
            if (Grade == null)
            {
                throw new ArgumentNullException(nameof(Grade));
            }

            context.Grades.Remove(Grade);
        }

        public void DeleteStudent(Student Student)
        {
            if (Student == null)
            {
                throw new ArgumentNullException(nameof(Student));
            }

            context.Students.Remove(Student);
        }

        public void DeleteSubject(Subject Subject)
        {
            if (Subject == null)
            {
                throw new ArgumentNullException(nameof(Subject));
            }

            context.Subjects.Remove(Subject);
        }

        public AcademicYear GetAcademicYear(Guid AcdemicYearrId)
        {
            if (AcdemicYearrId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(AcdemicYearrId));
            }

            return context.AcademicYears.FirstOrDefault(a => a.Id == AcdemicYearrId);
        }


        public IEnumerable<AcademicYear> GetAcademicYears()
        {
            return context.AcademicYears.ToList<AcademicYear>();
        }

        public Grade GetGrade(Guid GradeId)
        {
            if (GradeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(GradeId));
            }

            return context.Grades.FirstOrDefault(a => a.Id == GradeId);

        }

        public IEnumerable<Grade> GetGradesBySubjectId(Guid SubjectId)
        {
            if (SubjectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(SubjectId));
            }

            var grades = context.Grades.Include().Where(a => a.Subject.Id == SubjectId).OrderByDescending(a => a.Marks).ToList();

            List<Student> students = new List<Student>();

            foreach (var grade in grades)
            {
                students.Add(grade.Student);
            }
            return grades;

        }


        public Grade GetGrade(Guid StudentId, Guid SubjectId)
        {
            if (StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(StudentId));
            }

            if (SubjectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(SubjectId));
            }

            return context.Grades.FirstOrDefault(a => a.Student.Id==StudentId && a.Subject.Id==SubjectId);



        }

        public IEnumerable<Grade> GetGrades()
        {
            return context.Grades.Include(g => g.Student).Include(g => g.Subject).ToList();
        }

        public IEnumerable<Grade> GetGradesOfOneStudent(Guid StudentId)
        {
            if (StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(StudentId));
            }

            return context.Grades
                        .Where(c => c.Student.Id==StudentId)
                        .OrderBy(c => c.Marks).ToList();
        }

        public IEnumerable<Grade> GetGradesOfOneSubject(Guid SubjectId)
        {
            if (SubjectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(SubjectId));
            }

            return context.Grades
                        .Where(c => c.Subject.Id == SubjectId)
                        .OrderBy(c => c.Marks).ToList();
        }

        public Student GetStudent(Guid StudentId)
        {
            if (StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(StudentId));
            }

            return context.Students.FirstOrDefault(a => a.Id == StudentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList<Student>();
        }

        public IEnumerable<Student> GetStudents(IEnumerable<Guid> StudentIds)
        {
            if (StudentIds == null)
            {
                throw new ArgumentNullException(nameof(StudentIds));
            }

            return context.Students.Where(a => StudentIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public Subject GetSubject(Guid SubjectId)
        {
            if (SubjectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(SubjectId));
            }

            return context.Subjects.FirstOrDefault(a => a.Id == SubjectId);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects.ToList<Subject>();
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }

        public bool StudentExists(Guid StudentId)
        {
            if (StudentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(StudentId));
            }
            return context.Students.Any(a => a.Id == StudentId);

        }

        public AcademicYear UpdateAcademicYear(Guid AcdemicYearId,AcademicYear AcademicYear)
        {
            var _acdemicYear = context.AcademicYears.FirstOrDefault(n => n.Id == AcdemicYearId);
            if (_acdemicYear != null)
            {
                _acdemicYear.Students = AcademicYear.Students;
                _acdemicYear.Subjects = AcademicYear.Subjects;
                context.SaveChanges();
            }

            return _acdemicYear;

        }

        public Grade UpdateGrade(Guid GradeId,Grade Grade)
        {
            var _Grade = context.Grades.FirstOrDefault(n => n.Id == GradeId);
            if (_Grade != null)
            {
                _Grade.Student = Grade.Student;
                _Grade.Subject = Grade.Subject;
                context.SaveChanges();
            }

            return _Grade;
        }

        public Student UpdateStudent(Guid StudentId, Student Student)
        {
            var _student = context.Students.FirstOrDefault(n => n.Id == StudentId);
            if (_student != null)
            {
                _student.FirstName = Student.FirstName;
                _student.LastName = Student.LastName;
                _student.Email = Student.Email;
                _student.DateOfBirth = Student.DateOfBirth;
                _student.AcademicYearId = Student.AcademicYearId;
                _student.AcademicYear = Student.AcademicYear;
                context.SaveChanges();
            }
            return _student;
        }

        public Subject UpdateSubject(Guid subjectId,Subject Subject)
        {
            var _Subject = context.Subjects.FirstOrDefault(n => n.Id == subjectId);
            if (_Subject != null)
            {
                _Subject.Name = Subject.Name;
                _Subject.AcademicYears = Subject.AcademicYears;
                context.SaveChanges();
            }
            return _Subject;
        }

       
    }
}
