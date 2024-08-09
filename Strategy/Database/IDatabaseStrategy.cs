namespace Strategy.Database;


public interface IDatabaseStrategy
{
    void Connect();

    void ExecuteQuery(string query);
}
