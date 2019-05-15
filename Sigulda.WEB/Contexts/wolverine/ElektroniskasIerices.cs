namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Elektroniskas_ierices")]
    public partial class ElektroniskasIericesWolverine
    {
        [StringLength(50)]
        public string pirksanas_datums { get; set; }

        [StringLength(50)]
        public string cena { get; set; }

        [StringLength(50)]
        public string datums { get; set; }

        [Key]
        [StringLength(50)]
        public string vertiba { get; set; }

        [StringLength(20)]
        public string Ierice_ID { get; set; }
    }
}
