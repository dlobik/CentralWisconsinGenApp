﻿using GenDB.Business.Repository.EntityFramework;

namespace GenDB.Business.Repository
{
  public abstract class RepositoryFactory
  {
    public static ICensusRepository CreateCensusRepository()
    {
#if ENTITYFRAMEWORK
      return (new CensusEntityFrameworkRepository(new GenContext()));
#else
      return (new CensusSampleRepository());
#endif
    }
    public static INaturalizationRepository CreateNaturalizationRepository()
    {
#if ENTITYFRAMEWORK
      return (new NaturalizationEntityFrameworkRepository(new GenContext()));
#else
      return (new NaturalizationSampleRepository());
#endif
    }

    public static IObituaryRepository CreateObituaryRepository()
    {
#if ENTITYFRAMEWORK
      return (new ObituaryEntityFrameworkRepository(new GenContext()));
#else
      return (new ObituarySampleRepository());
#endif
    }

    public static ICensusMemberRepository CreateCensusMemberRepository()
    {
#if ENTITYFRAMEWORK
      return (new CensusMemberEntityFrameworkRepository(new GenContext()));
#else
      return (new ObituarySampleRepository());
#endif
    }

        public static ICountyRepository CreateCountyRepository()
    {
#if ENTITYFRAMEWORK
      return (new CountyEntityFrameworkRepository(new GenContext()));
#else
      return (new CountySampleRepository());
#endif
    }
    }
}