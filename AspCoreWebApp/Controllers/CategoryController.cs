using AspCoreWebApp.DB;
using AspCoreWebApp.Entity;
using AspCoreWebApp.MiddleWares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.Controllers
{
    
    
    public class CategoryController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(DataContext dataContext, ILogger<CategoryController> logger)
        {
            this.dataContext = dataContext;
            this.logger = logger;
        }
        
        [MyCustomActionFilter]
        public IActionResult Index()
        {
            logger.LogInformation("The Index() action method has been executed");
            var categories = dataContext.GetCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            var category = new Category();
            var maxId = dataContext.GetCategories().Count + 1;
            category.Id = maxId;
            return View(category);
        }


        
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                this.dataContext.Categories.Add(category);
                this.dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
            
        }
    }
}
