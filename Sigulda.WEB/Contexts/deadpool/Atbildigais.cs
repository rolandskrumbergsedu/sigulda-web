namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Atbildigais
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Atbildigais()
        {
            Kabinets1 = new HashSet<KabinetsWolverine>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AtbildigaisID { get; set; }

        public int? KabinetaID { get; set; }

        [Required]
        [StringLength(50)]
        public string AtbildigaisVards { get; set; }

        [Required]
        [StringLength(50)]
        public string AtbildigaisUzvards { get; set; }

        public virtual KabinetsWolverine Kabinets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KabinetsWolverine> Kabinets1 { get; set; }
    }
}
