public class PrinterOnCommand : ICommand
{
    private readonly Printer _printer;

    public PrinterOnCommand(Printer printer)
    {
        _printer = printer;
    }

    public void Execute()
    {
        _printer.On();
    }

    public void Undo()
    {
        _printer.Off();
    }
}