using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;//dbContext
        public CategoryController(ApplicationDbContext db)//tell application that we need an implementation of this application dbcontext where the connection to database is already made.
        {
            _db= db;
        }  
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;//have all the categories inside this object and then pass that to view(var .ToList()used in Index.cshtml) 
            return View(objCategoryList);
        }
        //create get
        public IActionResult Create()
        {
            return View();
        }

        //create post
        [HttpPost]
        [ValidateAntiForgeryToken]//prevent the cross site request forgery attack
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The DisplayOrder cannot exactly match the Name.");//("Key","Value")
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);   
        }

        //edit get
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //edit post
        [HttpPost]
        [ValidateAntiForgeryToken]//prevent the cross site request forgery attack
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");//("Key","Value")
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //delete get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //delete post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]//prevent the cross site request forgery attack
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
