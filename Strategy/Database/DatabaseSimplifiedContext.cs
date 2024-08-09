namespace Strategy.Database;

using System;
using System.Collections.Generic;

/// <summary>
/// PROS
/// Consistencia: Simplificamos la cantidad de codigo y implementamos toda la funcionalidad necesaria
///     Esto quiere decir que cuando tenemos pocas estrategias y/o la logica es minima entonces podemos reducir
/// 
/// Flexibilidad: Nuevas estrategias pueden ser añadidas de forma sencialla si se requiere.
/// Lectura: Al estar la logica mas encapsulada podemos tener codigo mas consiso.
/// 
/// CONS
/// Escalabilidad: Si el numero de estrategias fuese a crecer entonces o estamos tomando un buen approach al simplicar
/// 
/// Complejidad: Si las estrategias son complejas    
///
/// </summary>

public class DatabaseSimplifiedContext
{
    private readonly Dictionary<string, Action> _connect;

    private readonly Dictionary<string, Action<string>> _executeQuery;

    public DatabaseSimplifiedContext()
    {
        _connect = new Dictionary<string, Action>
        {
            { "SQLServer", () => Console.WriteLine("Connecting to SQLServer") },
            { "MySQL", () => Console.WriteLine("Connecting to MySQL") },
            { "PostreSQL", () => Console.WriteLine("Connecting to PostreSQL") }
        };

        _executeQuery = new Dictionary<string, Action<string>>
        {
            { "SQLServer", query => Console.WriteLine($"Execute query on SQLServer {query}") },
            { "MySQL", query => Console.WriteLine($"Execute query on MySQL {query}") },
            { "PostreSQL", query => Console.WriteLine($"Execute query on PostreSQL {query}") },
        };
    }

    public void Connect(string databaseType)
    {
        if (_connect.TryGetValue( databaseType, out var action ) )
        {
            action();
        }
        else
        {
            Console.WriteLine("Unkown database type");
        }
    }

    public void ExecuteQuery(string databaseType, string query)
    {
        if (_executeQuery.TryGetValue(databaseType, out var action))
        {
            action(query);
        }
        else
        {
            Console.WriteLine("Unkown database type");
        }
    }
}
