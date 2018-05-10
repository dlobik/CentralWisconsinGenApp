using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GenDB.Models
{
  public class SearchParameters: Model
  {
        [DisplayName("First Name:  ")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:  ")]
        public string LastName { get; set; }
        [DisplayName("Alternate Name:  ")]
        public string AltName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Event Year:  ")]
        public int EventYear { get; set; }
        [DisplayName("County:  ")]
        public string County { get; set; }
        public IEnumerable<SelectListItem> Counties { get; set; }

    }
}