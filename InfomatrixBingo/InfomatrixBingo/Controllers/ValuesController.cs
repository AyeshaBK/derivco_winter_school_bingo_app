using BingoAppClasses.Classes;
using InfomatrixBingo.Classes;
using InfomatrixBingo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppDummyAPI.Classes;

namespace WebAppDummyAPI.Controllers
{
    public class ValuesController : ApiController
    {

        private BingoModel db = new BingoModel();

        //http://localhost:50641/api/values/getticketballlist  use to get ticket ball list (for JS)

        //http://localhost:50641/api/values  use to get ball sequence (for JS)

        //http://localhost:50641/api/values (Ball b)  (POST!!!!)  to pass ball number to API and GET Marked ball location

        //http://localhost:50641/api/values/GetBalance Get User balance

        //http://localhost:50641/api/values/PostBalance(int)  (POST!!!!)  to pass wintype after game... to update user balance


        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values
        public List<Ball> Get()
        {
            return StaticClass.ballSequence;
        }


        //api/values/GetBalance
        [Route("api/values/GetBalance")]
        [HttpGet]
        public int GetBalance()
        {
            Debug.WriteLine("ACCOUNT FROM LOGIN: " + StaticClass.balance);
            return StaticClass.balance;
        }

        [Route("api/values/PostBalance")]
        [HttpPost]
        public void PostBalance(Balance b)
        {
            int winType = b.wintype;

            int winAmount = 0;

            switch(winType)
            {
                case 1:
                    winAmount = 30;
                        break;

                case 2:
                    winAmount = 60;
                    break;

                case 3:
                    winAmount = 120;
                    break;

            }

            Debug.WriteLine("ACCOUNT BALANCE BEFORE WIN: " + StaticClass.balance);
            StaticClass.balance = StaticClass.balance + winAmount;

            Debug.WriteLine("ACCOUNT BALANCE AFTER WIN: " + StaticClass.balance);

            List<AccountsTB> accounts = db.AccountsTBs.ToList();

            AccountsTB accountTB = db.AccountsTBs.Find(StaticClass.accId);

            accountTB.Balance = StaticClass.balance;

           
                db.Entry(accountTB).State = EntityState.Modified;
                db.SaveChanges();


            GameTB game = new GameTB();

            game.NumberPlayer = 1;
            game.GameDate = StaticClass.date;
            db.GameTBs.Add(game);
            db.SaveChanges();


            WinTypeTB winTypeRecord = new WinTypeTB();

            winTypeRecord.WinAmount = winAmount;
            winTypeRecord.WinType = "Full House";
            db.WinTypeTBs.Add(winTypeRecord);
            db.SaveChanges();

            int wtrcount = 0;

            foreach(WinTypeTB winTypeRec in db.WinTypeTBs)
            {
                wtrcount++;
            }

            int cnt = 0;
            int searchwintypeid = 0;

            foreach (WinTypeTB winTypeRec in db.WinTypeTBs)
            {
                cnt++;
                if (cnt.Equals(wtrcount))
                {
                    searchwintypeid = winTypeRec.WinTypeID;
                }
               

            }



            WinRecordsTB winRecord = new WinRecordsTB();
            winRecord.GameID = game.GameID;
            winRecord.PlayerID = accountTB.PlayerID;
            winRecord.WinTypeID = searchwintypeid;

            db.WinRecordsTBs.Add(winRecord);
            db.SaveChanges();

            Debug.WriteLine("DONE");
            


        }


        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

