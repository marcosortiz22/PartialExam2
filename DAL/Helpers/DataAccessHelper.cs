using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helpers;

public static class DataAccessHelper
{
    private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

    public static DataTable GetDataTable(string commandText, Dictionary<string, object> parameters = null)
    {
        DataTable dataTable = new DataTable();

        try
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(GetCommand(commandText, connection, parameters));
                adapter.Fill(dataTable);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(), "ERROR");
            throw new Exception("Error en base de datos, revisar logs.");
        }

        return dataTable;
    }

    public static int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters = null)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = GetCommand(commandText, connection, parameters))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(), "ERROR");
            throw new Exception("Error en base de datos, revisar logs.");
        }

    }

    public static DataSet GetDataSet(string query)
    {
        DataSet dataSet = new DataSet();
        try
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataSet);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(), "ERROR");
            throw new Exception("Error en base de datos, revisar logs.");
        }

        return dataSet;
    }

    public static object ExecuteScalar(string commandText, Dictionary<string, object> parameters = null)
    {
        object result;
        try
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = GetCommand(commandText, connection, parameters))
                {
                    result = command.ExecuteScalar();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(),"ERROR");
            throw new Exception("Error en base de datos, revisar logs.");
        }

        return result;
    }

    public static SqlConnection GetConnection()
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        return connection;
    }

    public static SqlCommand GetCommand(string query, SqlConnection connection, Dictionary<string, object> parameters = null)
    {
        SqlCommand command = new SqlCommand(query, connection);

        if (parameters != null)
        {
            SqlParameter[] sqlParameters = GetSqlParameters(parameters);
            command.Parameters.AddRange(sqlParameters);
        }

        return command;
    }

    public static SqlDataReader GetDataReader(SqlCommand command)
    {
        SqlDataReader reader;
        try
        {
            reader = command.ExecuteReader();
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString(), "ERROR");
            throw new Exception("Error en base de datos, revisar logs.");
        }

        return reader;
    }

    private static SqlParameter[] GetSqlParameters(Dictionary<string, object> parameters)
    {
        var sqlParameters = new List<SqlParameter>();
        foreach (var parameter in parameters)
        {
            var sqlParameter = new SqlParameter(parameter.Key, parameter.Value);
            sqlParameters.Add(sqlParameter);
        }
        return sqlParameters.ToArray();
    }
}
