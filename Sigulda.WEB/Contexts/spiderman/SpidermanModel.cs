namespace Sigulda.WEB.Contexts.spiderman
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SpidermanModel : DbContext
    {
        public SpidermanModel()
            : base("name=SpidermanDb")
        {
        }

        public virtual DbSet<Citi> Citi { get; set; }
        public virtual DbSet<Galdi> Galdi { get; set; }
        public virtual DbSet<Kresli> Kresli { get; set; }
        public virtual DbSet<Monitori> Monitori { get; set; }
        public virtual DbSet<Tafeles> Tafeles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
