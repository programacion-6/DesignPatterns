using Command.Commands.Interfaces;
using Command.Receivers;

namespace Command.Commands.GarageDoorCommands;

public class GarageDoorOpenCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorOpenCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.OpenGarageDoor();
    }

    public void Undo()
    {
        _garageDoor.CloseGarageDoor();
    }
}
