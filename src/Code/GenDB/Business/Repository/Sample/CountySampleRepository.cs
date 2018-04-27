﻿using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class CountySampleRepository : ICountyRepository
  {
    private IList<County> _models;

    public CountySampleRepository()
    {
      _models = new List<County>() {
        new County() { ID = 97, Name="Portage"},
        new County() { ID = 115,Name="Shawano"},
        new County() { ID = 073,Name="Marathon"},
        new County() { ID = 079, Name="Milwaukee"}
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
  }
}