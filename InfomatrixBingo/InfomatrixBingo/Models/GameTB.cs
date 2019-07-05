namespace InfomatrixBingo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameTB")]
    public partial class GameTB
    {
        [Key]
        public int GameID { get; set; }

        [Column(TypeName = "date")]
        public DateTime GameDate { get; set; }

        public int NumberPlayer { get; set; }
    }
}
