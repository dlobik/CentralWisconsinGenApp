using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenDB.DAL
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
  }
}