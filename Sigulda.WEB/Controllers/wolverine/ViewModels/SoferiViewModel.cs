using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.wolverine.ViewModels
{
    public class SoferiViewModel
    {
        [Required]
        public int SoferaID { get; set; }

        [Required]
        [StringLength(20)]
        public string Vards { get; set; }

        [Required]
        [StringLength(20)]
        public string Uzvards { get; set; }

        public decimal Telefona_nr { get; set; }

        public int Transports { get; set; }
    }
}