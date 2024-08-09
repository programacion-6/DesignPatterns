namespace Strategy.Database;

/// <summary>
/// WITHOUT STRATEGY PATTERN
/// </summary>

public class DatabaseHandler
{
    /// <summary>
    /// 'databaseType' puede ser una enum o directamente podemos utilizar 
    /// un factory para elegir el tipo de base de datos
    /// </summary>

    public void Connect(string databaseType)
    {
        if (databaseType == "SQLServer")
        {
            Console.WriteLine("Connecting to SQL Server...");
        }
        else if (databaseType == "MySQL")
        {
            Console.WriteLine("Connecting to MySQL...");
        }
        else if (databaseType == "PostgresSQL")
        {
            Console.WriteLine("Connecting to PostgresSQL...");
        }
        else
        {
            Console.WriteLine("Unknown database type.");
        }
    }

    public void ExecuteQuery(string databaseType, string query)
    {
        if (databaseType == "SQLServer")
        {
            Console.WriteLine("Executing query on SQL Server...");
        }
        else if (databaseType == "MySQL")
        {
            Console.WriteLine("Executing query on MySQL...");
        }
        else if (databaseType == "PostgresSQL")
        {
            Console.WriteLine("Executing query on PostgresSQL...");
        }
        else
        {
            Console.WriteLine("Unknown database type.");
        }
    }
}