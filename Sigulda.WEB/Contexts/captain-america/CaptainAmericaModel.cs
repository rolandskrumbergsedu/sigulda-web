namespace Sigulda.WEB.Contexts.captain_america
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CaptainAmericaModel : DbContext
    {
        public CaptainAmericaModel()
            : base("name=CaptainAmericaDb")
        {
        }

        public virtual DbSet<Klase> Klases { get; set; }
        public virtual DbSet<Macibu_prieksmets> Macibu_prieksmets { get; set; }
        public virtual DbSet<Macibu_stunda> Macibu_stunda { get; set; }
        public virtual DbSet<StundasTema> StundasTemas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klase>()
                .Property(e => e.Klase1)
                .IsUnicode(false);

            modelBuilder.Entity<Macibu_prieksmets>()
                .Property(e => e.Stundas_nosaukums)
                .IsUnicode(false);

            modelBuilder.Entity<Macibu_stunda>()
                .Property(e => e.Piezime)
                .IsUnicode(false);

            modelBuilder.Entity<Macibu_stunda>()
                .Property(e => e.Kabineta_nr)
                .IsUnicode(false);

            modelBuilder.Entity<StundasTema>()
                .Property(e => e.Tema)
                .IsUnicode(false);

            modelBuilder.Entity<StundasTema>()
                .Property(e => e.Piezime)
                .IsUnicode(false);
        }
    }
}
