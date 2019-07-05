using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDummyAPI.Classes
{
    public class TicketBall
    {
        public int BallNum { get; set; }
        public int BallRow { get; set;  }
        public int BallCol { get; set; }

        public int TicketId { get; set; }

        public int GameOver { get; set; } = 0;


       
    }
}