using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wright.Models.CategoryModels;
using Wright.Services.CategoryServices;

namespace Wright.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoryIndex> categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            await _categoryService.CreateNewCategoryAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Details")]
        public async Task<IActionResult> CategoryDetails(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if(category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var category = await _categoryService.GetCategoryByIdForEditAsync(id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEdit model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var category = await _categoryService.EditCategoryAsync(model);
            if(!category)
            {
                ViewData["ErrorMsg"] = "Unable to save to the database. Please try again.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Details", new { id = model.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if(category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDetail model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            await _categoryService.DeleteCategoryAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}