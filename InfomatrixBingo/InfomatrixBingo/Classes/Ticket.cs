using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoAppClasses.Classes
{
    public class Ticket
    {
        public String ID { get; set; }

        public List<Row> rows { get; set; }

        public int numCompletedRows { get; set; } = 0;

    }
}
