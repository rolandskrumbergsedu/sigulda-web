using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class LaivaViewModel
    {
        [Required]
        public int LaivasID { get; set; }

        [Required]
        [StringLength(20)]
        public string Nosaukums { get; set; }

        public int Veids { get; set; }

        public decimal Skaits { get; set; }
    }
}