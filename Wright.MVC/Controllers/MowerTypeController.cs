using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wright.Models.MowerTypeModels;
using Wright.Services.MowerTypeServices;

namespace Wright.MVC.Controllers
{
    public class MowerTypeController : Controller
    {
        private readonly ILogger<MowerTypeController> _logger;
        private readonly IMowerTypeService _mowerTypeService;

        public MowerTypeController(ILogger<MowerTypeController> logger, IMowerTypeService mowerTypeService)
        {
            _logger = logger;
            _mowerTypeService = mowerTypeService;
        }

        public async Task<IActionResult> Index()
        {
            List<MowerTypeIndex> mowerTypes = await _mowerTypeService.GetAllMowerTypesAsync();

            return View(mowerTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MowerTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            await _mowerTypeService.CreateNewMowerTypeAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Details")]
        public async Task<IActionResult> MowerTypeDetails(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var mowerType = await _mowerTypeService.GetMowerTypeByIdAsync(id);
            if(mowerType == null)
                return RedirectToAction(nameof(Index));
            return View(mowerType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var mowerType = await _mowerTypeService.GetMowerTypeByIdForEditAsync(id);
            if (mowerType == null)
                return RedirectToAction(nameof(Index));
            return View(mowerType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MowerTypeEdit model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var mowerType = await _mowerTypeService.EditMowerTypeAsync(model);
            if(!mowerType)
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
            var mowerType = await _mowerTypeService.GetMowerTypeByIdAsync(id);
            if(mowerType == null)
                return RedirectToAction(nameof(Index));
            return View(mowerType);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MowerTypeDetail model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            await _mowerTypeService.DeleteMowerTypeAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}