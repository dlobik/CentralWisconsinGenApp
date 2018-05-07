using System;
using System.Collections.Generic;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class CensusSampleRepository: ICensusRepository
  {
    private IList<Census> _models;

    public CensusSampleRepository()
    {
      _models = new List<Census>() {
        new Census { ID = 1, FirstName = "Hello", LastName = "milly", Age = 10, DateOfRecord = DateTime.Parse("2011-09-05"), Page = "3", Town = "jackson", },
        new Census { ID = 2, FirstName = "Bye", LastName = "dan", Age = 10, DateOfRecord = DateTime.Parse("2009-09-05"), Page = "3", Town = "milwaukee", },
        new Census { ID = 3, FirstName = "mother", LastName = "shut", Age = 10, DateOfRecord = DateTime.Parse("2008-09-05"), Page = "3", Town = "madison", },
        new Census { ID = 4, FirstName = "Father", LastName = "the", Age = 10, DateOfRecord = DateTime.Parse("2007-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 5, FirstName = "Son", LastName = "door", Age = 10, DateOfRecord = DateTime.Parse("2006-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 6, FirstName = "Grandpa", LastName = "itis", Age = 10, DateOfRecord = DateTime.Parse("2005-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 7, FirstName = "uncle", LastName = "veryyyyyyyyyyyyy", Age = 10, DateOfRecord = DateTime.Parse("2004-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 8, FirstName = "baby", LastName = "coldddddddddd", Age = 10, DateOfRecord = DateTime.Parse("2003-09-05"), Page = "3", Town = "blah blah", },
        new Census { ID = 9, FirstName = "bo", LastName = "outside", Age = 10, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "3", Town = "blah blah", },
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