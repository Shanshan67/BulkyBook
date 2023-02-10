using BulkyBookWeb.Data;
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
            var objCategoryList = _db.Categories.ToList();  
            return View();
        }
    }
}
