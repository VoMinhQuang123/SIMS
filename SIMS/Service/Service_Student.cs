using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;


namespace SIMS.Service
{
    public class Service_Student
    {
        // Inheriting interfaces
        private readonly IStudent _student;

        // Create constructor
        public Service_Student(IStudent student)
        {
            _student = student;
        }

        // Get all Students
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _student!.GetAllStudentsAsync();
        }

        // Get information Student by ID
        public async Task<Student?> GetStudentByIDAsync(int id)
        {
            return await _student.GetStudentByIDAsync(id);
        }

        // Add new Student 
        public async Task AddStudentAsync(Student entity)
        {
            await _student.AddStudentAsync(entity);
        }

        // Update information Student
        public async Task UpdateStudentAsync(Student entity)
        {
            await _student.UpdateStudentAsync(entity);
        }

        // Delete Student by ID
        public async Task DeleteStudentAsync(int id)
        {
            await _student.DeleteStudentAsync(id);
        }
    }
}
