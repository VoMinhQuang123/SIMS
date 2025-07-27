using System;
using System.Collections.Generic;
using SIMS.Model.CourseSystem.Course;
using SIMS.Model.User;

namespace SIMS.Service
{
    public class Service_Student
    {
        // Enroll a student in a course
        public void Enroll(Student student, Course course)
        {
            if (student == null || course == null)
                throw new ArgumentNullException("Student or Course cannot be null.");

            if (!student.EnrolledCourses.Contains(course))
            {
                student.EnrolledCourses.Add(course);
                Console.WriteLine($"✅ {student.Name} has enrolled in {course.Title}");
            }
            else
            {
                Console.WriteLine($"⚠️ {student.Name} is already enrolled in {course.Title}");
            }
        }

        // Unenroll a student from a course
        public void Unenroll(Student student, Course course)
        {
            if (student.EnrolledCourses.Contains(course))
            {
                student.EnrolledCourses.Remove(course);
                Console.WriteLine($"❌ {student.Name} has unenrolled from {course.Title}");
            }
            else
            {
                Console.WriteLine($"⚠️ {student.Name} is not enrolled in {course.Title}");
            }
        }

        // List all enrolled courses of a student
        public void ListEnrolledCourses(Student student)
        {
            Console.WriteLine($"\n📘 Courses enrolled by {student.Name}:");

            if (student.EnrolledCourses.Count == 0)
            {
                Console.WriteLine("No courses enrolled yet.");
                return;
            }

            foreach (var course in student.EnrolledCourses)
            {
                Console.WriteLine($"- {course.Title} ({course.Code})");
            }
        }
    }
}
