using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
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
        private readonly SIMSDBContext _context;
        private readonly Service_User service_User;
        // Create constructor
        public Service_Student(IStudent student, SIMSDBContext _context, Service_User service_User)
        {
            _student = student;
            this._context = _context;
            this.service_User = service_User;
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
        public async Task AddStudentAsync(Student entity, User user)
        {
            int userId = await service_User.AddUserAsync(user);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.UserID = userId;
            _context.StudentsDb.Add(entity);
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
