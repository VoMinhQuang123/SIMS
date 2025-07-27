using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Interface;
using SIMS.Model.CourseSystem.Course;

namespace SIMS.Service
{
    public class Service_Management_Course : CourseManagementService
    {
        private List<Course> _courseList = new();

        public void AddCourse(Course course) => _courseList.Add(course);
        public void UpdateCourse(Course course) { /* update logic */ }
        public void DeleteCourse(string courseCode) =>
            _courseList.RemoveAll(c => c.Code == courseCode);
    }
}
