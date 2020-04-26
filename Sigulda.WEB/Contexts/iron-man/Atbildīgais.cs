namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Atbildīgais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Atbildīgā_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Vārds { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Uzvārds { get; set; }
    }
}
