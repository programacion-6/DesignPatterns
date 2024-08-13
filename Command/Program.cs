using System.Net.Http.Headers;

namespace Command;

/// <summary>
/// Command
///     Todas las clases creadas (comandos) tienen un comportamiento pre-definido
///     siguiendo un 'estrategia'
/// 
/// Cuando?:
///     1. Se pone complejo el codigo a medida que crece
///     2. Existe varias formas de hacer lo mismo o hacer algo con el mismo objetivo pero destinta forma
///     3. Comportamiento encapsulado que modifica o que interactua directamente con una o varias entidad.
///     4. SE TOMAN ACCIONES EN NINGUN ORDEN APARENTE.
///     (5. Nos puede ayudar a definir el orden (o seleccion) en el que se ejecutan los comandos)
///     
/// Explicacion (WITH):
///     1. Command Interface: (ICommand) Para la ejecucion de los comandos
///     2. Concrete Commands: (WriteCommand) Implementa el interface command y encapsula el requerimiento i.e. de escribir.
///     3. Receiver: (TextEditor) La clase que aplica el comando ejecutado
///     4. Invoker: (CommandInvoker) Responsable de ejecutar los comandos y guardar el historias en una pila (cola).
///     5. Usage: El cliente usa el Command Invoker para ejectuar los comandos. El historial de comandos permite predefinir un orden o seleccion de comandos
/// </summary>
/// 

/// WITHOUT
//public class TextEditor
//{
//    private string _text;

//    public TextEditor()
//    {
//        _text = string.Empty;
//    }

//    public void WriteText(string text)
//    {
//        _text += text;
//        Console.WriteLine($"Current text: '{_text}'");
//    }

//    public void UndoWrite(string text)
//    {
//        if (_text.EndsWith(text))
//        {
//            _text = _text.Substring(0, _text.Length - text.Length);
//            Console.WriteLine($"Undo operation. Current text: '{_text}'");
//        }
//    }
//}


// WITH
//public interface ICommand
//{
//    void Execute();

//    void Undo();
//}

//public class WriteCommand : ICommand
//{
//    private readonly TextEditor _editor;

//    private readonly string _text;

//    public WriteCommand(TextEditor editor, string text)
//    {
//        _editor = editor; 
//        _text = text;
//    }

//    public void Execute()
//    {
//        _editor.WriteText(_text);
//    }

//    public void Undo()
//    {
//        _editor.UndoWrite(_text);
//    }
//}

//public class TextEditor
//{
//    private string _text;

//    public TextEditor()
//    {
//        _text = string.Empty;
//    }

//    public void WriteText(string text)
//    {
//        _text += text;
//        Console.WriteLine($"Current text: '{_text}'");
//    }

//    public void UndoWrite(string text)
//    {
//        if (_text.EndsWith(text))
//        {
//            _text = _text.Substring(0, _text.Length - text.Length);
//            Console.WriteLine($"Undo operation. Current text: '{_text}'");
//        }
//    }
//}

//public class CommandInvoker
//{
//    private readonly Stack<ICommand> _commandsHistory;

//    public CommandInvoker()
//    {
//        _commandsHistory = new Stack<ICommand>();
//    }

//    public void ExecuteCommand(ICommand command)
//    {
//        command.Execute();
//        _commandsHistory.Push(command);
//    }

//    public void UndoCommand()
//    {
//        if (_commandsHistory.Count > 0 )
//        {
//            ICommand command = _commandsHistory.Pop();
//            command.Undo();
//        }
//    }
//}

public interface ICommand
{
    void Execute();

    void Undo();
}

public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

public class Light
{
    public void On()
    {
        Console.WriteLine("The light is on");
    }

    public void Off()
    {
        Console.WriteLine("The light is off");
    }
}
public class FanOffCommand : ICommand
{
    private readonly Fan _fan;
    public FanOffCommand(Fan fan){
        _fan = fan;
    }
public void Execute()
    {
        _fan.Off();
    }

    public void Undo()
    {
        _fan.On();
    }
}

public class FanOnCommand : ICommand
{
    private readonly Fan _fan;
    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }
    public void Execute()
    {
        _fan.On();
    }

    public void Undo()
    {
        _fan.Off();
    }
}

