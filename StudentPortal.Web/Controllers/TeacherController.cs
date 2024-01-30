using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TeacherController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeacherViewModel viewModel)
        {
            var teacher = new Teacher
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
            };

            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
             var teacher =await dbContext.Teachers.ToListAsync();

            return View(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var teacher = await dbContext.Teachers.FindAsync(id);

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(Teacher viewModel)
        {
           var teacher = await dbContext.Teachers.FindAsync(viewModel.Id);

            if (teacher is not  null) 
            {
                teacher.Name = viewModel.Name;
                teacher.Category = viewModel.Category;
                teacher.Phone = viewModel.Phone;
                teacher.Email = viewModel.Email;



                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", ("Teacher"));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Teacher viewModel)
        {
            var teacher = await dbContext.Teachers.FindAsync(viewModel.Id);

            if (teacher is not null) 
            {
                dbContext.Teachers.Remove(teacher);

                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", ("Teacher"));
        }
    }
}