            //POST api/values
        [HttpPost]
        public TicketBall Post([FromBody]Ball ball)
        {
            StaticClass.isGameOver = false;
            int searchRowID = 0;


            TicketBall tBall = new TicketBall();

            tBall.GameOver = 0;

            //Search for ball in Strip and Daub user Strip
            foreach (Ticket t in StaticClass.userStrip.Tickets)
            {
                foreach(Row r in t.rows)
                {
                    foreach (Ball b in r.BallList)
                    {

                        if (b.BallNum == ball.BallNum)
                        {
                            tBall.BallRow = int.Parse(r.ID);
                            tBall.TicketId = int.Parse(t.ID);
                            tBall.BallNum = b.BallNum;
                            b.inGame = true;
                            searchRowID = int.Parse(r.ID);
                        }
                    }
                }
            }

            //Check for Column Number


            Ticket searchTicket = new Ticket();

            foreach(Ticket t in StaticClass.userStrip.Tickets)
            {
                int tid = int.Parse(t.ID);

                if (tid == tBall.TicketId)
                {
                    searchTicket = t;
                }
            }

            Row searchRow = new Row();

            foreach(Row r in searchTicket.rows)
            {
                int rid = int.Parse(r.ID);

                if (rid == searchRowID)
                {
                    searchRow = r;
                }
            }

            int count = 1;

            foreach(Ball b in searchRow.BallList)
            {
                if (b.BallNum == tBall.BallNum)
                {
                    tBall.BallCol = count;
                    
                }
                count++;
            }


            //Check For Win

             //CheckForOneLine

            int rowID = 0;
            int MarkedBalls = 0;

            foreach (Ticket t in StaticClass.userStrip.Tickets)
            {
                
                foreach (Row r in t.rows)
                {
                    rowID++;
                    MarkedBalls = 0;

                    foreach (Ball b in r.BallList)
                    {


                        if (b.inGame == true)
                        {
                            MarkedBalls++;
                        }
                    }

                    if (MarkedBalls == 5)
                    {
                        //Completed rows



                        foreach (Ticket tick in StaticClass.userStrip.Tickets)
                        {

                            foreach (Row rw in tick.rows)
                            {
                                int rid = int.Parse(rw.ID);

                                if (rid == rowID)
                                {
                                    if (rw.isRowCompleted == false)
                                    {
                                        rw.isRowCompleted = true;

                                        if (StaticClass.GameState == 0)
                                        {
                                            StaticClass.GameState = 1;
                                            tBall.GameOver = 1;
                                        }

                                        Debug.WriteLine("ROWWWW " + rid + " is completed");

                                    }
                                }
                            }
                        }

                    }

                    MarkedBalls = 0;
                }
            }


            int ticketID = 0;
            int completedRows = 0;

            foreach (Ticket t in StaticClass.userStrip.Tickets)
            {
                ticketID++;
                completedRows = 0;
                foreach (Row r in t.rows)
                {
                    if (r.isRowCompleted == true)
                    {
                        completedRows++;
                    }
                }

                if (completedRows == 2)
                {
                    if (StaticClass.GameState < 2)
                    {
                        StaticClass.GameState = 2;
                        tBall.GameOver = 2;
                    }

                }

                if (completedRows == 3)
                {
                    StaticClass.GameState = 3;
                    //Game Over
                    StaticClass.isGameOver = true;

                }
            }






            if (StaticClass.isGameOver == true)
            {
                tBall.GameOver = 3;

                Debug.WriteLine("THE GAME IS OVER, WE HAVE A WINNNNNEEEERRR!!!!!!!");
            }

            Debug.WriteLine("tBall Game Over Value: " + tBall.GameOver);
            Debug.WriteLine("Game State: " + StaticClass.GameState);

            return tBall;

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }


        //get ball sequence  GET api/values/5
        //public int[] Get(int id)
        //{
        //    return ballsequence;
        //}



        [Route("api/values/GetTicketBallList")]
        [HttpGet]
        public List<TicketBall> GetTicketBallList()
        {
            return StaticClass.ticketBallList;
        }



        [Route("api/values/GetIsGameOver")]
        [HttpGet]
        public Boolean GetIsGameOver()
        {
            return StaticClass.isGameOver;
        }


        //public void CheckForOneLine()
        //{
        //    int rowID = 0;
        //    int MarkedBalls = 0;

        //    foreach (Ticket t in StaticClass.userStrip.Tickets)
        //    {
        //        rowID++;
        //        foreach (Row r in t.rows)
        //        {
        //            MarkedBalls = 0;

        //            foreach (Ball b in r.BallList)
        //            {
                       

        //                if (b.inGame == true)
        //                {
        //                    MarkedBalls++;
        //                }
        //            }

        //            if(MarkedBalls ==5)
        //            {
        //                CompletedRow(rowID);
        //            }
        //        }
        //    }


        //}


        //public void CompletedRow(int rowID)
        //{
        //    foreach (Ticket t in StaticClass.userStrip.Tickets)
        //    {
               
        //        foreach (Row r in t.rows)
        //        {
        //            int rid = int.Parse(r.ID);

        //            if (rid == rowID)
        //            {
        //                if (r.isRowCompleted == false)
        //                {
        //                    r.isRowCompleted = true;

        //                    CheckForFullHouse();
        //                }
        //            }
        //        }
        //    }

            
        //}


        //public void CheckForFullHouse()
        //{
        //    int ticketID = 0;
        //    int completedRows = 0;

        //    foreach (Ticket t in StaticClass.userStrip.Tickets)
        //    {
        //        ticketID++;
        //        completedRows = 0;
        //        foreach (Row r in t.rows)
        //        {
        //            if (r.isRowCompleted == true)
        //            {
        //                completedRows++;
        //            }
        //        }

        //        if (completedRows == 3)
        //        {
        //            GameOver(ticketID);
        //        }
        //    }
        //}


        //public void GameOver(int ticketID)
        //{
        //    StaticClass.isGameOver = true;
        //}



    }




}
