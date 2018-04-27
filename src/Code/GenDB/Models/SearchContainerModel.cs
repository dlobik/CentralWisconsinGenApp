using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenDB.Models
{
    public class SearchContainerModel: Model
  {

        /* Trying to figure out of if possible to search all 3 tables from one controller method and return a container 
         * of the results, then populate individual parital views based off of data in containers / model
         */
        public SearchContainerModel(List<Obit> obits, List<Census> censuses, List<Naturalization> nat)
        {
            ObituarySearch = obits;
            CensusSearch = censuses;
            NaturalizationSearch = nat;
        }

        public List<Obit> ObituarySearch { get; set; }
        public List<Census> CensusSearch { get; set; }
        public List<Naturalization> NaturalizationSearch { get; set; }
    }
}