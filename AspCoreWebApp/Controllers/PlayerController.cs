using AspCoreWebApp.BL;
using AspCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerInfo _playerInfo;
        private readonly ILogger<PlayerController> _logger;


        public PlayerController(IPlayerInfo playerInfo, ILogger<PlayerController> logger)
            {
            this._playerInfo = playerInfo;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            _playerInfo.SetScore(100);
            ViewBag.Score = _playerInfo.GetScore();
            return View(new RegisterViewModel());
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            //Logic to save the data
            return RedirectToAction("Index", registerViewModel);
        }

    }

}
