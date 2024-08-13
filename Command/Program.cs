namespace Command;

public class Program
{
    public static void Main()
    {
        var livingRoomLight = new Light();
        var remoteControl = new RemoteControl();
        var garageDoor = new GarageDoor();
        var fan = new Fan();
        
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        ICommand openGarageDoor = new GarageDoorOpenCommand(garageDoor);
        ICommand closeGarageDoor = new GarageDoorCloseCommand(garageDoor);

        ICommand fanOn = new FanOnCommand(fan);
        ICommand fanOff = new FanOffCommand(fan);

        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();

        remoteControl.ExecuteCommand(openGarageDoor);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(closeGarageDoor);
        remoteControl.UndoCommand();

        remoteControl.ExecuteCommand(fanOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(fanOff);
        remoteControl.UndoCommand();
    }
}
