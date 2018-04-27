using System;
using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository
{
  public interface INaturalizationRepository : IDisposable
  {
    IEnumerable<Naturalization> All();
    Naturalization Get(int id);
    IEnumerable<Naturalization> Search(SearchParameters parameters);
  }
}