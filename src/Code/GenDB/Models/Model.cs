using Newtonsoft.Json;

namespace GenDB.Models
{
  public abstract class Model
  {
    public virtual string ToJson()
    {
      return (JsonConvert.SerializeObject(this));
    }
  }
}