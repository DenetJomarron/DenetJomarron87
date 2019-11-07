namespace DbConexion
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContex : DbContext
    {
        public DbContex()
            : base("name=DbContex")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Dealer)
                .HasForeignKey(e => e.IdDealer);

            modelBuilder.Entity<Dealer>()
                .HasMany(e => e.Vehicles)
                .WithRequired(e => e.Dealer)
                .HasForeignKey(e => e.IdDealer);
        }
    }
}
