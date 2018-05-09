using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.EntityFramework
{
  public class CensusMemberEntityFrameworkRepository : ICensusMemberRepository
  {
    private readonly GenContext _context;
    private DbSet<CensusMember> _censusMember;

    public CensusMemberEntityFrameworkRepository(GenContext context)
    {
      if (context == null) throw new ArgumentException("Empty or null context provided.", "context");
      _context = context;
      _censusMember = context.CensusMember;
    }

    public IEnumerable<CensusMember> All()
    {
      return (_censusMember);
    }

    public IEnumerable<CensusMember> Search(SearchParameters parameters)
    {
      CensusMember[] results = null;
      if (parameters == null) results = _censusMember.ToArray();
      else {
        var query = _censusMember.AsQueryable();

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

    public CensusMember Get(int id)
    {
      return(_censusMember.FirstOrDefault(c => c.ID == id));
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