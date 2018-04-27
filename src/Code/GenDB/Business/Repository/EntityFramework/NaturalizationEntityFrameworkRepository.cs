using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.EntityFramework
{
  public class NaturalizationEntityFrameworkRepository : INaturalizationRepository
  {
    private readonly GenContext _context;
    private DbSet<Naturalization> _naturalizations;

    public NaturalizationEntityFrameworkRepository(GenContext context)
    {
      if (context == null) throw new ArgumentException("Empty or null context provided.", "context");
      _context = context;
      _naturalizations = context.Naturalization;
    }

    public IEnumerable<Naturalization> All()
    {
      return(_naturalizations);
    }

    public IEnumerable<Naturalization> Search(SearchParameters parameters)
    {
      Naturalization[] results = null;
      if (parameters == null) results = _naturalizations.ToArray();
      else {
        var query = _naturalizations.AsQueryable();

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

    public Naturalization Get(int id)
    {
      return(_naturalizations.FirstOrDefault(n => n.ID == id));
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