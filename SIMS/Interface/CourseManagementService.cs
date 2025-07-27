using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model.CourseSystem.Course;

namespace SIMS.Interface
{
    public interface CourseManagementService
    {
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(string courseCode);
    }
}
