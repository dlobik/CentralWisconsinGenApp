using System;
using System.Data;

namespace Repository
{
    /// <summary>
    /// Summary description for IGenIndexDbRepository
    /// </summary>
    public interface IGenIndexDbRepository
    {
        DataSet SearchGenIndex(string lastName, string firstName, string county, string eventYear, string dateObitPub, bool obituaries, bool census, bool naturalization);

        DataSet PrintMailOrder(string cartId);

        DataSet GetShoppingCart(string cartId);

        DataSet GetNaturaliaztionData(string gnId);

        DataSet GetCensusMemberData(string gnId);

        DataSet GetObitsDates(string gnId, string nabbr);
    }
}
