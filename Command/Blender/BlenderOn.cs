public class BlenderOn : ICommand
{
    private readonly Blender _blender;

    public BlenderOn(Blender blender)
    {
        this._blender = blender;
    }

    public void Execute()
    {
        _blender.On();
    }

    public void Undo()
    {
        _blender.Off();
    }
}
