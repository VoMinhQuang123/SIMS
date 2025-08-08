using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class Service_Teacher
    {
        private readonly SIMSDBContext _context;
        private readonly Service_User service_User;
        private readonly ITeacher _teacher;

        // Create constructor
        public Service_Teacher(ITeacher teacher, SIMSDBContext _context, Service_User service_User)
        {
            _teacher = teacher;
            this._context = _context;
            this.service_User = service_User;
        }

        // Get all Teachers
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _teacher!.GetAllTeacheresAsync();
        }

        // Get information Teacher by ID
        public async Task<Teacher?> GetTeacherByIDAsync(int id)
        {
            return await _teacher.GetTeacherByIDAsync(id);
        }

        // Add new Teacher 
        public async Task AddTeacherAsync(Teacher entity, User user)
        {
            int userId = await service_User.AddUserAsync(user);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.UserID = userId;
            _context.TeachersDb.Add(entity);
            await _teacher.AddTeacherAsync(entity);
        }

        // Update information Teacher
        public async Task UpdateTeacherAsync(Teacher entity)
        {

            await _teacher.UpdateTeacherAsync(entity);
        }

        // Delete Teacher by ID
        public async Task DeleteTeacherAsync(int id)
        {
            await _teacher.DeleteTeacherAsync(id);
        }
    }
}
