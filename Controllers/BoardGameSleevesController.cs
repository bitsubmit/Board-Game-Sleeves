using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Board_game_sleeves.Controllers
{
    public class BoardGameSleevesController : Controller
    {
        // GET: BoardGameSleeves
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SleeveFitter()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}