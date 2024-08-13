public class Fan
{
    public int Velocity;

    public void On()
    {
        Velocity = 1;
        Console.WriteLine("The fan is on");
    }

    public void Off()
    {
        Velocity = 0;
        Console.WriteLine("The fan is off");
    }
}