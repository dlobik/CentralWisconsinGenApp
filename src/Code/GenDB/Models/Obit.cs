using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Obit: Model
  {
        public int ID { get; set; }
        public string FirstName { get; set; }
        //public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AltName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string WebText { get; set; }
        public virtual ICollection<Obit> Obits { get; set; }
        public virtual News NewsID { get; set; }
        public virtual County CountyID { get; set; }
        public List<Naturalization> MyNat { get; set; }
    }
}