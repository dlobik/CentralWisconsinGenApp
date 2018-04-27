using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GenDB.Models;

namespace GenDB.Business.Repository.EntityFramework
{
  public class GenContext : DbContext
  {
    public GenContext() : base("GenContext")
    {
    }

    public DbSet<Obit> Obit { get; set; }
    public DbSet<Census> Census { get; set; }
    public DbSet<Naturalization> Naturalization { get; set; }
    public DbSet<CensusMember> CensusMember { get; set; }
    public DbSet<County> County { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      //modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<CaseSensitiveAttribute, bool>("CaseSensitive", (property, attributes) => attributes.Single().IsEnabled));
      base.OnModelCreating(modelBuilder);
    }
  }
}