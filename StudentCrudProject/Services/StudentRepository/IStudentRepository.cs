using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentCrudProject.Models;

namespace StudentCrudProject.Services.StudentRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();

        Task<Student> GetById(int id);
        Task<int> Add(Student model);
        Task<bool> Update(Student model);
        Task<bool> Delete(int id);
        Task<bool> SaveChange(bool isTrue = true);

    }
}
