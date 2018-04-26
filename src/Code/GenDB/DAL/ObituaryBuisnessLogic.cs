using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.DAL
{
    public class ObituaryBuisnessLogic
    {
        private GenContext Context;
        public ObituaryBuisnessLogic()
        {
            Context = new GenContext();
        }

        public IEnumerable<Obit> Search(SearchParameters parameters)
        {
            var result = Context.Obit.AsQueryable();

            if (parameters != null)
            {

                if (!string.IsNullOrEmpty(parameters.FirstName))
                {
                    result = result.Where(x => x.FirstName.Contains(parameters.FirstName));
                }
                if (!string.IsNullOrEmpty(parameters.LastName))
                {
                    result = result.Where(x => x.LastName.Contains(parameters.LastName));
                }
                if (!string.IsNullOrEmpty(parameters.AltName))
                {
                    result = result.Where(x => x.AltName.Contains(parameters.LastName));
                }
            }
            return result;
        }    
    }
}