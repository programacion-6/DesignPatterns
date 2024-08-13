using Command.CommandInterface;

namespace Command.Invoker;

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
