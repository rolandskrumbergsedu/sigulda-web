namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Viles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Viles_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Veids { get; set; }

        public int izmers { get; set; }

        [Column(TypeName = "text")]
        public string ipasas_iezimes { get; set; }

        public bool? Bojats { get; set; }

        [StringLength(15)]
        public string Panema { get; set; }
    }
}
