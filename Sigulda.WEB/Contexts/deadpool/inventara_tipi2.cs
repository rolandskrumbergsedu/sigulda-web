namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class inventara_tipi2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inventara_tipi2()
        {
            Kabineta_inventars2 = new HashSet<Kabineta_inventars2>();
        }

        [Key]
        [StringLength(50)]
        public string tipa_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string nosaukums { get; set; }

        [StringLength(200)]
        public string Apraksts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineta_inventars2> Kabineta_inventars2 { get; set; }
    }
}
