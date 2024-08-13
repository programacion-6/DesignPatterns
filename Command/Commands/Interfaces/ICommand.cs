namespace Command.Commands.Interfaces;
// Command
public interface ICommand
{
    void Execute();
    
    void Undo();
}
