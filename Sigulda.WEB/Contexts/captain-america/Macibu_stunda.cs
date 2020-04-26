namespace Sigulda.WEB.Contexts.captain_america
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Macibu_stunda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stunda_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Datums { get; set; }

        public int? Stundas_nr { get; set; }

        public int? Prieksmets_ID { get; set; }

        public int? Klase_ID { get; set; }

        [StringLength(150)]
        public string Piezime { get; set; }

        public int? Tema_ID { get; set; }

        [StringLength(20)]
        public string Kabineta_nr { get; set; }

        public virtual Klase Klase { get; set; }

        public virtual Macibu_prieksmets Macibu_prieksmets { get; set; }

        public virtual StundasTema StundasTema { get; set; }
    }
}
