namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Akumulators
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Akumulatora_ID { get; set; }

        [StringLength(10)]
        public string Akumulatora_tips { get; set; }

        [StringLength(50)]
        public string Ražotājs_nosaukums { get; set; }

        public int? Ietilpība_mAh { get; set; }

        public decimal? Voltāža_V { get; set; }

        public int? Svars_g { get; set; }

        public int? Izmērs_a_mm { get; set; }

        public int? Izmērs_b_mm { get; set; }

        public int? Izmērs_c_mm { get; set; }

        public int? Skaits_skolā { get; set; }

        public int? Skaits_SJC { get; set; }

        public int? Pasūtītais_skaits { get; set; }

        [StringLength(400)]
        public string Piezīmes { get; set; }

        [StringLength(400)]
        public string Datasheets { get; set; }
    }
}
