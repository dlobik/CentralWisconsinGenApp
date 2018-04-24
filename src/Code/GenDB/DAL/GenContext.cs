using System.Collections.Generic;
using System.Web;
using GenDB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GenDB.ViewModels;

namespace GenDB.DAL
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
        }

      public IEnumerable<Census> SearchCensus(SearchParameters parameters)
      {
        return(Census);
      }
    }
}