namespace Sigulda.WEB.Contexts.deadpool
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kabineta_inventars2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int inventara_kabineta_id { get; set; }

        public int Kabineta_id { get; set; }

        [Required]
        [StringLength(50)]
        public string tipa_kods { get; set; }

        public virtual inventara_tipi2 inventara_tipi2 { get; set; }

        public virtual Kabineti1 Kabineti1 { get; set; }

        public virtual Kabineti1 Kabineti11 { get; set; }
    }
}
