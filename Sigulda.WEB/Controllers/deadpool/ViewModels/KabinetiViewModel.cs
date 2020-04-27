using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class KabinetiViewModel
    {
        [Required]
        public int kabineta_id { get; set; }

        [Required]
        [StringLength(5)]
        public string kabineta_nummurs { get; set; }

        public int skolotajs_id { get; set; }

        [Required]
        public string atrasanas_vieta { get; set; }
    }
}