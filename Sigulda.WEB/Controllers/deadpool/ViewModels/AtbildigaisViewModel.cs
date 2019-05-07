using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class AtbildigaisViewModel
    {
        public int AtbildigaisID { get; set; }

        public string AtbildigaisVards { get; set; }

        public string AtbildigaisUzvards { get; set; }

        public int? KabinetaID { get; set; }
    }
}