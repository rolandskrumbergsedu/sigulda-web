namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transportlidzekli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transportlidzekli()
        {
            Soferis = new HashSet<Soferi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransportaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ipasnieks { get; set; }

        [Required]
        [StringLength(30)]
        public string Marka { get; set; }

        [Required]
        [StringLength(30)]
        public string Modelis { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Gads { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_cilv_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_airu_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_vestu_ietilpiba { get; set; }

        public int PIekabe { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Numurzime { get; set; }

        public virtual Piekabe Piekabe1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soferi> Soferis { get; set; }
    }
}
