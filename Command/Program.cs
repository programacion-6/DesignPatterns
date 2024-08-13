namespace Command;

public class Program
{
    public static void Main()
    {
        var livingRoomLight = new Light();
        var ceilingFan = new Fan();
        var garageDoor = new GarageDoor();

        var remoteControl = new RemoteControl();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);
        
        ICommand fanOn = new FanOnCommand(ceilingFan);
        ICommand fanOff = new FanOffCommand(ceilingFan);

        ICommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
        ICommand garageDoorClose = new GarageDoorCloseCommand(garageDoor);

        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();

        remoteControl.ExecuteCommand(fanOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(fanOff);
        remoteControl.UndoCommand();

        remoteControl.ExecuteCommand(garageDoorOpen);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(garageDoorClose);
        remoteControl.UndoCommand();


    }
}
