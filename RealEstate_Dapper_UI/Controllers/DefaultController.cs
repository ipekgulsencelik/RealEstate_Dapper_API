using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SearchPartial() 
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _SearchPartial(string word)
        {
            TempData["word"] = word;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}