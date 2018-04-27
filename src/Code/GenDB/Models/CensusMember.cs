using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class CensusMember : Model
  {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Page { get; set; }
        public virtual Census CensusID { get; set; }

    }
}