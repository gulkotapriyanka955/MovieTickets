using GulkotaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GulkotaProject.Controllers
{

    //Created by Gulkota Priyanka
    public class HomeController : Controller
    {
        //Action methods for the Home and About Page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }//Controller
}//namespace