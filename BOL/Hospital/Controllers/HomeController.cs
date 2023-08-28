using BOL;
using Hosiptal_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BLL;

namespace Hosiptal_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetList()
        {
            List<KlingelnBerg> p = BLL.KlingelnBergService.GetList();
            ViewBag.list = p;
            return View("View");
        }

        public IActionResult GetAssetList() 
        {
            List<String> list = BLL.KlingelnBergService.GetAssetNameList();
            ViewBag.list = list;
            return View();
        }

        public IActionResult GetLatestMachineType()
        {
            List<String> list = BLL.KlingelnBergService.GetLatestMachineTypeList();
            ViewBag.list = list;
            return View();
        }

        public IActionResult Register(string assetName, string machineType, int seriesNumber)
        {
            KlingelnBerg p = new KlingelnBerg(assetName,machineType,seriesNumber);
            BLL.KlingelnBergService.insertP(p);
            return RedirectToAction("Index");
        }

       
    }
}