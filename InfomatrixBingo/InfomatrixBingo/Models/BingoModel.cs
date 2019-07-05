namespace InfomatrixBingo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BingoModel : DbContext
    {
        public BingoModel()
            : base("name=BingoModel")
        {
        }

        public virtual DbSet<AccountsTB> AccountsTBs { get; set; }
        public virtual DbSet<GameTB> GameTBs { get; set; }
        public virtual DbSet<UsersTB> UsersTBs { get; set; }
        public virtual DbSet<WinRecordsTB> WinRecordsTBs { get; set; }
        public virtual DbSet<WinTypeTB> WinTypeTBs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersTB>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<UsersTB>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UsersTB>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<WinTypeTB>()
                .Property(e => e.WinType)
                .IsUnicode(false);
        }
    }
}
