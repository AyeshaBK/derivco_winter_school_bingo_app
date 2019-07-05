using BingoAppClasses.Classes;
using InfomatrixBingo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDummyAPI.Classes
{
    public class StaticClass
    {
        public static Strip userStrip = new Strip();

        public static List<Ball> ballSequence = new List<Ball>();

        public static List<TicketBall> ticketBallList = new List<TicketBall>();

        public static Boolean isGameOver = false;

        public static int GameState = 0;

        public static String errorMessage = "";

        public static String currentUser = "";

        public static int balance = 0;

        public static int accId = 0;

        public static DateTime date = new DateTime();
    }
}