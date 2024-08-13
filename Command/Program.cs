namespace Command;
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

    // Concrete Command for Fan On
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

    // Concrete Command for Fan Off
    public class FanOffCommand : ICommand
    {
        private readonly Fan _fan;

        public FanOffCommand(Fan fan)
        {
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

    // Receiver for Fan
    public class Fan
    {
        public void On()
        {
            Console.WriteLine("The fan is on");
        }

        public void Off()
        {
            Console.WriteLine("The fan is off");
        }
    }

    // Concrete Command for Garage Door Open
    public class GarageDoorOpenCommand : ICommand
    {
        private readonly GarageDoor _garageDoor;

        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void Execute()
        {
            _garageDoor.Open();
        }

        public void Undo()
        {
            _garageDoor.Close();
        }
    }

    // Concrete Command for Garage Door Close
    public class GarageDoorCloseCommand : ICommand
    {
        private readonly GarageDoor _garageDoor;

        public GarageDoorCloseCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void Execute()
        {
            _garageDoor.Close();
        }

        public void Undo()
        {
            _garageDoor.Open();
        }
    }

    public class GarageDoor
    {
        public void Open()
        {
            Console.WriteLine("The garage door is open");
        }

        public void Close()
        {
            Console.WriteLine("The garage door is closed");
        }
    }

// OTRO APARATO QUE IMPLEMENTE ICommand
public class TelevisionOnCommand : ICommand
{
    private readonly Television _television;

    public TelevisionOnCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.On();
    }

    public void Undo()
    {
        _television.Off();
    }
}

public class TelevisionOffCommand : ICommand
{
    private readonly Television _television;

    public TelevisionOffCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.Off();
    }

    public void Undo()
    {
        _television.On();
    }
}
public class Television
{
    public void On()
    {
        Console.WriteLine("The television is on");
    }

    public void Off()
    {
        Console.WriteLine("The television is off");
    }
}
public class AirConditionerOnCommand : ICommand
{
    private readonly AirConditioner _airConditioner;

    public AirConditionerOnCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.On();
    }

    public void Undo()
    {
        _airConditioner.Off();
    }
}

public class AirConditionerOffCommand : ICommand
{
    private readonly AirConditioner _airConditioner;

    public AirConditionerOffCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.Off();
    }

    public void Undo()
    {
        _airConditioner.On();
    }
}
public class AirConditioner
{
    public void On()
    {
        Console.WriteLine("The air conditioner is on");
    }

    public void Off()
    {
        Console.WriteLine("The air conditioner is off");
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
        var livingRoomLight = new Light();
        var remoteControl = new RemoteControl();
        var fan = new Fan();
        var garageDoor = new GarageDoor();
        var television = new Television();
        var airConditioner = new AirConditioner();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);
        remoteControl.ExecuteCommand(lightOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(lightOff);
        remoteControl.UndoCommand();
        
        // Fan
        ICommand fanOn = new FanOnCommand(fan);
        ICommand fanOff = new FanOffCommand(fan);
        remoteControl.ExecuteCommand(fanOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(fanOff);
        remoteControl.UndoCommand();

        // Garage Door
        ICommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
        ICommand garageDoorClose = new GarageDoorCloseCommand(garageDoor);
        remoteControl.ExecuteCommand(garageDoorOpen);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(garageDoorClose);
        remoteControl.UndoCommand();

        // Television
        ICommand televisionOn = new TelevisionOnCommand(television);
        ICommand televisionOff = new TelevisionOffCommand(television);
        remoteControl.ExecuteCommand(televisionOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(televisionOff);
        remoteControl.UndoCommand();

        // Air Conditioner
        ICommand airConditionerOn = new AirConditionerOnCommand(airConditioner);
        ICommand airConditionerOff = new AirConditionerOffCommand(airConditioner);
        remoteControl.ExecuteCommand(airConditionerOn);
        remoteControl.UndoCommand();
        remoteControl.ExecuteCommand(airConditionerOff);
        remoteControl.UndoCommand();
    }
}
