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

        public virtual DbSet<AktivaKomponente> AktivasKomponentes { get; set; }
        public virtual DbSet<Akumulators> Akumulatori { get; set; }
        public virtual DbSet<Baterija> Baterijas { get; set; }
        public virtual DbSet<ElektromehaniskaKomponente> ElektromehāniskasKomponentes { get; set; }
        public virtual DbSet<EnergijasKomponente> Enerģijas_komponente { get; set; }
        public virtual DbSet<GatavaShemaModulis> GatavasShemasModulis { get; set; }
        public virtual DbSet<Komponente> Komponente { get; set; }
        public virtual DbSet<Komponentes> Komponentes { get; set; }
        public virtual DbSet<PasivaKomponente> PasīvasKomponentes { get; set; }
        public virtual DbSet<Sensors> Sensori { get; set; }
        public virtual DbSet<Vadi> Vadis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akumulators>()
                .Property(e => e.Voltāža_V)
                .HasPrecision(10, 3);
        }
    }
}
