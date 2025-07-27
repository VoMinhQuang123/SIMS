using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Interface;
using SIMS.Model.CourseSystem.Course;
using SIMS.Model.User;

namespace SIMS.Service
{
    public class Service_Enroll_Course : CourseEnrollmentService
    {
        public void Enroll(Student student, Course course)
        {
            if (!student.EnrolledCourses.Contains(course))
            {
                student.EnrolledCourses.Add(course);
            }
        }

        public void Unenroll(Student student, Course course)
        {
            student.EnrolledCourses.Remove(course);
        }

        public List<Course> GetEnrolledCourses(Student student)
        {
            return student.EnrolledCourses;
        }
    }
}
