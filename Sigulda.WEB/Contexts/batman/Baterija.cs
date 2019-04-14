namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baterija")]
    public partial class Baterija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Baterijas_ID { get; set; }

        [StringLength(10)]
        public string Baterijas_izmērs { get; set; }

        public int? Voltāža_mV { get; set; }

        public int? Skaits_skolā { get; set; }

        public int? Skaits_SJC { get; set; }

        public int? Pasūtītais_skaits { get; set; }

        [StringLength(400)]
        public string Piezīmes { get; set; }

        [StringLength(400)]
        public string Datasheets { get; set; }
    }
}
