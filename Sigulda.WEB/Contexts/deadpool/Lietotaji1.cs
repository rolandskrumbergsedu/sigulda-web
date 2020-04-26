namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lietotaji1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lietotaji1()
        {
            Kabineti1 = new HashSet<Kabineti1>();
            Kabineti11 = new HashSet<Kabineti1>();
            Kabineti12 = new HashSet<Kabineti1>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lietotajs_id { get; set; }

        [StringLength(60)]
        public string epasts { get; set; }

        [Required]
        [StringLength(15)]
        public string vards { get; set; }

        [Required]
        [StringLength(25)]
        public string uzvards { get; set; }

        [Required]
        [StringLength(30)]
        public string parole { get; set; }

        [Required]
        [StringLength(12)]
        public string personas_kods { get; set; }

        public bool skolotajs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineti1> Kabineti1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineti1> Kabineti11 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabineti1> Kabineti12 { get; set; }
    }
}
