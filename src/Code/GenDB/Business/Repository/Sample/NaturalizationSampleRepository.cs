using System;
using System.Collections.Generic;
using System.Linq;
using GenDB.Models;

namespace GenDB.Business.Repository.Sample
{
  public class NaturalizationSampleRepository : INaturalizationRepository
  {
    private IList<Naturalization> _models;

    public NaturalizationSampleRepository()
    {
      _models = new List<Naturalization>() {
        new Naturalization{ID = 1, FirstName="Donald", LastName="Gray", DOB="01/10/2005", Age=100, DateOfRecord=DateTime.Parse("2001-04-15"), RecordType="DI, Final", CountryOfOrigin="Italy", Series=3, Box=11, Folder=11, VolNumber="3A", PageCertNumber="45", DateOfEntry="05/20/11",PortOfEntry="New York",CountyID=1,},
        new Naturalization{ID = 2, FirstName="Hillary", LastName="Reed", DOB="10/22/1995", Age=15, DateOfRecord=DateTime.Parse("2011-05-22"), RecordType="DI", CountryOfOrigin="Belarus", Series=1, Box=5, Folder=76, VolNumber="4B", PageCertNumber="12", DateOfEntry="07/19/25",PortOfEntry="Detriot",CountyID=2,},
        new Naturalization{ID = 3, FirstName="William", LastName="Cooper", DOB="05/02/2011", Age=20, DateOfRecord=DateTime.Parse("2002-08-03"), RecordType="DI", CountryOfOrigin="Denmark", Series=2, Box=6, Folder=32, VolNumber="55", PageCertNumber="16", DateOfEntry="09/27/34",PortOfEntry="Milwaukee",CountyID=3,},
        new Naturalization{ID = 4, FirstName="Bill", LastName="Wood", DOB="07/22/1990", Age=35, DateOfRecord=DateTime.Parse("2003-04-02"), RecordType="DI, Final", CountryOfOrigin="India", Series=5, Box=9, Folder=52, VolNumber="12", PageCertNumber="22", DateOfEntry="08/11/90",PortOfEntry="Buffalo",CountyID=4,},
        new Naturalization{ID = 5, FirstName="Jackson", LastName="James", DOB="09/01/2001", Age=10, DateOfRecord=DateTime.Parse("2004-06-11"), RecordType="DI, Final", CountryOfOrigin="Iraq", Series=7, Box=4, Folder=72, VolNumber="33AB", PageCertNumber="65", DateOfEntry="06/07/08",PortOfEntry="Philadelphia",CountyID=5,},
        new Naturalization{ID = 6, FirstName="Mike", LastName="Bennet", DOB="12/25/1999", Age=5, DateOfRecord=DateTime.Parse("2005-11-21"), RecordType="DI", CountryOfOrigin="Kenya", Series=11, Box=7, Folder=27, VolNumber="12B", PageCertNumber="41", DateOfEntry="04/13/06",PortOfEntry="New York",CountyID=1,},
        new Naturalization{ID = 7, FirstName="Michael", LastName="Cruz", DOB="11/27/2004", Age=76, DateOfRecord=DateTime.Parse("2006-12-25"), RecordType="DI", CountryOfOrigin="Laos", Series=2, Box=34, Folder=22, VolNumber="15C", PageCertNumber="11", DateOfEntry="08/18/88",PortOfEntry="Philadelphia",CountyID=2,},
        new Naturalization{ID = 8, FirstName="Sandra", LastName="Price", DOB="06/30/1993", Age=54, DateOfRecord=DateTime.Parse("2007-01-15"), RecordType="DI, Final", CountryOfOrigin="Libya", Series=3, Box=12, Folder=2, VolNumber="11", PageCertNumber="06", DateOfEntry="05/27/67",PortOfEntry="Washington",CountyID=3,},
        new Naturalization{ID = 9, FirstName="Rachael", LastName="Long", DOB="02/24/2015", Age=26, DateOfRecord=DateTime.Parse("2008-09-05"), RecordType="DI", CountryOfOrigin="Nepal", Series=3, Box=61, Folder=12, VolNumber="2", PageCertNumber="02", DateOfEntry="01/11/01",PortOfEntry="Milwaukee",CountyID=4,},
        new Naturalization{ID = 10, FirstName="Davis", LastName="Perry", DOB="10/15/1960", Age=77, DateOfRecord=DateTime.Parse("2009-02-05"), RecordType="DI, Final", CountryOfOrigin="Niger", Series=33, Box=12, Folder=2, VolNumber="8", PageCertNumber="88", DateOfEntry="11/27/05",PortOfEntry="Buffalo",CountyID=5,},
        new Naturalization{ID = 11, FirstName="Rudolph", LastName="Alexander", DOB="11/10/2010", Age=87, DateOfRecord=DateTime.Parse("2015-07-05"), RecordType="DI", CountryOfOrigin="Alberia", Series=37, Box=2, Folder=2, VolNumber="54", PageCertNumber="67", DateOfEntry="01/20/95",PortOfEntry="Detroit",CountyID=1,},
        new Naturalization{ID = 12, FirstName="Johnny", LastName="Griffin", DOB="03/20/1920", Age=43, DateOfRecord=DateTime.Parse("2020-08-05"), RecordType="DI", CountryOfOrigin="Argentina", Series=12, Box=10, Folder=2, VolNumber="77", PageCertNumber="99", DateOfEntry="12/20/90",PortOfEntry="Washington",CountyID=2,},
      };
    }

    public IEnumerable<Naturalization> All()
    {
      return(_models);
    }

    public Naturalization Get(int id)
    {
      return (_models.FirstOrDefault(m => m.ID == id));
    }

    public IEnumerable<Naturalization> Search(SearchParameters parameters)
    {
      return (_models);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
  }
}