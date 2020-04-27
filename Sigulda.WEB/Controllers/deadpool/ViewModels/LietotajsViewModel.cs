using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class LietotajsViewModel
    {
        [Required]
        public int lietotajs_id { get; set; }

        [StringLength(60)]
        public string epasts { get; set; }

        [Required]
        [StringLength(15)]
        public string vards { get; set; }

        [Required]
        [StringLength(25)]
        public string uzvards { get; set; }

        [Required]
        [StringLength(30)]
        public string parole { get; set; }

        [Required]
        [StringLength(12)]
        public string personas_kods { get; set; }

        public bool skolotajs { get; set; }
    }
}