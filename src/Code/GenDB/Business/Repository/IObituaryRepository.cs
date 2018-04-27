using System;
using System.Collections.Generic;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Business.Repository
{
  public interface IObituaryRepository: IDisposable
  {
    IEnumerable<Obit> All();
    Obit Get(int id);
    IEnumerable<Obit> Search(SearchParameters parameters);
  }
}