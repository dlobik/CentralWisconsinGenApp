using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Census: Model
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Record Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }
        [DisplayName("Page")]
        public string Page { get; set; }
        [DisplayName("Town")]
        public string Town { get; set; }
        [DisplayName("County")]
        public int CountyID { get; set; }
        [ForeignKey("CountyID")] public virtual County Counties { get; set; }



    }
}