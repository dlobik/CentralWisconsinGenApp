using System;
using System.Collections.Generic;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class CensusMemberSampleRepository: ICensusMemberRepository
  {
    private IList<CensusMember> _models;

    public CensusMemberSampleRepository()
    {
      _models = new List<CensusMember>() {
        new CensusMember { ID = 10, FirstName = "Charles", LastName = "Smith", Age = 11, Page = "24B",},
        new CensusMember { ID = 20, FirstName = "Samuel", LastName = "Brown", Age = 100, Page = "123",},
        new CensusMember { ID = 30, FirstName = "Tyler", LastName = "Miller", Age = 2, Page = "11B",},
        new CensusMember { ID = 40, FirstName = "Henry", LastName = "Johnson", Age = 5, Page = "11A",},
        new CensusMember { ID = 50, FirstName = "George", LastName = "Jones", Age = 70, Page = "123",},
        new CensusMember { ID = 60, FirstName = "Sarah", LastName = "Davis", Age = 20, Page = "66",},
        new CensusMember { ID = 70, FirstName = "Elizabeth", LastName = "Williams", Age = 16, Page = "501",},
        new CensusMember { ID = 80, FirstName = "Mary", LastName = "Wilson", Age = 1, Page = "AB2",},
        new CensusMember { ID = 90, FirstName = "Taylor", LastName = "Clark", Age = 55, Page = "213",},
      };
    }

    public IEnumerable<CensusMember> All()
    {
      return(_models);
    }

    public CensusMember Get(int id)
    {
      return (_models.FirstOrDefault(m => m.ID == id));
    }

    public IEnumerable<CensusMember> Search(SearchParameters parameters)
    {
      return (_models);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
  }
}