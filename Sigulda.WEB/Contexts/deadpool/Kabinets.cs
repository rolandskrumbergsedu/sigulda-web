namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kabinets")]
    public partial class KabinetsWolverine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KabinetsWolverine()
        {
            Atbildigais = new HashSet<Atbildigais>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KabinetaID { get; set; }

        public int? InventaraID { get; set; }

        public int? AtbildigaisID { get; set; }

        public int? IericesID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atbildigais> Atbildigais { get; set; }

        public virtual Atbildigais Atbildigais1 { get; set; }

        public virtual ElektroniskasIericesDeadpool ElektroniskasIerices { get; set; }

        public virtual Inventars Inventars { get; set; }

        public virtual Inventars Inventars1 { get; set; }
    }
}
