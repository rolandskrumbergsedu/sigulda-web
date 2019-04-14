namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BatmanModel : DbContext
    {
        public BatmanModel()
            : base("name=BatmanDb")
        {
        }

        public virtual DbSet<AktivaKomponente> Aktīvā_komponente { get; set; }
        public virtual DbSet<Akumulators> Akumulators { get; set; }
        public virtual DbSet<Baterija> Baterijas { get; set; }
        public virtual DbSet<ElektromehaniskaKomponente> Elektromehāniskā_komponente { get; set; }
        public virtual DbSet<EnergijasKomponente> Enerģijas_komponente { get; set; }
        public virtual DbSet<GatavaShemaModulis> Gatavā_shēma_modulis { get; set; }
        public virtual DbSet<Komponente> Komponente { get; set; }
        public virtual DbSet<Komponentes> Komponentes { get; set; }
        public virtual DbSet<PasivaKomponente> Pasīvā_komponente { get; set; }
        public virtual DbSet<Sensors> Sensors { get; set; }
        public virtual DbSet<Vadi> Vadis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akumulators>()
                .Property(e => e.Voltāža_V)
                .HasPrecision(10, 3);
        }
    }
}
