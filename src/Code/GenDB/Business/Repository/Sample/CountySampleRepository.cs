using System;
using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class CountySampleRepository : ICountyRepository
  {
    private IList<County> _models;

    public CountySampleRepository()
    {
      _models = new List<County>() {
        new County() { ID = 1, Name="Portage"},
        new County() { ID = 2,Name="Shawano"},
        new County() { ID = 3,Name="Marathon"},
        new County() { ID = 4, Name="Milwaukee"},
        new County() { ID = 5, Name="Stevens Point"}
      };
    }

    public IEnumerable<County> All()
    {
      return(_models);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }

        public County Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<County> Search(SearchParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}