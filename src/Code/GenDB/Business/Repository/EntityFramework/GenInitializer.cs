using System.Data.Entity;
using GenDB.Business.Repository.Sample;

namespace GenDB.Business.Repository.EntityFramework
{
  public class GenInitializer : DropCreateDatabaseAlways<GenContext>
  {
    protected override void Seed(GenContext context)
    {
      var obituaryRepository = new ObituarySampleRepository();
      foreach (var obit in obituaryRepository.All()) {
        context.Obit.Add(obit);
      }

      var censusRepository = new CensusSampleRepository();
      foreach (var census in censusRepository.All()) {
        context.Census.Add(census);
      }

      var naturalizationRepository = new NaturalizationSampleRepository();
      foreach (var naturalization in naturalizationRepository.All()) {
        context.Naturalization.Add(naturalization);
      }

      var countryRepository = new CountySampleRepository();
      foreach (var county in countryRepository.All()) {
        context.County.Add(county);
      }

      context.SaveChanges();
    }
  }
}