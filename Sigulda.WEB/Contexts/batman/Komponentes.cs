namespace Sigulda.WEB.Contexts.batman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Komponentes")]
    public partial class Komponentes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Enerģijas_komponente_ID { get; set; }

        public int Vadi_ID { get; set; }

        public int Komponente_ID { get; set; }
    }
}
