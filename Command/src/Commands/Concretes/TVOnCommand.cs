using Command.src.Commands.Interface;
using Command.src.Receivers;

namespace Command.src.Commands.Concretes;

public class TVOnCommand : ICommand
{
    private readonly TV _tv;

    public TVOnCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.On();
    }

    public void Undo()
    {
        _tv.Off();
    }

}
