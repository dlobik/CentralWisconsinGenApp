using System;
using System.Collections.Generic;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.DAL
{
  public interface ICensusRepository: IDisposable
  {
    IEnumerable<Census> All();
    Census Get(int id);
    IEnumerable<Census> Search(SearchParameters parameters);
  }
}