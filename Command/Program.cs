using Command.Commands.FanCommands;
using Command.Commands.GarageDoorCommands;
using Command.Commands.Interfaces;
using Command.Commands.LightCommands;
using Command.Invokers;
using Command.Receivers;

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

// Client
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
        // Crear el receptor
        var livingRoomLight = new Light();
        // Crear el invocador
        var remoteControl = new RemoteControl();
        

        //// LIGHT
        
        // Crear los comandos
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        // Ejecutar comandos y guardarlos en el historial
        remoteControl.ExecuteCommand(lightOn); // Output: Light is On
        // Deshacer el comando
        remoteControl.UndoCommand(); // Output: Light is Off
        remoteControl.ExecuteCommand(lightOff); // Output: Light is Off

        // Deshacer el otro comando
        remoteControl.UndoCommand(); // Output: Light is On

        // Intentar deshacer cuando no hay más comandos
        remoteControl.UndoCommand(); // Output: No commands to undo


        //// FAN
        
        // Crear el receptor
        var bedroomFan = new Fan();
        // Crear los comandos
        ICommand fanOn = new FanOnCommand(bedroomFan);
        ICommand fanOff = new FanOffCommand(bedroomFan);

        // Ejecutar comandos y guardarlos en el historial
        remoteControl.ExecuteCommand(fanOn); // Output: Fan is On
        // Deshacer el comando
        remoteControl.UndoCommand(); // Output: Fan is Off
        remoteControl.ExecuteCommand(fanOff); // Output: Fan is Off

        // Deshacer el otro comando
        remoteControl.UndoCommand(); // Output: Fan is On

        // Intentar deshacer cuando no hay más comandos
        remoteControl.UndoCommand(); // Output: No commands to undo


        /// GARAGE DOOR

        // Crear el receptor
        var garageDoor = new GarageDoor();
        // Crear los comandos
        ICommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
        ICommand garageDoorClose = new GarageDoorCloseCommand(garageDoor);

        // Ejecutar comandos y guardarlos en el historial
        remoteControl.ExecuteCommand(garageDoorOpen); // Output: Garage Door is Open
        // Deshacer el comando
        remoteControl.UndoCommand(); // Output: Garage Door is clode
        remoteControl.ExecuteCommand(garageDoorClose); // Output: Garage Door is close

        // Deshacer el otro comando
        remoteControl.UndoCommand(); // Output: Garage Door is Open

        // Intentar deshacer cuando no hay más comandos
        remoteControl.UndoCommand(); // Output: No commands to undo
    }
}
