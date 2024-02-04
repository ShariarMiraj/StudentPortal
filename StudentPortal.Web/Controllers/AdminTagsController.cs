using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Domain;

namespace StudentPortal.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AdminTagsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest viewModel)
        {
            var tag = new Tag
            {
                Name = viewModel.Name,
                DisplayName = viewModel.DisplayName,
            };
            
            dbContext.Tags.Add(tag);

            dbContext.SaveChanges();

            return View();
        }


    }
}
