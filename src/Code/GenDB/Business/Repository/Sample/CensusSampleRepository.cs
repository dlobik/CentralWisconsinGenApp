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
        new Census { ID = 1, FirstName = "Sophia", LastName = "Garcia", Age = 55, DateOfRecord = DateTime.Parse("2011-11-18"), Page = "34", Town = "Adams", CountyID=1, CensusMemberID = 1,},
        new Census { ID = 2, FirstName = "Emma", LastName = "Martin", Age = 18, DateOfRecord = DateTime.Parse("2009-11-11"), Page = "5", Town = "Almond", CountyID=2, CensusMemberID = 2,},
        new Census { ID = 3, FirstName = "Olivia", LastName = "Moore", Age = 21, DateOfRecord = DateTime.Parse("2008-09-27"), Page = "16", Town = "Beaver Dam", CountyID=3, CensusMemberID = 3,},
        new Census { ID = 4, FirstName = "Ava", LastName = "Walker", Age = 23, DateOfRecord = DateTime.Parse("2007-07-22"), Page = "22", Town = "Bloomfield", CountyID=4, CensusMemberID = 4,},
        new Census { ID = 5, FirstName = "Emily", LastName = "Sanchez", Age = 30, DateOfRecord = DateTime.Parse("2006-11-05"), Page = "18", Town = "Dayton", CountyID=5, CensusMemberID = 5,},
        new Census { ID = 6, FirstName = "Billy", LastName = "Lewis", Age = 60, DateOfRecord = DateTime.Parse("2005-03-05"), Page = "2", Town = "Georgetown", CountyID=1, CensusMemberID = 6,},
        new Census { ID = 7, FirstName = "Ralph", LastName = "Perez", Age = 59, DateOfRecord = DateTime.Parse("2004-05-16"), Page = "1", Town = "Green Bay", CountyID=2, CensusMemberID = 7,},
        new Census { ID = 8, FirstName = "Reginald", LastName = "Hall", Age = 25, DateOfRecord = DateTime.Parse("2003-01-25"), Page = "55", Town = "Hull", CountyID=3, CensusMemberID = 8,},
        new Census { ID = 9, FirstName = "Kaylee", LastName = "Young", Age = 16, DateOfRecord = DateTime.Parse("2001-09-05"), Page = "77", Town = "Lincoln", CountyID=4, CensusMemberID = 9,},
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