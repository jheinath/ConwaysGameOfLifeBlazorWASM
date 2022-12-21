namespace ConwaysGameOfLifeBlazorWASM.Domain;

public class Array2D
{
    private readonly bool[] _array;
    public readonly int Width;
    public readonly int Height;

    public Array2D(int height, int width)
    {
        Height = height;
        Width = width;
        _array = new bool[Width * height];
    }

    public bool this[int x, int y]
    {
        get => _array[y * Width + x];
        set => _array[y * Width + x] = value;
    }
}