namespace Command;
public class Program
{
    public static void Main()
    {
        // ---- WITHOUT ------
        //var editor = new TextEditor();
        //editor.WriteText("Hello ");
        //editor.WriteText("World!");

        //editor.UndoWrite("World!");

        // ---- WITH ------

        //var editor = new TextEditor();
        //var invoker = new CommandInvoker();

        //ICommand writeHello = new WriteCommand(editor, "Hello ");
        //ICommand writeWorld = new WriteCommand(editor, "World!");

        //invoker.ExecuteCommand(writeHello);
        //invoker.ExecuteCommand(writeWorld);
        //invoker.UndoCommand();

        // REMOTE CONTROL
        var livingRoomLight = new Light();
        var fan = new Fan();
        var garageDoor = new GarageDoor();
        var TV = new TV();

        var remoteControl = new RemoteControl();
        
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        ICommand fanOn = new FanOnCommand(fan);
        ICommand fanOff = new FanOffCommand(fan);

        ICommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
        ICommand garageDoorClosed = new GarageDoorClosedCommand(garageDoor);

        ICommand TVOn = new TVOnCommand(TV);
        ICommand TVOff = new TVOffCommand(TV);

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
        remoteControl.ExecuteCommand(garageDoorClosed);
        remoteControl.UndoCommand();

        remoteControl.ExecuteCommand(TVOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(TVOff);
        remoteControl.UndoCommand();
    }
}
