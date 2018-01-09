using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NW_Central_Library.Models;

namespace NW_Central_Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = " Welcome to the Norhtwest Central Library.  .......before checking out materials and facility resources.  Also, ensure each juvenile member account is associated with an adult member. The conferences, lectures and personal workshops for this month, including the annual United for Libraries Friend Conference, a lecture series on Winter Gardening in the Pacific Northwest and the Becoming a Better Leader Workshop, are posted within the entrances of the library, as well as at every desk.  Don't forget to mark your calendar for the next American Library Association meeting in Conference Hall A on February 25, 2018 at 7:00pm.";

            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
