namespace Command.Components.Concrets.WashingMachine;

using Command.Components.Interfaces;
using Command.Components.Receivers;

public class SetModeCommand : ICommand
{
    private WashingMachine _washingMachine;
    private string _mode;
    private string _previousMode;

    public SetModeCommand(WashingMachine washingMachine, string mode)
    {
        _washingMachine = washingMachine;
        _mode = mode;
    }

    public void Execute()
    {
        _previousMode = _mode;
        _washingMachine.SetMode(_mode);
    }

    public void Undo()
    {
        _washingMachine.SetMode(_previousMode);
    }
}
