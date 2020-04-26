namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Piekabes_veids
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Piekabes_veids()
        {
            Piekabes = new HashSet<Piekabe>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PVID { get; set; }

        [Required]
        [StringLength(30)]
        public string Veida_nosaukums { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_kajaku_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_kanoe_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_piep_ietilpiba { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Max_supdelu_ietilpiba { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Piekabe> Piekabes { get; set; }
    }
}
