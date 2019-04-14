namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mebeles
    {
        [StringLength(30)]
        public string MebelesID { get; set; }

        [Required]
        [StringLength(40)]
        public string Mebeles_Veids { get; set; }

        public int? Pirksanas_datums { get; set; }

        public int? Cena { get; set; }

        public int? Datums { get; set; }

        public int Vertiba { get; set; }
    }
}
