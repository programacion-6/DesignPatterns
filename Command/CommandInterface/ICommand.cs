namespace Command.CommandInterface;

public interface ICommand
{
    void Execute();

    void Undo();
}
