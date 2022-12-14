namespace ConwaysGameOfLifeBlazorWASM.Domain;

public class TemplatePattern
{
    public bool[,] Cells { get; set; }
    public string Name { get; set; }
    public PatternType PatternType { get; set; }
}

public enum PatternType
{
    Oscillator,
    Spaceship
}