public class GarageDoorOffCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorOffCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.Off();
    }

    public void Undo()
    {
        _garageDoor.On();
    }
}