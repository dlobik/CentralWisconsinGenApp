using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class Naturalization
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }
        public string RecordType { get; set; }
        public string CountryOfOrigin { get; set; }
        public int Series { get; set; }
        public int Box { get; set; }
        public int Folder { get; set; }
        public string VolNumber { get; set; }
        public string PageCertNumber { get; set; }
        public string DateOfEntry { get; set; }
        public string PortOfEntry { get; set; }
        public virtual County CountyID { get; set; }

    }
}