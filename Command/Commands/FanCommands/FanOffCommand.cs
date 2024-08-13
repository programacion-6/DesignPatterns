using Command.Commands.Interfaces;
using Command.Receivers;

namespace Command.Commands.FanCommands;

public class FanOffCommand : ICommand
{
    private readonly Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOffFan();
    }

    public void Undo()
    {
        _fan.TurnOnFan();
    }
}
