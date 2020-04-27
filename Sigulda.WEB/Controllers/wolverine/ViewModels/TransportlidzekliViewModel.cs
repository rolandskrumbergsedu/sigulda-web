using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class TransportlidzekliViewModel
    {
        [Required]
        public int TransportaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ipasnieks { get; set; }

        [Required]
        [StringLength(30)]
        public string Marka { get; set; }

        [Required]
        [StringLength(30)]
        public string Modelis { get; set; }

        public decimal Gads { get; set; }

        public decimal Max_cilv_ietilpiba { get; set; }

        public decimal Max_airu_ietilpiba { get; set; }

        public decimal Max_vestu_ietilpiba { get; set; }

        public int PIekabe { get; set; }

        public decimal Numurzime { get; set; }
    }
}