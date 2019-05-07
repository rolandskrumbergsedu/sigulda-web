using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class ElektroniskasIericesViewModel
    {
        public int IericesID { get; set; }

        public double? IericesNolietojums { get; set; }
        
        public DateTime? Datums { get; set; }
        
        public decimal IericesCena { get; set; }
        
        public string IericesNosaukums { get; set; }
    }
}