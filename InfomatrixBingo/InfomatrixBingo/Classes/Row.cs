using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoAppClasses.Classes
{
    public class Row
    {
        public List<Ball> BallList { get; set; }

        public String ID { get; set; }

        public Boolean isRowCompleted { get; set; } = false;
    }
}
