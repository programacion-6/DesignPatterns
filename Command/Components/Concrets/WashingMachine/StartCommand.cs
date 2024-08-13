namespace Command.Components.Concrets.WashingMachine;

using Command.Components.Interfaces;
using Command.Components.Receivers;

public class StartCommand : ICommand
{
    private WashingMachine _washingMachine;

    public StartCommand(WashingMachine washingMachine)
    {
        _washingMachine = washingMachine;
    }

    public void Execute()
    {
        _washingMachine.Start();
    }

    public void Undo()
    {
        _washingMachine.Stop();
    }
}
