public class BlenderOff : ICommand
{
    private readonly Blender _blender;

    public BlenderOff(Blender blender)
    {
        this._blender = blender;
    }

    public void Execute()
    {
        _blender.Off();
    }

    public void Undo()
    {
        _blender.On();
    }
}
