namespace Sigulda.WEB.Contexts.captain_america
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StundasTema")]
    public partial class StundasTema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StundasTema()
        {
            Macibu_stunda = new HashSet<MacibuStunda>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tema_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Tema { get; set; }

        [StringLength(100)]
        public string Piezime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MacibuStunda> Macibu_stunda { get; set; }
    }
}
