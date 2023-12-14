using HorizonHotel.Domain.Entities;
using HorizonHotel.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HorizonHotel.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj) 
        {
            if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The Name cannot be the same as description");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Villa Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Update(int villaId)
        {
            // Method 1 to fetch data based on villa ID
            Villa? obj = _db.Villas.Find(villaId);

            // Method 2 to fetch data based on villa ID
            // Villa? obj = _db.Villas.FirstOrDefault( u=> u.Id == villaId);

            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Villa Updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.Find(villaId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "Villa Deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Villa Could Not Be Deleted";
            return View();
        }
    }
}
