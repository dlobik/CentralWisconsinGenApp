using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.EntityFramework
{
    public class ObituaryEntityFrameworkRepository : IObituaryRepository
    {
        private readonly GenContext _context;
        private DbSet<Obit> _obituaries;

        public ObituaryEntityFrameworkRepository(GenContext context)
        {
            if (context == null) throw new ArgumentException("Empty or null context provided.", "context");
            _context = context;
            _obituaries = context.Obit;
        }

        public IEnumerable<Obit> All()
        {
            return (_obituaries);
        }

        public IEnumerable<Obit> Search(SearchParameters parameters)
        {
            Obit[] results = null;
            if (parameters == null) results = _obituaries.ToArray();
            else
            {
                var query = _obituaries.AsQueryable();

                // WATCH OUT FOR SQL INJECTION
                if (!String.IsNullOrWhiteSpace(parameters.FirstName))
                {
                    query = query.Where(p => DbFunctions.Like(p.FirstName, parameters.FirstName));
                }
                if (!String.IsNullOrWhiteSpace(parameters.LastName))
                {
                    query = query.Where(p => DbFunctions.Like(p.LastName, parameters.LastName));
                }
                if (!String.IsNullOrWhiteSpace(parameters.AltName))
                {
                    query = query.Where(p => DbFunctions.Like(p.AltName, parameters.AltName));
                }
                if (!String.IsNullOrWhiteSpace(parameters.EventYear.ToString()))
                {
                    query = query.Where(p => p.DateOfRecord.Year == parameters.EventYear);
                }
                if (!String.IsNullOrWhiteSpace(parameters.County))
                {
                    query = query.Where(p => p.CountyID.ToString() == parameters.County);
                }
                results = query.ToArray();
            }
            return (results);
        }

        public Obit Get(int id)
        {
            return (_obituaries.FirstOrDefault(n => n.ID == id));
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