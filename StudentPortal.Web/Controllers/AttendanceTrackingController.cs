using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Migrations;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class AttendanceTrackingController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AttendanceTrackingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  async  Task<IActionResult> Add(AttendanceTrackingViewModel viewModel)
        {

            var attendanceTracking = new AttendanceTracking
            {
                Session = viewModel.Session,
                StudentID = viewModel.StudentID,
                Timestamp = viewModel.Timestamp,
                LateArrivalTime = viewModel.LateArrivalTime,


            };

            await dbContext.AttendanceTrackings.AddAsync(attendanceTracking);
            await dbContext.SaveChangesAsync();

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {

            var attendanceTracking =  await dbContext.AttendanceTrackings.ToListAsync();

            return View(attendanceTracking);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var attendanceTracking = await dbContext.AttendanceTrackings.FindAsync(id);

            return View(attendanceTracking);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(AttendanceTrackingViewModel viewModel)
        {
            var attendanceTracking= await dbContext.AttendanceTrackings.FindAsync(viewModel.AttendanceID);

            if(attendanceTracking is not null)
            {
                attendanceTracking.Session = viewModel.Session;
                attendanceTracking.StudentID = viewModel.StudentID;
                attendanceTracking.Timestamp = viewModel.Timestamp;
                attendanceTracking.LateArrivalTime = viewModel.LateArrivalTime;

                await dbContext.SaveChangesAsync();
            };

            return RedirectToAction("List", "AttendanceTracking");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AttendanceTrackingViewModel viewModel)
        {
            var attendanceTracking = await dbContext.AttendanceTrackings.FindAsync(viewModel.AttendanceID);

            if (attendanceTracking is not null) 
            {
                dbContext.AttendanceTrackings.Remove(attendanceTracking);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "AttendanceTracking");
        }


    }       
}
