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
        new CensusMember { ID = 1, FirstName = "what", LastName = "yaaaaeeee", Age = 11, Page = "24B",},
        new CensusMember { ID = 2, FirstName = "you", LastName = "thisisfun", Age = 100, Page = "123",},
        new CensusMember { ID = 3, FirstName = "chicken", LastName = "sandwich", Age = 2, Page = "11B",},
        new CensusMember { ID = 4, FirstName = "egg", LastName = "chicken", Age = 5, Page = "11A",},
        new CensusMember { ID = 5, FirstName = "cow", LastName = "yummy", Age = 70, Page = "123",},
        new CensusMember { ID = 6, FirstName = "milk", LastName = "pizzaslice", Age = 20, Page = "66",},
        new CensusMember { ID = 7, FirstName = "goat", LastName = "baby", Age = 16, Page = "501",},
        new CensusMember { ID = 8, FirstName = "sheep", LastName = "waterbottle", Age = 1, Page = "AB2",},
        new CensusMember { ID = 9, FirstName = "monster", LastName = "energy", Age = 55, Page = "213",},
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