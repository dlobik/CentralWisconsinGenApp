using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Census: Model
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }
        public string Page { get; set; }
        public string Town { get; set; }
        public virtual County CountyID { get; set; }



    }
}