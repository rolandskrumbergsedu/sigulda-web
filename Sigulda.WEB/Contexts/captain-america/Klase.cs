namespace Sigulda.WEB.Contexts.captain_america
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klase")]
    public partial class Klase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klase()
        {
            Macibu_stunda = new HashSet<MacibuStunda>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Klase_ID { get; set; }

        [Column("Klase")]
        [Required]
        [StringLength(10)]
        public string Klase1 { get; set; }

        public int? Grupa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MacibuStunda> Macibu_stunda { get; set; }
    }
}
