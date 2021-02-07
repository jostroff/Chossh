using Chess.Game.GameEngine;
using Chess.Game.GameEngine.Initializators;
using Chess.Game.InputProviders;
using Chess.Game.OutputProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chess.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
    }
}