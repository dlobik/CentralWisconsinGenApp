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
            new Obit{ID = 1, FirstName="Carson", LastName="Alexander", AltName="Alex", DateOfRecord=DateTime.Parse("2001-04-15"), BirthDate="12/21/15", Age=10, CountyID=1, WebText="Web Text 1",},
            new Obit{ID = 2, FirstName="Brayden", LastName="West", AltName="Bray", DateOfRecord=DateTime.Parse("2004-02-08"), BirthDate="5/16/15", Age=100, CountyID=2, WebText="Web Text 2"},
            new Obit{ID = 3, FirstName="Levi", LastName="Griffin", AltName="Griff", DateOfRecord=DateTime.Parse("2012-05-05"), BirthDate="4/19/15", Age=22, CountyID=3, WebText="Web Text 3"},
            new Obit{ID = 4, FirstName="Charles", LastName="Hayes", AltName="Charlie", DateOfRecord=DateTime.Parse("2010-09-18"), BirthDate="6/22/15", Age=54, CountyID=4, WebText="Web Text 4"},
            new Obit{ID = 5, FirstName="Sebastian", LastName="Woods", AltName="Woody", DateOfRecord=DateTime.Parse("2011-11-20"), BirthDate="9/25/15", Age=19, CountyID=5, WebText="Web Text 5"},
            new Obit{ID = 6, FirstName="Christian", LastName="Dave", AltName="Chris", DateOfRecord=DateTime.Parse("2002-10-11"), BirthDate="7/20/15", Age=28, CountyID=1, WebText="Web Text 6"},
            new Obit{ID = 7, FirstName="Andrew", LastName="Dancer", AltName="Drew", DateOfRecord=DateTime.Parse("2001-01-15"), BirthDate="2/15/15", Age=52, CountyID=2, WebText="Web Text 7"},
            new Obit{ID = 8, FirstName="Cameron", LastName="Burns", AltName="Cam", DateOfRecord=DateTime.Parse("2022-07-22"), BirthDate="3/11/15", Age=74, CountyID=3, WebText="Web Text 8"},
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