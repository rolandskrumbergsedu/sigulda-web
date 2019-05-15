namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DeadPoolModel : DbContext
    {
        public DeadPoolModel()
            : base("name=DeadPoolDb")
        {
        }

        public virtual DbSet<Atbildigais> Atbildigais { get; set; }
        public virtual DbSet<ElektroniskasIericesDeadpool> ElektroniskasIerices { get; set; }
        public virtual DbSet<Inventars> Inventars { get; set; }
        public virtual DbSet<KabinetsWolverine> Kabinets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atbildigais>()
                .HasMany(e => e.Kabinets1)
                .WithOptional(e => e.Atbildigais1)
                .HasForeignKey(e => e.AtbildigaisID);

            modelBuilder.Entity<ElektroniskasIericesDeadpool>()
                .Property(e => e.IericesCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inventars>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inventars>()
                .HasMany(e => e.Kabinets)
                .WithOptional(e => e.Inventars)
                .HasForeignKey(e => e.InventaraID);

            modelBuilder.Entity<Inventars>()
                .HasMany(e => e.Kabinets1)
                .WithOptional(e => e.Inventars1)
                .HasForeignKey(e => e.InventaraID);

            modelBuilder.Entity<KabinetsWolverine>()
                .HasMany(e => e.Atbildigais)
                .WithOptional(e => e.Kabinets)
                .HasForeignKey(e => e.KabinetaID);
        }
    }
}
