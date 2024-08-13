using Command.Receivers;
using Command.interfaces;

namespace Command.Commands;
public class GarageDoorCloseCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorCloseCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.Close();
    }

    public void Undo()
    {
        _garageDoor.Open();
    }
}
