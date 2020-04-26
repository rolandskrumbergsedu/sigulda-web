namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AvengersModel : DbContext
    {
        public AvengersModel()
            : base("name=AvengersDb")
        {
        }

        public virtual DbSet<Iekarta> Iekartas { get; set; }
        public virtual DbSet<Macibu_Materiali> Macibu_Materialis { get; set; }
        public virtual DbSet<Prieksmeti> Prieksmetis { get; set; }
        public virtual DbSet<Reaktivas_Viela> Reaktivas_Vielas { get; set; }
        public virtual DbSet<Trauki> Traukis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Iekarta>()
                .Property(e => e.Skaits)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Macibu_Materiali>()
                .Property(e => e.Skaits)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Prieksmeti>()
                .Property(e => e.Skaits)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Reaktivas_Viela>()
                .Property(e => e.Skaits)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Trauki>()
                .Property(e => e.Skaits)
                .HasPrecision(3, 0);
        }
    }
}
