using System;
using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository
{
  public interface ICensusRepository: IDisposable
  {
    IEnumerable<Census> All();
    Census Get(int id);
    IEnumerable<Census> Search(SearchParameters parameters);
  }
}