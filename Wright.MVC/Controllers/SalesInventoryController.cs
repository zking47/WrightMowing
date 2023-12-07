using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wright.Models.SalesInventoryModels;
using Wright.Services.SalesInventoryServices;

namespace Wright.MVC.Controllers
{
    public class SalesInventoryController : Controller
    {
        private readonly ILogger<SalesInventoryController> _logger;
        private readonly ISalesInventoryService _salesInventoryService;

        public SalesInventoryController(ILogger<SalesInventoryController> logger, ISalesInventoryService salesInventoryService)
        {
            _logger = logger;
            _salesInventoryService = salesInventoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<SalesInvIndex> SalesInventoryEnitities = await _salesInventoryService.GetAllSalesInventoriesAsync();

            return View(SalesInventoryEnitities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesInvCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            await _salesInventoryService.CreateNewSalesInventoryAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Details")]
        public async Task<IActionResult> ListingDetails(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var salesInventory = await _salesInventoryService.GetSalesInventoryByIdAsync(id);
            if(salesInventory == null)
                return RedirectToAction(nameof(Index));
            return View(salesInventory);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var salesInventory = await _salesInventoryService.GetSalesInventoryByIdForEditAsync(id);
            if (salesInventory == null)
                return RedirectToAction(nameof(Index));
            return View(salesInventory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SalesInvEdit model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var salesInventory = await _salesInventoryService.EditSalesInventoryAsync(model);
            if(!salesInventory)
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
            var salesInventory = await _salesInventoryService.GetSalesInventoryByIdAsync(id);
            if(salesInventory == null)
                return RedirectToAction(nameof(Index));
            return View(salesInventory);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SalesInvDetail model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            await _salesInventoryService.DeleteSalesInventoryAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}