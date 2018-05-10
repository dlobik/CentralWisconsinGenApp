using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Obit: Model
  {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Alternate Name")]
        public string AltName { get; set; }
        [DisplayName("Date of Record")]
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }
        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Web Text: ")]
        public string WebText { get; set; }
        public virtual ICollection<Obit> Obits { get; set; }
        public virtual News NewsID { get; set; }
        [DisplayName("County")]
        public int CountyID { get; set; }
        [ForeignKey("CountyID")]public virtual County Counties { get; set; }
        public List<Naturalization> MyNat { get; set; }
    }
}