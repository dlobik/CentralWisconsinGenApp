using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Naturalization: Model
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Record Date")]
        public DateTime DateOfRecord { get; set; }
        [DisplayName("Record Type")]
        public string RecordType { get; set; }
        [DisplayName("County of Origin")]
        public string CountryOfOrigin { get; set; }
        [DisplayName("Series: ")]
        public int Series { get; set; }
        [DisplayName("Box: ")]
        public int Box { get; set; }
        [DisplayName("Folder: ")]
        public int Folder { get; set; }
        [DisplayName("Volume: ")]
        public string VolNumber { get; set; }
        [DisplayName("Page Certification: ")]
        public string PageCertNumber { get; set; }
        [DisplayName("Date of Entry")]
        public string DateOfEntry { get; set; }
        [DisplayName("Port of Entry")]
        public string PortOfEntry { get; set; }
        public virtual County CountyID { get; set; }

    }
}