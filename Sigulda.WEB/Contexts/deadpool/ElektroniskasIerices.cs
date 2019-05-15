namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ElektroniskasIerices")]
    public partial class ElektroniskasIericesDeadpool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ElektroniskasIericesDeadpool()
        {
            Kabinets = new HashSet<KabinetsWolverine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IericesID { get; set; }

        public double? IericesNolietojums { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Datums { get; set; }

        [Column(TypeName = "money")]
        public decimal IericesCena { get; set; }

        [Required]
        [StringLength(50)]
        public string IericesNosaukums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KabinetsWolverine> Kabinets { get; set; }
    }
}
