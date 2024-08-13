namespace Command;

public class CloseGarageDoorCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public CloseGarageDoorCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.CloseDoor();
    }

    public void Undo()
    {
        _garageDoor.OpenDoor();
    }
}