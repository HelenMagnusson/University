using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Filters;
using University.Models.Entities;
using University.Models.ViewModels.Students;

namespace University.Controllers
{
    //[ModelIsValid]
    [NullRefferenseFilter]
    public class StudentsController : Controller
    {
        private readonly UniversityContext db;
        private readonly IMapper mapper;
        private readonly UserManager<Student> userManager;
        private readonly Faker faker;

        public StudentsController(UniversityContext context, IMapper mapper, UserManager<Student> userManager) 
        {
            db = context;
            this.mapper = mapper;
            this.userManager = userManager;
            faker = new Faker();
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {

            //var m = db.Student.Where(s => EF.Property<DateTime>(s, "Edited") >= DateTime.Now.AddDays(-1));

            //Student student = null;
            //var avatar = student.Avatar;
            //var model = _context.Student    //.Include(s => s.Adress)
            //                            .Select(s => new StudentsIndexViewModel
            //                            {
            //                                Id = s.Id,
            //                                Avatar = s.Avatar,
            //                                Fullname = s.FullName,
            //                                AdressStreet = s.Adress.Street
            //                            })
            //                            .OrderBy(m => m.AdressStreet)
            //                            .Take(10);

            var model = mapper.ProjectTo<StudentsIndexViewModel>(db.Student)
                              .OrderBy(m => m.AdressStreet)
                              .Take(10);


            return View(await model.ToListAsync());
        }

        // GET: Students/Details/5
        [RequiredParam("id")]
        [ModelNotNull]
        public async Task<IActionResult> Details(int? id)
        {
              

            //var student = await db.Student
            //    .FirstOrDefaultAsync(m => m.Id == id);
            
            var student = await mapper.ProjectTo<StudentsDetailsViewModel>(db.Student)
                                      .FirstOrDefaultAsync(m => m.Id == id);

            //student = null;

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelIsValid]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
          
                //var student = new Student
                //{
                //    Avatar = faker.Internet.Avatar(),
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Email = model.Email,
                //    Adress = new Adress
                //    {
                //        Street = model.Street,
                //        City = model.City,
                //        ZipCode = model.ZipCode
                //    }
                //};

                var student = mapper.Map<Student>(model);
                student.Avatar = faker.Internet.Avatar();
                student.UserName = model.Email;

                await userManager.CreateAsync(student, "bytmig");

                //db.Add(student);
                //await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Avatar,FirstName,LastName,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // db.Entry(student).Property("Edited").CurrentValue = DateTime.Now;
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.Student.FindAsync(id);
            db.Student.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return db.Student.Any(e => e.Id == id);
        }
    }
}
