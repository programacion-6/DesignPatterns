using Command.CommandInterface;
using Command.Receivers;

namespace Command.ConcreteCommands.Fans;

public class FanOffCommand : ICommand
{
    private readonly Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.Off();
    }

    public void Undo()
    {
        _fan.On();
    }
}
