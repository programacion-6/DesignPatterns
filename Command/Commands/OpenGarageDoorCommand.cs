namespace Command;

public class OpenGarageDoorCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public OpenGarageDoorCommand(GarageDoor garageDoor)
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