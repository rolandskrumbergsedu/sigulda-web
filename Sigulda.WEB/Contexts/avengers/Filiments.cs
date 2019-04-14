namespace Sigulda.WEB.Contexts.avengers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Filiments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int filimenta_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string krasa { get; set; }

        [Required]
        [StringLength(30)]
        public string materials { get; set; }

        public int masa { get; set; }
    }
}
