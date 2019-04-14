namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventars()
        {
            Kabinets = new HashSet<Kabinets>();
            Kabinets1 = new HashSet<Kabinets>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InventaraID { get; set; }

        [Required]
        [StringLength(50)]
        public string InvNosaukums { get; set; }

        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        public double Nolietojums { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabinets> Kabinets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabinets> Kabinets1 { get; set; }
    }
}
