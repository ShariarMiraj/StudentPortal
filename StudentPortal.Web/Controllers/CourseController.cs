using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            var course = new Course
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CreatedDate = viewModel.CreatedDate,
                Department = viewModel.Department,
                EnrolledStudents = viewModel.EnrolledStudents,


            };
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var course = await dbContext.Courses.ToListAsync();

            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id )
        {
           var course = await dbContext.Courses.FindAsync(id);
           
           return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course  viewModel)
        {
            var course = await dbContext.Courses.FindAsync(viewModel.Id);

            if ( course is not null ) 
            {
                course.Name = viewModel.Name;
                course.Description = viewModel.Description;
                course.CreatedDate = viewModel.CreatedDate;
                course.Department = viewModel.Department;
                course.EnrolledStudents = viewModel.EnrolledStudents;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List" , "Course");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Course viewModel)
        {
            var course = await dbContext.Courses.FindAsync(viewModel.Id);

            if (course is not null)
            {
                dbContext.Courses.Remove(course);

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Course");
        }

    }
}
