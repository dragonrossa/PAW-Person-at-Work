using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadniSati.Models
{
    public class FruitModel
    {
        public List<SelectListItem> Projects { get; set; }
        public int? ProjektId { get; set; }
       
    }
}