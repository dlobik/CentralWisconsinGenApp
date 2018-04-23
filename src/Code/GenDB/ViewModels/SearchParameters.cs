using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenDB.ViewModels
{
    public class SearchParameters
    {
        [DisplayName("First Name:  ")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:  ")]
        public string LastName { get; set; }
        [DisplayName("Alternate Name:  ")]
        public string AltName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Record:  ")]
        public DateTime DateOfRecord { get; set; }
        [DisplayName("County:  ")]
        public string County { get; set; }
    }
}