using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigulda.WEB.Controllers.captain_america.ViewModels
{
    public class MacibuStundaViewModel
    {
        public int Stunda_ID { get; set; }
        
        public DateTime? Datums { get; set; }

        public int? Stundas_nr { get; set; }

        public int? Prieksmets_ID { get; set; }

        public int? Klase_ID { get; set; }
        
        public string Piezime { get; set; }

        public int? Tema_ID { get; set; }
        
        public string Kabineta_nr { get; set; }
    }
}