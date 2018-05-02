using System.Collections.Generic;
using GenDB.Models;
using System;

namespace GenDB.Business.Repository
{
  public interface ICountyRepository : IDisposable
  {
    IEnumerable<County> All();
    County Get(int id);
    IEnumerable<County> Search(SearchParameters parameters);
    }
}