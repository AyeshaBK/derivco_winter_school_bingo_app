using InfomatrixBingo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDummyAPI.Classes;

namespace BingoApp.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult GamePage()
        {

            DateTime now = DateTime.Now;


            StaticClass.date = now;

            StaticClass.balance = StaticClass.balance - 50;



            return View();
        }
    }
}