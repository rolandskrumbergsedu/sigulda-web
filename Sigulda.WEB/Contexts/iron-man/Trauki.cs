namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trauki")]
    public partial class Trauki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Trauki_ID { get; set; }

        public int? Skaits { get; set; }

        [StringLength(50)]
        public string Nosaukums { get; set; }
    }
}
