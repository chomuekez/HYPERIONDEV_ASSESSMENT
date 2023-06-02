using HYPERION_ASSESSMENT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HYPERION_ASSESSMENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext _context;
        
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomePage()
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
        
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

    }
}
