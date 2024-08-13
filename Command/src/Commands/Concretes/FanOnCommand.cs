using Command.src.Commands.Interface;
using Command.src.Receivers;

namespace Command.src.Commands.Concretes;

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
