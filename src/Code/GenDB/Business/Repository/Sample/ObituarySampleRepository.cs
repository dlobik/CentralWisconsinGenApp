using System;
using System.Collections.Generic;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class ObituarySampleRepository : IObituaryRepository
  {
    private IList<Obit> _models;

    public ObituarySampleRepository()
    {
      _models = new List<Obit>() {
            new Obit{ID = 1, FirstName="Carson", LastName="Alexander", AltName="Colgy", DateOfRecord=DateTime.Parse("2009-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 1",},
            new Obit{ID = 2, FirstName="Bill", LastName="Bango", AltName="Couy", DateOfRecord=DateTime.Parse("2004-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 2"},
            new Obit{ID = 3, FirstName="Craig", LastName="Qwerty", AltName="Cooy", DateOfRecord=DateTime.Parse("2012-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 3"},
            new Obit{ID = 4, FirstName="Charles", LastName="Zippy", AltName="Coogu", DateOfRecord=DateTime.Parse("2010-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 4"},
            new Obit{ID = 5, FirstName="Franksrson", LastName="Myre", AltName="Coguy", DateOfRecord=DateTime.Parse("2011-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 5"},
            new Obit{ID = 6, FirstName="Dirty", LastName="Dave", AltName="Clgy", DateOfRecord=DateTime.Parse("2002-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 6"},
            new Obit{ID = 7, FirstName="Big Dave", LastName="Dancer", AltName="Cguy", DateOfRecord=DateTime.Parse("2011-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 7"},
            new Obit{ID = 8, FirstName="Bye", LastName="Lalala", AltName="Coguy", DateOfRecord=DateTime.Parse("2022-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 8"},
      };
    }

    public IEnumerable<Obit> All()
    {
      return(_models);
    }

    public Obit Get(int id)
    {
      return (_models.FirstOrDefault(m => m.ID == id));
    }

    public IEnumerable<Obit> Search(SearchParameters parameters)
    {
      return (_models);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
  }
}