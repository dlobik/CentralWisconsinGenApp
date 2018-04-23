using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GenDB.Models
{
    public class County
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<SelectListItem> Counties { get; set; }
    }
}