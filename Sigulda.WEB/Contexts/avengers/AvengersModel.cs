namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AvengersModel : DbContext
    {
        public AvengersModel()
            : base("name=AvengersDb")
        {
        }

        public virtual DbSet<Amurs> Amurs { get; set; }
        public virtual DbSet<Filiments> Filiments { get; set; }
        public virtual DbSet<Knaibles> Knaibles { get; set; }
        public virtual DbSet<Materiali> Materials { get; set; }
        public virtual DbSet<Skruvjgriezni> Skruvjgrieznis { get; set; }
        public virtual DbSet<Viles> Viles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amurs>()
                .Property(e => e.ipasas_iezimes)
                .IsUnicode(false);

            modelBuilder.Entity<Amurs>()
                .Property(e => e.Panema)
                .IsFixedLength();

            modelBuilder.Entity<Filiments>()
                .Property(e => e.krasa)
                .IsFixedLength();

            modelBuilder.Entity<Filiments>()
                .Property(e => e.materials)
                .IsFixedLength();

            modelBuilder.Entity<Knaibles>()
                .Property(e => e.Veids)
                .IsFixedLength();

            modelBuilder.Entity<Knaibles>()
                .Property(e => e.ipasas_iezimes)
                .IsUnicode(false);

            modelBuilder.Entity<Knaibles>()
                .Property(e => e.Panema)
                .IsFixedLength();

            modelBuilder.Entity<Materiali>()
                .Property(e => e.Materials)
                .IsFixedLength();

            modelBuilder.Entity<Materiali>()
                .Property(e => e.iezimes)
                .IsUnicode(false);

            modelBuilder.Entity<Skruvjgriezni>()
                .Property(e => e.gals)
                .IsFixedLength();

            modelBuilder.Entity<Skruvjgriezni>()
                .Property(e => e.ipasas_iezimes)
                .IsUnicode(false);

            modelBuilder.Entity<Skruvjgriezni>()
                .Property(e => e.Panema)
                .IsFixedLength();

            modelBuilder.Entity<Viles>()
                .Property(e => e.Veids)
                .IsFixedLength();

            modelBuilder.Entity<Viles>()
                .Property(e => e.ipasas_iezimes)
                .IsUnicode(false);

            modelBuilder.Entity<Viles>()
                .Property(e => e.Panema)
                .IsFixedLength();
        }
    }
}
