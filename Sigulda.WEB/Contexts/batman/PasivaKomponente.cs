namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pasīvā_komponente")]
    public partial class PasivaKomponente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pasīvā_komponente_ID { get; set; }

        [StringLength(50)]
        public string Komponentes_tips { get; set; }

        [StringLength(50)]
        public string Komponentes_nosaukums { get; set; }

        [StringLength(20)]
        public string Footprint { get; set; }

        [StringLength(50)]
        public string Pirmās_Vērtības_nosaukums { get; set; }

        public int? Pirmā_Vērtība { get; set; }

        [StringLength(50)]
        public string Otrās_Vērtības_nosaukums { get; set; }

        public int? Otrā_Vērtība { get; set; }

        [StringLength(50)]
        public string Trešās_Vērtības_nosaukums { get; set; }

        public int? Trešā_Vērtība { get; set; }

        public int? Daudzums_skolā { get; set; }

        public int? Daudzums_SJC { get; set; }

        public int? Pasūtītais_daudzums { get; set; }

        [StringLength(400)]
        public string Piezīmes { get; set; }

        [StringLength(400)]
        public string Datasheets { get; set; }
    }
}
