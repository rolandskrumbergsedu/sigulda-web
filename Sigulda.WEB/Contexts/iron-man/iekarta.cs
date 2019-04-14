namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class iekarta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Iekartas_ID { get; set; }

        [StringLength(50)]
        public string Nosaukums { get; set; }

        public int? Skaits { get; set; }
    }
}
