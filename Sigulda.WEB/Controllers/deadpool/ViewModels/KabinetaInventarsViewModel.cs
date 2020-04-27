using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class KabinetaInventarsViewModel
    {
        [Required]
        public int inventara_kabineta_id { get; set; }

        [Required]
        public int Kabineta_id { get; set; }

        [Required]
        [StringLength(50)]
        public string tipa_kods { get; set; }
    }
}