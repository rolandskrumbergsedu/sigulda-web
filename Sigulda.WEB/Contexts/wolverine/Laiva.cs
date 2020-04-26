namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Laiva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laiva()
        {
            Pasutijumis = new HashSet<Pasutijumi>();
            Pasutijumis1 = new HashSet<Pasutijumi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LaivasID { get; set; }

        [Required]
        [StringLength(20)]
        public string Nosaukums { get; set; }

        public int Veids { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Skaits { get; set; }

        public virtual Laivu_veidi Laivu_veidi { get; set; }

        public virtual Laivu_veidi Laivu_veidi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasutijumi> Pasutijumis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasutijumi> Pasutijumis1 { get; set; }
    }
}
