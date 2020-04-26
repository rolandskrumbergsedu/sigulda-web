namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Laivu_veidi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laivu_veidi()
        {
            Laivas = new HashSet<Laiva>();
            Laivas1 = new HashSet<Laiva>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LVID { get; set; }

        [Required]
        [StringLength(20)]
        public string Veida_nosaukums { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cilv_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Airi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laiva> Laivas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laiva> Laivas1 { get; set; }
    }
}
