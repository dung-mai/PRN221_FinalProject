using AcademicGradeManagementApp.Util;
using AcademicGradeManagementApp.Utils;
using Business.IRepository;
using Bussiness.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Assignment2.Extensions;

namespace AcademicGradeManagementApp.Pages.Grade
{
    public class StudentGradeModel : PageModelBase
    {
        private IStudentRepository _studentRepository;
        private IStudyCourseRepository _studyCourseRepository;
        private IGradeComponentRepository _gradeComponentRepository;
        public StudentDTO? Student { get; set; }
        public List<StudyCourseDTO> SemesterCourse { get; set; } = new List<StudyCourseDTO>();
        public StudyCourseDTO? CurrentCourse { get; set; }
        public List<GradeComponentDTO> GradeComponents { get; set; } = new List<GradeComponentDTO>();
        public List<SemesterDTO>? Semesters { get; set; } = new List<SemesterDTO>();
        public int? TermId { get; set; }

        public StudentGradeModel(IStudentRepository studentRepository, IStudyCourseRepository studyCourseRepository, IGradeComponentRepository _gradeComponentRepository)
        {
            _studentRepository = studentRepository;
            _studyCourseRepository = studyCourseRepository;
            this._gradeComponentRepository = _gradeComponentRepository;
            authorizedRoles = new string[] { "student", "teacher", "TMO" };
        }

        public IActionResult OnGet(int? term, int? courseId, string? rollNumber)
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            //IF rollnumber emtyp => Student LOGGIN
            if (String.IsNullOrEmpty(rollNumber))
            {
                if (LoggedInAccount.Role.RoleName.Equals(Constants.STUDENT_ROLE))
                {
                    Student = _studentRepository.GetStudentWithGradeResults(LoggedInAccount.Id);
                    Semesters = Student?.GetSemesters();

                    //IF term is not select
                    if (term.HasValue)
                    {
                        TermId = (int)term;
                        SemesterCourse = _studyCourseRepository.GetStudyCourseOfStudentBySemester((int)term, Student.Rollnumber);

                        //IF COURSE IS NOT SELECTED
                        if (courseId.HasValue)
                        {
                            CurrentCourse = _studyCourseRepository.GetStudyCourseBySubject(term, Student.Rollnumber, courseId);
                            GradeComponents = _gradeComponentRepository.GetGradeComponentsOfSubjetWithStudentResult(CurrentCourse.SubjectOfClass.SubjectId, CurrentCourse.Id);
                        }
                    } else
                    {
                        SemesterCourse = _studyCourseRepository.GetStudyCourseOfStudentBySemester(Semesters[Semesters.Count - 1].Id, Student.Rollnumber);
                    }
                }
                else
                {
                    return LoginBasedFeatureRedirect();
                }

            }

            return Page();
        }


        private void GetCourseOfSemester(int semesterId)
        {
            //return Student.StudyCourses.Where(course => course.SubjectOfClass.SemesterId == );
        }
    }
}
