using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class News: Model
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Abbr { get; set; }
        public string URL { get; set; }

    }
}