namespace Sigulda.WEB.Contexts.iron_man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reagenti")]
    public partial class Reagenti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reagenti_ID { get; set; }

        public string Nosaukums { get; set; }

        [StringLength(50)]
        public string Formula { get; set; }

        public int? Skaits { get; set; }

        [MaxLength(1)]
        public byte[] Stadija { get; set; }
    }
}
