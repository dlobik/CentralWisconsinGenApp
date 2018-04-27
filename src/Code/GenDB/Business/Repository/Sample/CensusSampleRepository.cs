using System;
using System.Collections.Generic;
using System.Linq;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Business.Repository.Sample
{
  public class CensusSampleRepository: ICensusRepository
  {
    private IList<Census> _models;

    public CensusSampleRepository()
    {
      _models = new List<Census>() {
        new Census { ID = 1, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 2, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 3, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 4, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 5, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 6, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 7, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 8, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 9, FirstName = "Hello", LastName = "Billy", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
      };
    }

    public IEnumerable<Census> All()
    {
      return(_models);
    }

    public Census Get(int id)
    {
      return (_models.FirstOrDefault(m => m.ID == id));
    }

    public IEnumerable<Census> Search(SearchParameters parameters)
    {
      return (_models);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
  }
}