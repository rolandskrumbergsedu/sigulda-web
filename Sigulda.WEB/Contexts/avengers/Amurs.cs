namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Amurs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Amura_ID { get; set; }

        public int kata_garums { get; set; }

        public int galvas_izmers { get; set; }

        [Column(TypeName = "text")]
        public string ipasas_iezimes { get; set; }

        public bool? Bojats { get; set; }

        [StringLength(15)]
        public string Panema { get; set; }
    }
}
