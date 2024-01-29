using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class DiscussionForumController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DiscussionForumController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDiscussionForumViewModel viewModel)
        {
            var discussionForum = new DiscussionForum
            {

                ForumName = viewModel.ForumName,
                Description = viewModel.Description,
                DateTime = viewModel.DateTime,
                Creator = viewModel.Creator,

            };

            await dbContext.DiscussionForums.AddAsync(discussionForum);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var discussionForum = await dbContext.DiscussionForums.ToListAsync();

            return View(discussionForum);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var discussionForum = await dbContext.DiscussionForums.FindAsync(id);

            return View(discussionForum);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DiscussionForum viewModel)
        {
            var discussionForum = await dbContext.DiscussionForums.FindAsync(viewModel.ForumID);

            if (discussionForum is not null)
            {

                discussionForum.ForumName = viewModel.ForumName;
                discussionForum.Description = viewModel.Description;
                discussionForum.DateTime = viewModel.DateTime;
                discussionForum.Creator = viewModel.Creator;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "DiscussionForum");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DiscussionForum viewModel)
        {
            var discussionForum = await dbContext.DiscussionForums.FindAsync(viewModel.ForumID);

            if (discussionForum is not null)
            {
                dbContext.DiscussionForums.Remove(discussionForum);

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "DiscussionForum");

        }
    }
}
