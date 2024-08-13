using Command.Commands.Interfaces;
using Command.Receivers;

namespace Command.Commands.GarageDoorCommands;

public class GarageDoorCloseCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorCloseCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.CloseGarageDoor();
    }

    public void Undo()
    {
        _garageDoor.OpenGarageDoor();
    }
}
