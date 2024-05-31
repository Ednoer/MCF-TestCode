using BpkbMvc.Models;
using BpkbMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BpkbMvc.Controllers
{
    public class TrBpkbController : Controller
    {
        private readonly TrBpkbService _trBpkbService;

        public TrBpkbController(TrBpkbService trBpkbService)
        {
            _trBpkbService = trBpkbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            TrBpkbModel trBpkbModel;
            List<Location> locations = new List<Location>();
            try
            {
                trBpkbModel = await _trBpkbService.GetTrBpkb(token);
                locations = await _trBpkbService.GetLocations(token);

                ViewBag.Locations = locations;

                return View(trBpkbModel);
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", "Failed to retrieve data from the server. Please try again later.");
                trBpkbModel = new TrBpkbModel();
                return View(trBpkbModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(TrBpkbModel trBpkbModel)
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please fix the validation errors.";
                return View(trBpkbModel);
            }

            await _trBpkbService.UpsertTrBpkb(trBpkbModel, token);
            TempData["SuccessMessage"] = "Data successfully saved.";
            return RedirectToAction("Index");
        }
    }
}
