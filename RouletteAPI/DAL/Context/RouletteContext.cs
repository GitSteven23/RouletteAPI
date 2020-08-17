using DAL.Entities;
using System.Data.Entity;

namespace DAL.Context
{
    public class RouletteContext : DbContext
    {
        public RouletteContext() : base("name=RouletteContext")
        { }

        public virtual DbSet<Bets> Bets { get; set; }
        public virtual DbSet<Roulettes> Roulettes { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bets>()
                .Property(e => e.Money)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Roulettes>()
                .HasMany(e => e.Bets)
                .WithRequired(e => e.Roulettes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Available_Credit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Bets)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
