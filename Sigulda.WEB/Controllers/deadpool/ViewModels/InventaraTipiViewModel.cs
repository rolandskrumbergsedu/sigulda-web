using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class InventaraTipiViewModel
    {
        [Required]
        [StringLength(50)]
        public string tipa_id { get; set; }

        [Required]
        public string nosaukums { get; set; }

        [StringLength(200)]
        public string Apraksts { get; set; }
    }
}