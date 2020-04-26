namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Objekt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Objekta_ID { get; set; }

        public int Objekta_NR { get; set; }

        public int Objekta_Cena { get; set; }

        public int Objekta_Termiņš { get; set; }

        public int Objekta_Daudzums { get; set; }

        [Column(TypeName = "date")]
        public DateTime Iegādes_Laiks { get; set; }

        public int Kabineta_ID { get; set; }
    }
}
