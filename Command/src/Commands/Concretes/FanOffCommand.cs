using Command.src.Commands.Interface;
using Command.src.Receivers;

namespace Command.src.Commands.Concretes;

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