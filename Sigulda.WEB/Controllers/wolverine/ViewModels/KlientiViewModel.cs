using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class KlientiViewModel
    {
        [Required]
        public int Klienta_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Klienta_vards { get; set; }

        [Required]
        [StringLength(50)]
        public string Klienta_uzvards { get; set; }

        public decimal telefons { get; set; }

        [Required]
        [StringLength(100)]
        public string e_pasts { get; set; }
    }
}