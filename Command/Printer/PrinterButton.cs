public class PrinterButton
{
    private readonly Stack<ICommand> _commandHistory;

    public PrinterButton()
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