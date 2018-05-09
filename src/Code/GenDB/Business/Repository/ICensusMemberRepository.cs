using System;
using System.Collections.Generic;
using GenDB.Models;

namespace GenDB.Business.Repository
{
  public interface ICensusMemberRepository: IDisposable
  {
    IEnumerable<CensusMember> All();
    CensusMember Get(int id);
    IEnumerable<CensusMember> Search(SearchParameters parameters);
  }
}