public class Fan
{
    public void On()
    {
        Console.WriteLine("I guess the Fan is on now.");
    }
    public void Off()
    {
        Console.WriteLine("What? Do you expect something else? Yes yes the hecking Fan is off now.");
    }
    
}

public class GarageDoorOnCommand : ICommand
{
    private readonly GarageDoor _garageDoor;
    public GarageDoorOnCommand(GarageDoor garageDoor)
    {
        _garageDoor =  garageDoor;
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
public class GarageDoorOffCommand : ICommand
{
    private readonly GarageDoor _garageDoor;
    public GarageDoorOffCommand(GarageDoor garageDoor)
    {
        _garageDoor =  garageDoor;
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
public class GarageDoor
{
    public void On()
    {
        Console.WriteLine("Wait, something stopped the door, ok it's done now.");
    }
    public void Off()
    {
        Console.WriteLine("Another battery and should do, yep it's closing, and it's closed.");
    }
}

// OTRO APARATO QUE IMPLEMENTE ICommand
public class KillingMachineOnCommand : ICommand
{
    private readonly KillingMachine _machine;
    public KillingMachineOnCommand(KillingMachine machine)
    {
        _machine = machine;
    }
     public void Execute()
    {
        _machine.On();
    }

    public void Undo()
    {
        _machine.Off();
    }
}

public class KillingMachineOffCommand : ICommand
{
    private readonly KillingMachine _machine;
    public KillingMachineOffCommand(KillingMachine machine)
    {
        _machine = machine;
    }
     public void Execute()
    {
        _machine.Off();
    }

    public void Undo()
    {
        _machine.On();
    }
}

public class KillingMachineScoutTargetsCommand : ICommand
{
    private readonly KillingMachine _machine;
    public KillingMachineScoutTargetsCommand(KillingMachine machine)
    {
        _machine = machine;
    }
     public void Execute()
    {
        _machine.ScoutTargets();
    }

    public void Undo()
    {
        _machine.StopCurrentOperation();
    }
}

public class KillingMachineKillTargetsCommand : ICommand
{
    private readonly KillingMachine _machine;
    public KillingMachineKillTargetsCommand(KillingMachine machine)
    {
        _machine = machine;
    }
     public void Execute()
    {
        _machine.KillTargets();
    }

    public void Undo()
    {
        _machine.StopCurrentOperation();
    }
}
public class KillingMachine 
{
    public void On()
    {
        Console.WriteLine("System operational, ready for duty");
    }
    public void Off()
    {
        Console.WriteLine("System shutting down, recovering power.");
    }
    public void ScoutTargets()
    {
        Console.WriteLine("Command confirmed, following enemies without being detected.");
    }
    public void KillTargets()
    {
        Console.WriteLine("Command confirmed, proceeding to murder protocols.");
    }
    public void StopCurrentOperation()
    {
        Console.WriteLine("Command canceled, waiting next command.");
    }
}

public class RemoteControl
{
    private readonly Stack<ICommand> _commandHistory;

    public RemoteControl()
    {
        _commandHistory = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoCommand()
    {
        ICommand command = _commandHistory.Pop();
        command.Undo();
    }
}

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
        
        var remoteControl = new RemoteControl();
        
        var livingRoomLight = new Light();
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        var fan = new Fan();
        ICommand fanOn = new FanOnCommand(fan);
        ICommand fanOff = new FanOffCommand(fan);

        var garage = new GarageDoor();
        ICommand garageDoorOn = new GarageDoorOnCommand(garage);
        ICommand garageDoorOff = new GarageDoorOffCommand(garage);

        var killingMachine = new KillingMachine();
        ICommand killingMachineOn = new KillingMachineOnCommand(killingMachine);
        ICommand killingMachineOff = new KillingMachineOffCommand(killingMachine);
        ICommand killingMachineScout = new KillingMachineScoutTargetsCommand(killingMachine);
        ICommand killingMachineKill = new KillingMachineKillTargetsCommand(killingMachine);

        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();

        //Killing machine commands
        remoteControl.ExecuteCommand(killingMachineOn);
        remoteControl.ExecuteCommand(killingMachineScout);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(killingMachineKill);
        remoteControl.UndoCommand();
    }
}
