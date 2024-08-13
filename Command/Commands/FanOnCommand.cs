using Command.Receivers;
using Command.interfaces;

namespace Command.Commands;

public class FanOnCommand : ICommand
{
    private readonly Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.On();
    }

    public void Undo()
    {
        _fan.Off();
    }
}

