using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class PasutijumiViewModel
    {
        [Required]
        public int Pas_ID { get; set; }

        public int Klients { get; set; }

        public int Laivu_veids { get; set; }

        public decimal Laivu_daudzums { get; set; }

        public int Soferis { get; set; }

        public DateTime? Ires_sakums { get; set; }

        public DateTime? Ires_beigas { get; set; }
    }
}