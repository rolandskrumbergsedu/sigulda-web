namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Deadpool : DbContext
    {
        public Deadpool()
            : base("name=DeadpoolDb")
        {
        }

        public virtual DbSet<inventara_tipi2> inventara_tipi2 { get; set; }
        public virtual DbSet<Kabineta_inventars2> Kabineta_inventars2 { get; set; }
        public virtual DbSet<Kabineti1> Kabineti1 { get; set; }
        public virtual DbSet<Lietotaji1> Lietotaji1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<inventara_tipi2>()
                .Property(e => e.tipa_id)
                .IsUnicode(false);

            modelBuilder.Entity<inventara_tipi2>()
                .Property(e => e.nosaukums)
                .IsUnicode(false);

            modelBuilder.Entity<inventara_tipi2>()
                .Property(e => e.Apraksts)
                .IsUnicode(false);

            modelBuilder.Entity<inventara_tipi2>()
                .HasMany(e => e.Kabineta_inventars2)
                .WithRequired(e => e.inventara_tipi2)
                .HasForeignKey(e => e.tipa_kods)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kabineta_inventars2>()
                .Property(e => e.tipa_kods)
                .IsUnicode(false);

            modelBuilder.Entity<Kabineti1>()
                .Property(e => e.kabineta_nummurs)
                .IsUnicode(false);

            modelBuilder.Entity<Kabineti1>()
                .Property(e => e.atrasanas_vieta)
                .IsUnicode(false);

            modelBuilder.Entity<Kabineti1>()
                .HasMany(e => e.Kabineta_inventars2)
                .WithRequired(e => e.Kabineti1)
                .HasForeignKey(e => e.Kabineta_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kabineti1>()
                .HasMany(e => e.Kabineta_inventars21)
                .WithRequired(e => e.Kabineti11)
                .HasForeignKey(e => e.Kabineta_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lietotaji1>()
                .Property(e => e.vards)
                .IsUnicode(false);

            modelBuilder.Entity<Lietotaji1>()
                .Property(e => e.uzvards)
                .IsUnicode(false);

            modelBuilder.Entity<Lietotaji1>()
                .Property(e => e.personas_kods)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Lietotaji1>()
                .HasMany(e => e.Kabineti1)
                .WithRequired(e => e.Lietotaji1)
                .HasForeignKey(e => e.skolotajs_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lietotaji1>()
                .HasMany(e => e.Kabineti11)
                .WithRequired(e => e.Lietotaji11)
                .HasForeignKey(e => e.skolotajs_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lietotaji1>()
                .HasMany(e => e.Kabineti12)
                .WithRequired(e => e.Lietotaji12)
                .HasForeignKey(e => e.skolotajs_id)
                .WillCascadeOnDelete(false);
        }
    }
}
