namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Komponente")]
    public partial class Komponente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Komponente_ID { get; set; }

        public int Pasīvā_komponente_ID { get; set; }

        public int Sensora_ID { get; set; }

        public int Elektromehāniskā_komponente_ID { get; set; }

        public int Gatavā_shēma_modulis_ID { get; set; }

        public int Aktīvās_komponentes_ID { get; set; }
    }
}
