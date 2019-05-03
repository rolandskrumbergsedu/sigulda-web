namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gatavā_shēma_modulis")]
    public partial class GatavaShemaModulis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Gatavā_shēma_moduļa_ID { get; set; }

        [StringLength(50)]
        public string Nosaukums { get; set; }

        [StringLength(50)]
        public string Pielietojums { get; set; }

        public int? Daudzums_skolā { get; set; }

        public int? Daudzums_SJC { get; set; }

        public int? Pasūtītais_daudzums { get; set; }

        [StringLength(400)]
        public string Piezīmes { get; set; }

        [StringLength(400)]
        public string Links { get; set; }
    }
}
