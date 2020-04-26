namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klienti")]
    public partial class Klienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klienti()
        {
            Pasutijumis = new HashSet<Pasutijumi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Klienta_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Klienta_vards { get; set; }

        [Required]
        [StringLength(50)]
        public string Klienta_uzvards { get; set; }

        [Column(TypeName = "numeric")]
        public decimal telefons { get; set; }

        [Column("e-pasts")]
        [Required]
        [StringLength(100)]
        public string e_pasts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasutijumi> Pasutijumis { get; set; }
    }
}
