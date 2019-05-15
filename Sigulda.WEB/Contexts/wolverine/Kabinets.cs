namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kabineti")]
    public partial class Kabineti
    {
        [StringLength(20)]
        public string KabinetaID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string Elektronika { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string Mebeles { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string Atbildigie { get; set; }
    }
}
