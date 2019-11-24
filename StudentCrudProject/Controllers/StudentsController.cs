using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCrudProject.Models;
using StudentCrudProject.Services.StudentRepository;

namespace StudentCrudProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _studentRepository.GetAll());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
         
            return View(await _studentRepository.GetById(id));
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Average,RegisterDate,Age,Sex")] Student student)
        {

           await _studentRepository.Add(student);
                return RedirectToAction(nameof(Index));
            
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            return View(await _studentRepository.GetById(id));
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Average,RegisterDate,Age,Sex")] Student student)
        {
            await _studentRepository.Update(student);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            return View(await  _studentRepository.GetById(id));
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          await  _studentRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

     
    }
}
