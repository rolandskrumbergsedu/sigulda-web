namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kabineti1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kabineti1()
        {
            Kabineta_inventars2 = new HashSet<Kabineta_inventars2>();
            Kabineta_inventars21 = new HashSet<Kabineta_inventars2>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int kabineta_id { get; set; }

        [Required]
        [StringLength(5)]
        public string kabineta_nummurs { get; set; }

        public int skolotajs_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string atrasanas_vieta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineta_inventars2> Kabineta_inventars2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineta_inventars2> Kabineta_inventars21 { get; set; }

        public virtual Lietotaji1 Lietotaji1 { get; set; }

        public virtual Lietotaji1 Lietotaji11 { get; set; }

        public virtual Lietotaji1 Lietotaji12 { get; set; }
    }
}
