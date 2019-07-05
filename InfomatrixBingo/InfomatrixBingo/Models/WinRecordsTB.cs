namespace InfomatrixBingo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WinRecordsTB")]
    public partial class WinRecordsTB
    {
        [Key]
        public int WinRecordID { get; set; }

        public int WinTypeID { get; set; }

        public int PlayerID { get; set; }

        public int GameID { get; set; }
    }
}
