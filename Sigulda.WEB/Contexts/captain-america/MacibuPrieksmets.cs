namespace Sigulda.WEB.Contexts.captain_america
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Macibu_prieksmets")]
    public partial class MacibuPrieksmets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MacibuPrieksmets()
        {
            Macibu_stunda = new HashSet<MacibuStunda>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prieksmets_ID { get; set; }

        [StringLength(50)]
        public string Stundas_nosaukums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MacibuStunda> Macibu_stunda { get; set; }
    }
}
