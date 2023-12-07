using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wright.Models.ListingModels;
using Wright.Services.ListingServices;

namespace Wright.MVC.Controllers
{
    public class ListingController : Controller
    {
        private readonly ILogger<ListingController> _logger;
        private readonly IListingService _listingService;

        public ListingController(ILogger<ListingController> logger, IListingService listingService)
        {
            _logger = logger;
            _listingService = listingService;
        }

        public async Task<IActionResult> Index()
        {
            List<ListingIndex> listings = await _listingService.GetAllListingsAsync();

            return View(listings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            await _listingService.CreateNewListingAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Details")]
        public async Task<IActionResult> ListingDetails(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var listing = await _listingService.GetListingByIdAsync(id);
            if(listing == null)
                return RedirectToAction(nameof(Index));
            return View(listing);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var listing = await _listingService.GetListingByIdForEditAsync(id);
            if (listing == null)
                return RedirectToAction(nameof(Index));
            return View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ListingEdit model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var listing = await _listingService.EditListingAsync(model);
            if(!listing)
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
            var listing = await _listingService.GetListingByIdAsync(id);
            if(listing == null)
                return RedirectToAction(nameof(Index));
            return View(listing);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ListingDetail model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            await _listingService.DeleteListingAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}