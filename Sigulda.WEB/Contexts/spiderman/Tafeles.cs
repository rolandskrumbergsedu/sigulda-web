namespace Sigulda.WEB.Contexts.spiderman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tafeles
    {
        [StringLength(50)]
        public string Kabinets { get; set; }

        [StringLength(50)]
        public string Cena { get; set; }

        [StringLength(50)]
        public string Skaits { get; set; }

        [StringLength(50)]
        public string Nolietojums { get; set; }

        [StringLength(50)]
        public string Pircējs { get; set; }

        [StringLength(50)]
        public string Garantija { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tafeles_ID { get; set; }
    }
}
