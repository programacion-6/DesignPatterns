namespace Command.Components.Concrets.WashingMachine;

using Command.Components.Interfaces;
using Command.Components.Receivers;

public class PauseCommand : ICommand
{
    private WashingMachine _washingMachine;

    public PauseCommand(WashingMachine washingMachine)
    {
        _washingMachine = washingMachine;
    }

    public void Execute()
    {
        _washingMachine.Pause();
    }

    public void Undo()
    {
        _washingMachine.Start();
    }
}
