namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kabinet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kabineta_ID { get; set; }

        public int Kabineta_NR { get; set; }

        public int Atbildīgā_ID { get; set; }
    }
}
