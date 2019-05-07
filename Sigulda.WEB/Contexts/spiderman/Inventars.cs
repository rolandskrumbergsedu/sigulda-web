namespace Sigulda.WEB.Contexts.spiderman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventars1")]
    public partial class Inventars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Inventars_ID { get; set; }

        public int Galdi_ID { get; set; }

        public int Monitori_ID { get; set; }

        public int Kresli_ID { get; set; }

        public int Tafeles_ID { get; set; }

        public int Citi_ID { get; set; }
    }
}
