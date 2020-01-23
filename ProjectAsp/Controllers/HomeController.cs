using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectAsp.Db;
using ProjectAsp.Models;
using ProjectAsp.Services;

namespace ProjectAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RestaurantService restaurantService;

        public HomeController(ILogger<HomeController> logger, RestaurantContext restCtx)
        {
            _logger = logger;
            this.restaurantService = new RestaurantService(restCtx);
        }

        public IActionResult Index()
        {
            List<Restaurant> listResto = this.restaurantService.getAllRest().Where(x => x.note != null).OrderByDescending(x => x.note.note).Take(5).ToList();
            /*JsonService jsonService = new JsonService(this.restaurantService);
            jsonService.importData("C:\\Users\\arder\\Desktop\\resto.json");
            jsonService.exportData("C:\\Users\\arder\\Desktop\\resto2.json");*/
            //restaurantService.update();
            return View("index", listResto);
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
    }
}
