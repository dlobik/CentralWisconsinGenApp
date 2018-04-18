using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

	/// <summary>
	/// Summary description for Catalog.
	/// </summary>
	public class Catalog
	{
		public Catalog()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private string connectionString() 
		{
			return ConfigurationSettings.AppSettings["conSQL"];
		}
		public SqlDataReader GetProductsOnCatalog() 
		{
			//' Create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//' Create and initialize the command object
			SqlCommand command = new SqlCommand("GetProductsOnCatalog", connection);
			command.CommandType = CommandType.StoredProcedure;

			connection.Open();

			//' Return a SqlDataReader to the calling function
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public SqlDataReader SearchCatalog(String searchstring ,String allWords)
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("SearchCatalog", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'we guard against bogus values here - if we receive anything
			//'different than TRUE we assume it's FALSE
			if (allWords.ToUpper() == "TRUE")
			{
				//'we only do an "all words" search
				command.Parameters.Add("@AllWords", SqlDbType.Bit, 1);
				command.Parameters["@AllWords"].Value = 1;
			}
			else
			{
				//'we only do an "any words" search
				command.Parameters.Add("@AllWords", SqlDbType.Bit, 1);
				command.Parameters["@AllWords"].Value = 0;
			}

			//'we eliminate separation characters
			searchstring = searchstring.Replace(",", " ");
			searchstring = searchstring.Replace(";", " ");
			searchstring = searchstring.Replace(".", " ");
			searchstring = searchstring.Replace("and", " ");
			searchstring = searchstring.Replace("or", " ");
			searchstring = searchstring.Replace("on", " ");
			searchstring = searchstring.Replace("a", " ");
			searchstring = searchstring.Replace("the", " ");

			//'we create an array which contains the words
			string delimStr = " ";
			char [] delimiter = delimStr.ToCharArray();

			String[] words = searchstring.Split(delimiter);

			//'wordscount contains the total number of words
			int wordsCount = words.Length;
			//'index is used to parse the list of words
			int index = 0;
			//'this will store the total number of added words
			int addedWords = 0;

			//'we allow a maximum of 8 words
			while (addedWords < 8 && index < wordsCount)
			{
				//'we add the @WordN parameters here
				if (words[index].Length > 2)
				{
					addedWords += 1;
					//'add an input parameter and supply a value for it
					command.Parameters.AddWithValue("@Word" + addedWords.ToString(), words[index]);
				}
				index += 1;
			}
			//'open the connection
			connection.Open();

			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

	}

