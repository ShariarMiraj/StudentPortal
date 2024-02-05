using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Repo.Abstract;

namespace StudentPortal.Web.Controllers
{
    public class GenraController : Controller
    {
        private readonly IGenreService service;

        public GenraController(IGenreService service)
        {
            this.service = service;
        }

      
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre viewModle)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModle);
            }

            var result = service.Add(viewModle);
            if(result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }

            TempData["msg"] = "Errror";
            return View(viewModle);
        }



        public IActionResult Update(int id)
        {
            var recode = service.FindById(id);
            return View(recode);
        }

        [HttpPost]
        public IActionResult Update(Genre viewModle)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModle);
            }

            var result = service.Update(viewModle);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Update));
            }

            TempData["msg"] = "Errror";
            return View(viewModle);
        }


        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
      
            return RedirectToAction("GetAll");
         

        }


        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);

         ;


        }
    }
}
