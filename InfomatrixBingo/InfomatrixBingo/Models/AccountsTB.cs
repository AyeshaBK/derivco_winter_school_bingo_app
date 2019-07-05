namespace InfomatrixBingo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountsTB")]
    public partial class AccountsTB
    {
        [Key]
        public int AccountID { get; set; }

        public int PlayerID { get; set; }

        public int Balance { get; set; }
    }
}
