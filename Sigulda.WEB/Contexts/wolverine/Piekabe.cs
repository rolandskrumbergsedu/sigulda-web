namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Piekabe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Piekabe()
        {
            Transportlidzeklis = new HashSet<Transportlidzekli>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PiekabesID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nosaukums { get; set; }

        public int? Veids { get; set; }

        public virtual Piekabes_veids Piekabes_veids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportlidzekli> Transportlidzeklis { get; set; }
    }
}
