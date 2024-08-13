namespace Command;

public class GarageDoorOpenCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorOpenCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.OpenDoor();
    }

    public void Undo()
    {
        _garageDoor.CloseDoor();
    }
}