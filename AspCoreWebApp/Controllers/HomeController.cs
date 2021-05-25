using AspCoreWebApp.BL;
using AspCoreWebApp.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlayerInfo playerInfo;
        private readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public HomeController(ILogger<HomeController> logger, IPlayerInfo playerInfo)
        {
            _logger = logger;
            this.playerInfo = playerInfo;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("This is logging the information");
            //_logger.LogDebug("This is logging the Debug");
            //_logger.LogTrace("This is logging the trace");
            //_logger.LogWarning("This is logging the Warning");
            //_logger.LogError("This is logging the Error");
            //_logger.LogCritical("This is logging the Critical");

            log.Info("This is logging the information");
            log.Debug("This is logging the Debug");
            log.Warn("This is logging the Warning");
            log.Error("This is logging the Error");
            log.Fatal("This is logging the Fatal");

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

        public IActionResult LastestScore()
        {
            ViewBag.LatestScore = this.playerInfo.GetScore();
            return View();
        }
    }
}
