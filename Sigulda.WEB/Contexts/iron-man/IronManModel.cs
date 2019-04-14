namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IronManModel : DbContext
    {
        public IronManModel()
            : base("name=IronManDb")
        {
        }

        public virtual DbSet<iekarta> iekartas { get; set; }
        public virtual DbSet<Piederumi> Piederumis { get; set; }
        public virtual DbSet<Reagenti> Reagentis { get; set; }
        public virtual DbSet<Trauki> Traukis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reagenti>()
                .Property(e => e.Formula)
                .IsFixedLength();

            modelBuilder.Entity<Reagenti>()
                .Property(e => e.Stadija)
                .IsFixedLength();
        }
    }
}
