using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class PiekabeViewModel
    {
        [Required]
        public int PiekabesID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nosaukums { get; set; }

        public int? Veids { get; set; }

    }
}