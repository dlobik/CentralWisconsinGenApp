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
        new Naturalization{ID = 1, FirstName="Bye", LastName="Gogogoogogoggo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 2, FirstName="hi", LastName="Gogoasdsad", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 3, FirstName="William", LastName="Gogosss", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 4, FirstName="Bill", LastName="Gogoqweqew", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 5, FirstName="Jackson", LastName="Gogoq", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 6, FirstName="Mike", LastName="Go", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 7, FirstName="Michael", LastName="qweqweGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 8, FirstName="Sandra", LastName="qewssGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 9, FirstName="Rachael", LastName="qwewesseGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 10, FirstName="Dingo", LastName="vvccxGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 11, FirstName="Rudolph", LastName="vffhghGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
        new Naturalization{ID = 12, FirstName="Johnny", LastName="qwtyyuGogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
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