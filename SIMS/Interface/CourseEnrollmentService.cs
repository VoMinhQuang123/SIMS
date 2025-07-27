using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model.CourseSystem.Course;
using SIMS.Model.User;

namespace SIMS.Interface
{
    public interface CourseEnrollmentService
    {
        void Enroll(Student student, Course course);
        void Unenroll(Student student, Course course);
        List<Course> GetEnrolledCourses(Student student);
    }
}
