using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model.CourseSystem.Course;


namespace SIMS.Model.User
{
    public class Student : User
    {
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();

        public string Major { get; set; }

        public Student(int id, string name, string email, string major)
            : base(id, name, email)
        {
            Major = major;
        }
    }
}
