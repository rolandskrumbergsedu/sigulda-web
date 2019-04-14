namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vadi")]
    public partial class Vadi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vadi_ID { get; set; }

        [StringLength(50)]
        public string Vada_tips { get; set; }

        [StringLength(50)]
        public string Vada_mērķis { get; set; }

        [StringLength(20)]
        public string Krāsa { get; set; }

        public int? AWG { get; set; }

        public int? Daudzums_skolā { get; set; }

        public int? Daudzums_SJC { get; set; }

        public int? Pasūtītais_daudzums { get; set; }

        [StringLength(400)]
        public string Piezīmes { get; set; }
    }
}
