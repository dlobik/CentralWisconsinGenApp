using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository
{
  public interface ICountyRepository
  {
    IEnumerable<County> All();
  }
}