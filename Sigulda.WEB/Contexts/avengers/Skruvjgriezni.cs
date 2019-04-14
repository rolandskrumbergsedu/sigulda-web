namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skruvjgriezni")]
    public partial class Skruvjgriezni
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Skruvgriezna_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string gals { get; set; }

        public int garums { get; set; }

        [Column(TypeName = "text")]
        public string ipasas_iezimes { get; set; }

        public bool? Bojats { get; set; }

        [StringLength(15)]
        public string Panema { get; set; }
    }
}
