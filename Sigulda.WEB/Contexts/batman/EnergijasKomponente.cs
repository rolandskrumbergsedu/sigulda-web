namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enerģijas_komponente")]
    public partial class EnergijasKomponente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Enerģijas_komponente_ID { get; set; }

        public int? Baterijas_ID { get; set; }

        public int? Akumulatora_ID { get; set; }
    }
}
