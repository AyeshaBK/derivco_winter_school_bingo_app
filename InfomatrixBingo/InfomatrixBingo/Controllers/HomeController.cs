using BingoAppClasses.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppDummyAPI.Classes;

namespace WebAppDummyAPI.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            if (StaticClass.currentUser.Equals(""))
            {
                return RedirectToAction("Login", "Users");
            }

            Debug.WriteLine("NEW GAME!!!!!!!!!!");

            StaticClass.userStrip = new Strip();

            StaticClass.ballSequence = new List<Ball>();

            StaticClass.ticketBallList = new List<TicketBall>();

            StaticClass.isGameOver = false;

            StaticClass.GameState = 0;



        //Generate user strip and store in Static class
        StripGenerator generator = new StripGenerator();

            Strip userStrip = new Strip();


            userStrip = generator.GetStrip();
            
           

            StaticClass.userStrip = userStrip;




            //Generate ball sequence and store in Static class
            List<Ball> bSequence = new List<Ball>();

            List<Ball> sequence = new List<Ball>();


            for (int i = 0; i < 90; i++)
            {
                Ball b = new Ball();
                b.BallNum = i +1;
                b.inGame = false;
                bSequence.Add(b);
            }


            //Code to shuffle balls in ball sequence
            Random r = new Random();
            int randomIndex = 0;
            while (bSequence.Count > 0)
            {
                randomIndex = r.Next(0, bSequence.Count); 
                sequence.Add(bSequence[randomIndex]); 
                bSequence.RemoveAt(randomIndex); 
            }
            

            StaticClass.ballSequence = sequence;






            //Generate and sort ticketBall list  (for JS use) and store in static class
            List<TicketBall> ticketBallList = new List<TicketBall>();



            foreach (Ticket t in userStrip.Tickets)
            {

                foreach (Row row in t.rows)
                {
                    int count = 1;

                    foreach (Ball b in row.BallList)
                    {
                        TicketBall tb = new TicketBall();
                        tb.TicketId = int.Parse(t.ID);
                        tb.BallRow = int.Parse(row.ID);
                        tb.BallNum = b.BallNum;
                        tb.BallCol = count;

                        ticketBallList.Add(tb);

                        count++;
                    }
                }
            }



            StaticClass.ticketBallList = ticketBallList;

            StaticClass.GameState = 0;
            
            

            StaticClass.isGameOver = false;

            StaticClass.GameState = 0;
           

            

            return View();
        }


       







    }
}
