using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.deadpool.ViewModels
{
    public class InventarsViewModel
    {
        public int InventaraID { get; set; }
        
        public string InvNosaukums { get; set; }
        
        public decimal Cena { get; set; }

        public double Nolietojums { get; set; }
        
        public DateTime Datums { get; set; }
    }
}