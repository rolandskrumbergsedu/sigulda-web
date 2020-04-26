namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soferi")]
    public partial class Soferi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Soferi()
        {
            Pasutijumis = new HashSet<Pasutijumi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoferaID { get; set; }

        [Required]
        [StringLength(20)]
        public string Vards { get; set; }

        [Required]
        [StringLength(20)]
        public string Uzvards { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Telefona_nr { get; set; }

        public int Transports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasutijumi> Pasutijumis { get; set; }

        public virtual Transportlidzekli Transportlidzekli { get; set; }
    }
}
