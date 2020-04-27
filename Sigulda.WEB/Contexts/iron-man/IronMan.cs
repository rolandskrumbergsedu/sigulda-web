namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IronMan : DbContext
    {
        public IronMan()
            : base("name=IronManDb")
        {
        }

        public virtual DbSet<Atbildīgais> Atbildīgais { get; set; }
        public virtual DbSet<Kabinet> Kabinets { get; set; }
        public virtual DbSet<Objekt> Objekts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atbildīgais>()
                .Property(e => e.Vārds)
                .IsUnicode(false);

            modelBuilder.Entity<Atbildīgais>()
                .Property(e => e.Uzvārds)
                .IsUnicode(false);
        }
    }
}
