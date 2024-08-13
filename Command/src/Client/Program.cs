using Command.src.Commands.Concretes;
using Command.src.Commands.Interface;
using Command.src.Invoker;
using Command.src.Receivers;

namespace Command.src.Client;

public class Program
{
    public static void Main()
    {
        var remoteControl = new RemoteControl();

        var livingRoomLight = new Light();
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        var livingRoomFan = new Fan();
        ICommand fanOn = new FanOnCommand(livingRoomFan);
        ICommand fanOff = new FanOffCommand(livingRoomFan);

        var garageDoor = new GarageDoor();
        ICommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
        ICommand garageDoorClose = new GarageDoorCloseCommand(garageDoor);

        var livingRoomTV = new TV();
        ICommand tvOn = new TVOnCommand(livingRoomTV);
        ICommand tvOff = new TVOffCommand(livingRoomTV);

        Console.WriteLine("========== On Commands ==========");
        remoteControl.ExecuteCommand(lightOn);
        remoteControl.ExecuteCommand(fanOn);
        remoteControl.ExecuteCommand(garageDoorOpen);
        remoteControl.ExecuteCommand(tvOn);

        Console.WriteLine("========== Undo Commands ==========");
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();

        Console.WriteLine("\n\n========== Off Commands ==========");
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.ExecuteCommand(fanOff);
        remoteControl.ExecuteCommand(garageDoorClose);
        remoteControl.ExecuteCommand(tvOff);

        Console.WriteLine("========== Undo Commands ==========");
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();
        remoteControl.UndoCommand();
    }
}
