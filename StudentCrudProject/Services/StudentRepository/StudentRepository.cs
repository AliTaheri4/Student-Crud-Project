using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCrudProject.Models;

namespace StudentCrudProject.Services.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
          private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
              _context = context;
        }

        /// <summary>
        /// get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Student>> GetAll()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student> GetById(int id)
        {
            try
            {

                  return await _context.Students.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// insert student
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> Add(Student model)
        {
            try
            {

                await _context.Students.AddAsync(model);
                await SaveChange();
                return model.Id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// update student
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Student model)
        {
            try
            {

                var student = await _context.Students.SingleOrDefaultAsync(p => p.Id == model.Id);
                if (student != null)
                {
                    #region Update fields
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;
                    student.Average = model.Average;
                    student.RegisterDate = model.RegisterDate;
                    student.Sex = model.Sex;
                    student.Age = model.Age;
                }
                #endregion
                var result=await SaveChange();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// delete student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            try
            {

                 var student = await _context.Students.FirstOrDefaultAsync(p => p.Id == id);
              
                if (student != null)
                {
                   var result= await SaveChange();
                    return result;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// UOW !
        /// </summary>
        public async Task<bool> SaveChange(bool isTrue=true)
        {
            try
            {
                if (isTrue)
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
