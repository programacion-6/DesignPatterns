namespace Command.Components.Interfaces;

public interface ICommand
{
    void Execute();

    void Undo();
}
