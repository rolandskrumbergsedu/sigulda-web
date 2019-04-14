namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materials")]
    public partial class Materiali
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Materiala_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Materials { get; set; }

        public int Bieziums { get; set; }

        [Column(TypeName = "text")]
        public string iezimes { get; set; }

        public int? Garums { get; set; }

        public int? Platums { get; set; }

        public int? Laukums { get; set; }
    }
}
