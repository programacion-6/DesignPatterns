public class GarageDoorClosedCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorClosedCommand(GarageDoor garageDoor)
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