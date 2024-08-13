namespace Command.Components.Concrets.WashingMachine;

using Command.Components.Interfaces;
using Command.Components.Receivers;

public class StopCommand : ICommand
{
    private WashingMachine _washingMachine;

    public StopCommand(WashingMachine washingMachine)
    {
        _washingMachine = washingMachine;
    }

    public void Execute()
    {
        _washingMachine.Stop();
    }

    public void Undo()
    {
        _washingMachine.Start();
    }
}
