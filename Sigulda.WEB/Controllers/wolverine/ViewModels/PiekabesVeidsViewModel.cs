using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class PiekabesVeidsViewModel
    {
        [Required]
        public int PVID { get; set; }

        [Required]
        [StringLength(30)]
        public string Veida_nosaukums { get; set; }

        public decimal Max_kajaku_ietilpiba { get; set; }

        public decimal Max_kanoe_ietilpiba { get; set; }

        public decimal Max_piep_ietilpiba { get; set; }

        public decimal Max_supdelu_ietilpiba { get; set; }
    }
}