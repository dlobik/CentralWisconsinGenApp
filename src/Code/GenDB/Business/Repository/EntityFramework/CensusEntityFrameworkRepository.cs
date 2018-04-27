using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Business.Repository.EntityFramework
{
  public class CensusEntityFrameworkRepository : ICensusRepository
  {
    private readonly GenContext _context;
    private DbSet<Census> _census;

    public CensusEntityFrameworkRepository(GenContext context)
    {
      if (context == null) throw new ArgumentException("Empty or null context provided.", "context");
      _context = context;
      _census = context.Census;
    }

    public IEnumerable<Census> All()
    {
      return (_census);
    }

    public IEnumerable<Census> Search(SearchParameters parameters)
    {
      Census[] results = null;
      if (parameters == null) results = _census.ToArray();
      else {
        var query = _census.AsQueryable();

        // WATCH OUT FOR SQL INJECTION
        if (!String.IsNullOrWhiteSpace(parameters.FirstName)) {
          query = query.Where(p => DbFunctions.Like(p.FirstName, parameters.FirstName));
        }
        if (!String.IsNullOrWhiteSpace(parameters.LastName)) {
          query = query.Where(p => DbFunctions.Like(p.LastName, parameters.LastName));
        }
        results = query.ToArray();
      }
      return (results);
    }

    public Census Get(int id)
    {
      return(_census.FirstOrDefault(c => c.ID == id));
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
      if (_context != null) {
        _context.Dispose();
      }
    }
  }
}