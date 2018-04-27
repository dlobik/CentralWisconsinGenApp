using System;
using System.Collections.Generic;
using GenDB.Business.Repository;
using GenDB.Models;
using GenDB.ViewModels;

namespace GenDB.Business
{
  public class ObituaryBusinessLogic: IDisposable
  {
    private IObituaryRepository _repository;

    public ObituaryBusinessLogic() : this(RepositoryFactory.CreateObituaryRepository())
    {
    }

    public ObituaryBusinessLogic(IObituaryRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<Obit> Search(SearchParameters parameters)
    {
      return(_repository.Search(parameters));
    }

    public IEnumerable<Obit> All()
    {
      return (_repository.All());
    }

    public Obit Get(int id)
    {
      return (_repository.Get(id));
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
      if (_repository != null) {
        _repository.Dispose();
      }
    }
  }
}