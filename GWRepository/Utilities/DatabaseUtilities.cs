using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Utilities
{
    public class DatabaseUtilities
    {
        private const string _middleDatabaseString = "[QAWIZPROGlobalDataRepository].[dbo].";

        public DatabaseUtilities()
        {
        }

        #region Database Functions
        public List<string> GetRandomColumns(string table, string column, int numToReturn)
        {
            SqlConnection connection = GetConnection();
            List<int> usedRandomNumbers = new List<int>();
            string databaseAndTable = _middleDatabaseString + table;
            SqlDataReader myReader = null;
            int numRows = GetNumberOfRowsInTable(databaseAndTable);
            List<string> listToReturn = new List<string>();

            while (listToReturn.Count < numToReturn)
            {
                int randomNum = RandomNumberGeneratorUtilities.GetRandomNumber(numRows);
                while (usedRandomNumbers.Contains(randomNum))
                {
                    randomNum = RandomNumberGeneratorUtilities.GetRandomNumber(numRows);
                }
                usedRandomNumbers.Add(randomNum);
                SqlCommand myCommand = new SqlCommand($"select top 1 {column} from {databaseAndTable} where {column} " +
                                                      $"in (select top {randomNum} {column} from {databaseAndTable} order " +
                                                      $"by {column} asc) order by {column} desc", connection);
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                listToReturn.Add(myReader[column].ToString());
                myReader.Close();
            }

            CloseConnection(connection);
            return listToReturn;
        }

        public Dictionary<string, string> GetColumnsFromRandomRow(string table, List<string> columns)
        {
            SqlConnection connection = GetConnection();
            string databaseAndTable = _middleDatabaseString + table;
            SqlDataReader myReader = null;
            Dictionary<string, string> dictionaryToReturn = new Dictionary<string, string>();

            int randomNum = RandomNumberGeneratorUtilities.GetRandomNumber(GetNumberOfRowsInTable(databaseAndTable));

            foreach (string column in columns)
            {
                SqlCommand myCommand = new SqlCommand($"select top 1 {column} from {databaseAndTable} where {column} " +
                                                      $"in (select top {randomNum} {column} from {databaseAndTable} order " +
                                                      $"by {column} asc) order by {column} desc", connection);
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                string strippedColumnName = column.Substring(1, column.Length - 2);
                dictionaryToReturn.Add(strippedColumnName, myReader[strippedColumnName].ToString());
                myReader.Close();
            }

            CloseConnection(connection);
            return dictionaryToReturn;
        }
        #endregion


        #region Database Helpers
        private int GetNumberOfRowsInTable(string databaseAndTable)
        {
            SqlConnection connection = GetConnection();
            List<int> usedRandomNumbers = new List<int>();            
            string getNumRows = $"DECLARE @spaceUsed TABLE (name varchar(255),rows int,reserved varchar(50)," +
                                $"data varchar(50),index_size varchar(50),unused varchar(50))INSERT INTO @spaceUsed" +
                                $" exec sp_spaceused '{databaseAndTable}'SELECT rows FROM @spaceUsed";
            SqlCommand myCommand = new SqlCommand(getNumRows, connection);
            SqlDataReader myReader = null;
            myReader = myCommand.ExecuteReader();
            myReader.Read();
            int rowNumberToReturn = Convert.ToInt32(myReader["rows"]);
            myReader.Close();
            return rowNumberToReturn;
        }

        private void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private SqlConnection GetConnection()
        {
            SqlConnection myConnection = new SqlConnection("user id=qawizproglobal;" +
                           "password=test4work;server=fbms2048;" +
                           "Trusted_Connection=no;" +
                           "database=QAWIZPROGlobalDataRepository; " +
                           "connection timeout=5");
            try
            {
                myConnection.Open();
                try
                {
                    return myConnection;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        #endregion
    }
}