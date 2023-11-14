 using System;
using Microsoft.AspNetCore.Mvc;
using TheFirst.Controllers.Data;
using TheFirst.Models;

namespace TheFirst.Controllers
{
	public class CategoryController : Controller
	{

		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Category> objCategoryList = _db.Categories;
			
			return View(objCategoryList);

		}

		//Get
        public IActionResult Create()
        {
          
            return View();

        }

		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{

			if(obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "Your name and displayOrder cannot be the same");
			}
			if(ModelState.IsValid)
			{
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

			return View(obj);
		}
    }
}

