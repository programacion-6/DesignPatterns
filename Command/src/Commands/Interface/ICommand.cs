namespace Command.src.Commands.Interface;

public interface ICommand
{
    void Execute();
    void Undo();
}
