using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class LaivuVeidiViewModel
    {
        [Required]
        public int LVID { get; set; }

        [Required]
        [StringLength(20)]
        public string Veida_nosaukums { get; set; }

        public decimal Cilv_ietilpiba { get; set; }

        public decimal Airi { get; set; }
    }
}