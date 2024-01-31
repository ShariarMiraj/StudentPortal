using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class FeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Add(AddFeeViewModel viewModel)
        {
            var fee = new Fee
            {
                CourseID = viewModel.CourseID,
                FeeType = viewModel.FeeType,
                Amount = viewModel.Amount,
                LateFee = viewModel.LateFee,
                PaymentDate = viewModel.PaymentDate,
            };

            await dbContext.fees.AddAsync(fee);
            await dbContext.SaveChangesAsync();
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var fee = await dbContext.fees.ToListAsync();
           return View(fee);
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fee =await dbContext.fees.FindAsync(id);
            return View(fee);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Fee viewModel)
        {
            var fee = await dbContext.fees.FindAsync(viewModel.FeeId);

            if (fee is not null) 
            {
                
                fee.CourseID = viewModel.CourseID;
                fee.FeeType = viewModel.FeeType;
                fee.Amount = viewModel.Amount;
                fee.LateFee = viewModel.LateFee;
                fee.PaymentDate = viewModel.PaymentDate;


                await dbContext.SaveChangesAsync();

            }

            return RedirectToAction("List", "Fee");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Fee viewModel)
        {
            var fee = await dbContext.fees.FindAsync(viewModel.FeeId);

            if (fee is not null)
            {
                dbContext.fees.Remove(fee);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Fee");

        }
    }
}
