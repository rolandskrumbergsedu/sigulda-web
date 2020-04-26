namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Iekarta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IekartasID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nosaukums { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Skaits { get; set; }

        [Required]
        [StringLength(255)]
        public string AtrasanasV { get; set; }

        [Column(TypeName = "image")]
        public byte[] Attels { get; set; }
    }
}
