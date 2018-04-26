using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GenDB.Models;


namespace GenDB.DAL
{
    public class GenInitializer : DropCreateDatabaseAlways<GenContext>
    {
        protected override void Seed(GenContext context)
        {
            var obit = new List<Obit>
            {
            new Obit{FirstName="Carson", LastName="Alexander", AltName="Colgy", DateOfRecord=DateTime.Parse("2009-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 1"},
            new Obit{FirstName="Bill", LastName="Bango", AltName="Couy", DateOfRecord=DateTime.Parse("2004-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 2"},
            new Obit{FirstName="Craig", LastName="Qwerty", AltName="Cooy", DateOfRecord=DateTime.Parse("2012-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 3"},
            new Obit{FirstName="Charles", LastName="Zippy", AltName="Coogu", DateOfRecord=DateTime.Parse("2010-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 4"},
            new Obit{FirstName="Franksrson", LastName="Myre", AltName="Coguy", DateOfRecord=DateTime.Parse("2011-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 5"},
            new Obit{FirstName="Dirty", LastName="Dave", AltName="Clgy", DateOfRecord=DateTime.Parse("2002-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 6"},
            new Obit{FirstName="Big Dave", LastName="Dancer", AltName="Cguy", DateOfRecord=DateTime.Parse("2011-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 7"},
            new Obit{FirstName="Samantha", LastName="Lalala", AltName="Coguy", DateOfRecord=DateTime.Parse("2022-09-01"), BirthDate="2/10/15", Age=1, WebText="Web Text 8"},
            };

            obit.ForEach(s => context.Obit.Add(s));
            context.SaveChanges();

            var census = new List<Census>
            {
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 1",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 2",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 3",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 4",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 5",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 6",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 7",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 8",},
            new Census{FirstName="Hello",LastName="Billy", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), Page="3", Town="Town 9",},
            };
            census.ForEach(s => context.Census.Add(s));
            context.SaveChanges();

            var nats = new List<Naturalization>
            {
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            new Naturalization{FirstName="Bye", LastName="Gogo", DOB="10/10/10", Age=10, DateOfRecord=DateTime.Parse("2001-09-05"), RecordType="DI", CountryOfOrigin="Italy", Series=3, Box=1, Folder=2, VolNumber="3A", PageCertNumber="45", DateOfEntry="20/20/20",PortOfEntry="Washington"},
            };
            nats.ForEach(s => context.Naturalization.Add(s));
            context.SaveChanges();

            var county = new List<County>
            {
            new County{Name="Portage"},
            new County{Name="Shawno"},
            new County{Name="Marathon"},
            new County{Name="Milwaukee"}
            };
            county.ForEach(s => context.County.Add(s));
            context.SaveChanges();
        }
    }
}