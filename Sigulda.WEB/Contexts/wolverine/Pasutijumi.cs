namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pasutijumi")]
    public partial class Pasutijumi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pas_ID { get; set; }

        public int Klients { get; set; }

        public int Laivu_veids { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Laivu_daudzums { get; set; }

        public int Soferis { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ires_sakums { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ires_beigas { get; set; }

        public virtual Klienti Klienti { get; set; }

        public virtual Laiva Laiva { get; set; }

        public virtual Laiva Laiva1 { get; set; }

        public virtual Soferi Soferi { get; set; }
    }
}
