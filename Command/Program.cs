public class Program
{
    public static void Main()
    {
        var livingRoomLight = new Light();
        var remoteControl = new RemoteControl();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();

        Blender blender = new Blender();
        BlenderButton blenderButton = new BlenderButton();

        ICommand blenderOn = new BlenderOn(blender);
        ICommand blenderOff = new BlenderOff(blender);

        blenderButton.ExecuteCommand(blenderOff);
        blenderButton.UndoCommand();
        blenderButton.ExecuteCommand(blenderOn);
        blenderButton.UndoCommand();

        Printer printer = new Printer();
        PrinterButton printerButton = new PrinterButton();

        ICommand printerOn = new PrinterOnCommand(printer);
        ICommand printerOff = new PrinterOffCommand(printer);

        printerButton.ExecuteCommand(printerOn);
        printerButton.UndoCommand();
        printerButton.ExecuteCommand(printerOff);
        printerButton.UndoCommand();
    }
}
