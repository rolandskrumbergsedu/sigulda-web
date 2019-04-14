namespace Sigulda.WEB.Contexts.wolverine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Atbildigie")]
    public partial class Atbildigie
    {
        [Key]
        [StringLength(40)]
        public string Vards { get; set; }

        [Column(TypeName = "text")]
        public string Uzvards { get; set; }

        [Column(TypeName = "text")]
        public string Amats { get; set; }
    }
}
