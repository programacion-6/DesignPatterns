using Command.Commands.Interfaces;

namespace Command.Invokers;

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
        if (_commandHistory.Count > 0)
        {
            ICommand lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo");
        }
    }
}
