using Command.Commands.Interfaces;
using Command.Receivers;

namespace Command.Commands.FanCommands;

public class FanOnCommand : ICommand
{
    private readonly Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOnFan();
    }

    public void Undo()
    {
        _fan.TurnOffFan();
    }
}
