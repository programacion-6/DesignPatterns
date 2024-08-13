public class GarageDoorOnCommand : ICommand
{
    private readonly GarageDoor _garageDoor;

    public GarageDoorOnCommand(GarageDoor garageDoor)
    {
        _garageDoor = garageDoor;
    }

    public void Execute()
    {
        _garageDoor.On();
    }

    public void Undo()
    {
        _garageDoor.Off();
    }
}