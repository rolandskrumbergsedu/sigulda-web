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

        public virtual DbSet<Atbildigie> Atbildigie { get; set; }
        public virtual DbSet<Mebeles> Mebeles { get; set; }
        public virtual DbSet<ElektroniskasIerices> Elektroniskas_ierices { get; set; }
        public virtual DbSet<Kabinets> Kabinets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atbildigie>()
                .Property(e => e.Uzvards)
                .IsUnicode(false);

            modelBuilder.Entity<Atbildigie>()
                .Property(e => e.Amats)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Sigulda.WEB.Contexts.deadpool.Inventars> Inventars { get; set; }
    }
}
