namespace Command.Components.Receivers;

public class WashingMachine
{
    public void Start()
    {
        Console.WriteLine("Washing Machine started.");
    }

    public void Stop()
    {
        Console.WriteLine("Washing Machine stopped.");
    }

    public void Pause()
    {
        Console.WriteLine("Washing Machine paused.");
    }

    public void SetMode(string mode)
    {
        Console.WriteLine($"Washing Machine mode set to {mode}.");
    }
}
