namespace Command;

using Command.Components.Concrets.Light;
using Command.Components.Concrets.Fan;
using Command.Components.Concrets.GarageDoor;
using Command.Components.Concrets.WashingMachine;
using Command.Components.Receivers;
using Command.Components.Interfaces;
using Command.Components.Invokers;

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

// OTRO APARATO QUE IMPLEMENTE ICommand

public class AudioSystemOnCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemOnCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.On();
    }

    public void Undo()
    {
        _audioSystem.Off();
    }
}

public class AudioSystemOffCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemOffCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.Off();
    }

    public void Undo()
    {
        _audioSystem.On();
    }
}

public class AudioSystemVolumeUpCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemVolumeUpCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.VolumeUp();
    }

    public void Undo()
    {
        _audioSystem.VolumeDown();
    }
}

public class AudioSystemVolumeDownCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemVolumeDownCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.VolumeDown();
    }

    public void Undo()
    {
        _audioSystem.VolumeUp();
    }
}

public class AudioSystemNextTrackCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemNextTrackCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.NextTrack();
    }

    public void Undo()
    {
        _audioSystem.PreviousTrack();
    }
}

public class AudioSystemPreviousTrackCommand : ICommand
{
    private readonly AudioSystem _audioSystem;

    public AudioSystemPreviousTrackCommand(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    public void Execute()
    {
        _audioSystem.PreviousTrack();
    }

    public void Undo()
    {
        _audioSystem.NextTrack();
    }
}

public class AudioSystem
{
    private int _volume = 5;
    private int _currentTrack = 1;

    public void On()
    {
        Console.WriteLine("The audio system is on");
    }

    public void Off()
    {
        Console.WriteLine("The audio system is off");
    }

    public void VolumeUp()
    {
        if (_volume < 10)
        {
            _volume++;
            Console.WriteLine($"Volume is now at {_volume}");
        }
        else
        {
            Console.WriteLine("Volume is at maximum");
        }
    }

    public void VolumeDown()
    {
        if (_volume > 0)
        {
            _volume--;
            Console.WriteLine($"Volume is now at {_volume}");
        }
        else
        {
            Console.WriteLine("Volume is at minimum");
        }
    }

    public void NextTrack()
    {
        _currentTrack++;
        Console.WriteLine($"Playing track {_currentTrack}");
    }

    public void PreviousTrack()
    {
        if (_currentTrack > 1)
        {
            _currentTrack--;
            Console.WriteLine($"Playing track {_currentTrack}");
        }
        else
        {
            Console.WriteLine("Already on the first track");
        }
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
        var livingRoomLight = new Light();
        var fan = new Fan();
        var garageDoor = new GarageDoor();
        var audioSystem = new AudioSystem();
        var remoteControl = new RemoteControl();
        
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        // Fan Device
        ICommand onCommand = new FanOnCommand(fan);
        ICommand offCommand = new FanOffCommand(fan);

        // Garage Door Device
        ICommand openCommand = new GarageDoorOpenCommand(garageDoor);
        ICommand closeCommand = new GarageDoorCloseCommand(garageDoor);
        
        ICommand audioOn = new AudioSystemOnCommand(audioSystem);
        ICommand audioOff = new AudioSystemOffCommand(audioSystem);
        ICommand volumeUp = new AudioSystemVolumeUpCommand(audioSystem);
        ICommand volumeDown = new AudioSystemVolumeDownCommand(audioSystem);
        ICommand nextTrack = new AudioSystemNextTrackCommand(audioSystem);
        ICommand previousTrack = new AudioSystemPreviousTrackCommand(audioSystem);

        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();

        // Completing Devices
        // Fan Device
        remoteControl.ExecuteCommand(onCommand);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(offCommand);
        remoteControl.UndoCommand();

        // Garage Door Device
        remoteControl.ExecuteCommand(openCommand);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(closeCommand);
        remoteControl.UndoCommand();

        Console.WriteLine("Audio Example.");
        remoteControl.ExecuteCommand(audioOn);
        Console.WriteLine("Volume Up here.");
        remoteControl.ExecuteCommand(volumeUp);
        Console.WriteLine("Next track here.");
        remoteControl.ExecuteCommand(nextTrack);
        Console.WriteLine("Undo here.");
        remoteControl.UndoCommand(); 
        Console.WriteLine("Previous track here.");
        remoteControl.ExecuteCommand(previousTrack);
        Console.WriteLine("Undo here.");
        remoteControl.UndoCommand(); 
        Console.WriteLine("Volume Down here.");
        remoteControl.ExecuteCommand(volumeDown);
        Console.WriteLine("Undo here.");
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(audioOff);

        // Adding "Washing Machine" Device using Command
        var washingMachine = new WashingMachine();

        ICommand startCommand = new StartCommand(washingMachine);
        ICommand stopCommand = new StopCommand(washingMachine);
        ICommand pauseCommand = new PauseCommand(washingMachine);
        ICommand setModeCommand = new SetModeCommand(washingMachine, "Fuzzy");

        // Starting the washing machine
        remoteControl.ExecuteCommand(startCommand);
        // Undo the last operation 
        // (Start -> Stop)
        remoteControl.UndoCommand();

        // Pausing the washing machine
        remoteControl.ExecuteCommand(pauseCommand);
        // Undo the last operation 
        // (Pause -> Start)
        remoteControl.UndoCommand();

        // Setting the washing mode to Fuzzy
        remoteControl.ExecuteCommand(setModeCommand);
        // Undo the last operation
        // (Pause to set a Mode -> Start)
        remoteControl.ExecuteCommand(startCommand);

        // Stopping the washing machine
        remoteControl.ExecuteCommand(stopCommand);
        // Undo the last operation 
        // (Stop -> Start)
        remoteControl.UndoCommand();
    }
}
