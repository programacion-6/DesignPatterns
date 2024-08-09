namespace Strategy.Database;

public class DatabaseContext
{
    private IDatabaseStrategy _databaseStrategy;

    public void SetDatabaseStrategy(IDatabaseStrategy databaseStrategy)
    {
        _databaseStrategy = databaseStrategy;
    }

    public void Connect()
    {
        _databaseStrategy.Connect();
    }

    public void ExecuteQuery(string query)
    {
        _databaseStrategy.ExecuteQuery(query);
    }
}
