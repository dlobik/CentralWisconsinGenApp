using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.EntityFramework
{
    public class CountyEntityFrameworkRepository : ICountyRepository
    {
        private readonly GenContext _context;
        private DbSet<County> _county;

        public CountyEntityFrameworkRepository(GenContext context)
        {
            if (context == null) throw new ArgumentException("Empty or null context provided.", "context");
            _context = context;
            _county = context.County;
        }

        public IEnumerable<County> All()
        {
            return (_county);
        }

        public IEnumerable<County> Search(SearchParameters parameters)
        {
            County[] results = null;
            if (parameters == null) results = _county.ToArray();
            else
            {
                var query = _county.AsQueryable();

                // WATCH OUT FOR SQL INJECTION
                //if (!String.IsNullOrWhiteSpace(parameters.FirstName))
                //{
                //    query = query.Where(p => DbFunctions.Like(p.Name, parameters.Name));
                //}       
                //results = query.ToArray();
            }
            return (results);
        }

        public County Get(int id)
        {
            return (_county.FirstOrDefault(c => c.ID == id));
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}