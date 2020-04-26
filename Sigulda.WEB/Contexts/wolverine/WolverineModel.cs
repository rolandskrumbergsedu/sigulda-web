namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WolverineModel : DbContext
    {
        public WolverineModel()
            : base("name=WolverineDb")
        {
        }

        public virtual DbSet<Klienti> Klientis { get; set; }
        public virtual DbSet<Laiva> Laivas { get; set; }
        public virtual DbSet<Laivu_veidi> Laivu_veidi { get; set; }
        public virtual DbSet<Pasutijumi> Pasutijumis { get; set; }
        public virtual DbSet<Piekabe> Piekabes { get; set; }
        public virtual DbSet<Piekabes_veids> Piekabes_veids { get; set; }
        public virtual DbSet<Soferi> Soferis { get; set; }
        public virtual DbSet<Transportlidzekli> Transportlidzeklis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klienti>()
                .Property(e => e.telefons)
                .HasPrecision(8, 0);

            modelBuilder.Entity<Klienti>()
                .HasMany(e => e.Pasutijumis)
                .WithRequired(e => e.Klienti)
                .HasForeignKey(e => e.Klients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laiva>()
                .Property(e => e.Skaits)
                .HasPrecision(4, 0);

            modelBuilder.Entity<Laiva>()
                .HasMany(e => e.Pasutijumis)
                .WithRequired(e => e.Laiva)
                .HasForeignKey(e => e.Laivu_veids)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laiva>()
                .HasMany(e => e.Pasutijumis1)
                .WithRequired(e => e.Laiva1)
                .HasForeignKey(e => e.Laivu_veids)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laivu_veidi>()
                .Property(e => e.Cilv_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Laivu_veidi>()
                .Property(e => e.Airi)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Laivu_veidi>()
                .HasMany(e => e.Laivas)
                .WithRequired(e => e.Laivu_veidi)
                .HasForeignKey(e => e.Veids)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Laivu_veidi>()
                .HasMany(e => e.Laivas1)
                .WithRequired(e => e.Laivu_veidi1)
                .HasForeignKey(e => e.Veids)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pasutijumi>()
                .Property(e => e.Laivu_daudzums)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Piekabe>()
                .HasMany(e => e.Transportlidzeklis)
                .WithRequired(e => e.Piekabe1)
                .HasForeignKey(e => e.PIekabe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Piekabes_veids>()
                .Property(e => e.Max_kajaku_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Piekabes_veids>()
                .Property(e => e.Max_kanoe_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Piekabes_veids>()
                .Property(e => e.Max_piep_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Piekabes_veids>()
                .Property(e => e.Max_supdelu_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Piekabes_veids>()
                .HasMany(e => e.Piekabes)
                .WithOptional(e => e.Piekabes_veids)
                .HasForeignKey(e => e.Veids);

            modelBuilder.Entity<Soferi>()
                .Property(e => e.Telefona_nr)
                .HasPrecision(8, 0);

            modelBuilder.Entity<Soferi>()
                .HasMany(e => e.Pasutijumis)
                .WithRequired(e => e.Soferi)
                .HasForeignKey(e => e.Soferis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transportlidzekli>()
                .Property(e => e.Gads)
                .HasPrecision(4, 0);

            modelBuilder.Entity<Transportlidzekli>()
                .Property(e => e.Max_cilv_ietilpiba)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Transportlidzekli>()
                .Property(e => e.Max_airu_ietilpiba)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Transportlidzekli>()
                .Property(e => e.Max_vestu_ietilpiba)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Transportlidzekli>()
                .Property(e => e.Numurzime)
                .HasPrecision(8, 0);

            modelBuilder.Entity<Transportlidzekli>()
                .HasMany(e => e.Soferis)
                .WithRequired(e => e.Transportlidzekli)
                .HasForeignKey(e => e.Transports)
                .WillCascadeOnDelete(false);
        }
    }
}
