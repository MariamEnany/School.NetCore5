using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Repo
{
     public interface ISchoolRepository
    {
        IEnumerable<Subject> GetSubjects();
       // IEnumerable<Subject> GetSubjectsByAcdemicYear(Guid AcademicYearId);
        Subject GetSubject(Guid SubjectId);
        void AddSubject( Subject Subject);
       // void AddSubject(Guid AcademicYearId, Guid StudentId, Subject Subject);
        Subject UpdateSubject(Guid SubjectId,Subject Subject);
        void DeleteSubject(Subject Subject);


       
        IEnumerable<Student> GetStudents();
        //IEnumerable<Student> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        Student GetStudent(Guid StudentId);
        IEnumerable<Student> GetStudents(IEnumerable<Guid> StudentIds);
        void AddStudent(Student Student);
        void DeleteStudent(Student Student);
        Student UpdateStudent(Guid StudentId,Student Student);
        bool StudentExists(Guid StudentId);


        IEnumerable<AcademicYear> GetAcademicYears();
        //IEnumerable<AcademicYear> GetAcademicYearsBySubject(Subject Subject);
        AcademicYear GetAcademicYear(Guid AcdemicYearId);
       // AcademicYear GetAcademicYear(Guid StudentId, Guid SubjectId);
        void AddAcademicYear(AcademicYear AcademicYear);
       // void AddAcademicYear(Guid StudentId, Guid SubjectId, AcademicYear AcademicYear);
        AcademicYear UpdateAcademicYear(Guid AcdemicYearId,AcademicYear AcademicYear);
        void DeleteAcademicYear(AcademicYear AcademicYear);


        IEnumerable<Grade> GetGrades();
        IEnumerable<Grade> GetGradesOfOneSubject(Guid SubjectId);
        IEnumerable<Grade> GetGradesOfOneStudent(Guid StudentId);
        Grade GetGrade(Guid GradeId);
        Grade GetGrade(Guid StudentId,Guid SubjectId);
        void AddGrade(Grade Grade);
        Grade UpdateGrade(Guid GradeId,Grade Grade);
        void DeleteGrade(Grade Grade);
        IEnumerable<Grade> GetGradesBySubjectId(Guid SubjectId);


        bool Save();
    }
}
