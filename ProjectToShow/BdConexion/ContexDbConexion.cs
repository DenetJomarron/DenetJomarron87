namespace BdConexion
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContexDbConexion : DbContext
    {
        public ContexDbConexion()
            : base("name=ContexDbConexion")
        {
        }

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
