public class PrinterOffCommand : ICommand
{
    private readonly Printer _printer;

    public PrinterOffCommand(Printer printer)
    {
        _printer = printer;
    }

    public void Execute()
    {
        _printer.Off();
    }

    public void Undo()
    {
        _printer.On();
    }
}
