namespace Strategy.Database;

public class SQLServerStrategy : IDatabaseStrategy
{
    public void Connect()
    {
        Console.WriteLine("Connecting to SQL Server");
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine("Executing query on SQL Server");
    }
}

// Puedo tener mas clases como :
// MySQLStrategy
// PosgreSQLStrategy
