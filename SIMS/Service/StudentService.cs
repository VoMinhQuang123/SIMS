using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;


namespace SIMS.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
    }
}
