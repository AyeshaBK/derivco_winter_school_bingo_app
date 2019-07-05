namespace InfomatrixBingo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WinTypeTB")]
    public partial class WinTypeTB
    {
        [Key]
        public int WinTypeID { get; set; }

        [Required]
        [StringLength(30)]
        public string WinType { get; set; }

        public int WinAmount { get; set; }
    }
}
