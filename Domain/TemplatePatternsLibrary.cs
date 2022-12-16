using System.Collections.Generic;

namespace ConwaysGameOfLifeBlazorWASM.Domain;

public static class TemplatePatternsLibrary
{
    public static IEnumerable<TemplatePattern> GetTemplatePatterns()
    {
        return new List<TemplatePattern>
        {
            GetBlinker(),
            GetToad(),
            GetBeacon(),
            
            GetGlider(),
            GetLightWeightSpaceship(),
            GetMiddleWeightSpaceship(),
            GetHeavyWeightSpaceship()
        };
    }

    #region Spaceships

    private static TemplatePattern GetGlider()
    {
        var glider = new TemplatePattern
        {
            Name = "Glider",
            Cells = new bool[3, 3],
            PatternType = PatternType.Spaceship
        };
        glider.Cells[2, 0] = true;
        glider.Cells[0, 1] = true;
        glider.Cells[2, 1] = true;
        glider.Cells[1, 2] = true;
        glider.Cells[2, 2] = true;
        return glider;
    }

    private static TemplatePattern GetLightWeightSpaceship()
    {
        var sSpaceship = new TemplatePattern
        {
            Name = "Small Spaceship",
            Cells = new bool[5, 4],
            PatternType = PatternType.Spaceship
        };
        sSpaceship.Cells[1, 0] = true;
        sSpaceship.Cells[2, 0] = true;
        sSpaceship.Cells[3, 0] = true;
        sSpaceship.Cells[4, 0] = true;
        sSpaceship.Cells[0, 1] = true;
        sSpaceship.Cells[4, 1] = true;
        sSpaceship.Cells[4, 2] = true;
        sSpaceship.Cells[0, 3] = true;
        sSpaceship.Cells[3, 3] = true;
        return sSpaceship;
    }

    private static TemplatePattern GetMiddleWeightSpaceship()
    {
        var mSpaceship = new TemplatePattern
        {
            Name = "Medium Spaceship",
            Cells = new bool[6, 4],
            PatternType = PatternType.Spaceship
        };
        mSpaceship.Cells[1, 0] = true;
        mSpaceship.Cells[2, 0] = true;
        mSpaceship.Cells[3, 0] = true;
        mSpaceship.Cells[0, 1] = true;
        mSpaceship.Cells[1, 1] = true;
        mSpaceship.Cells[2, 1] = true;
        mSpaceship.Cells[3, 1] = true;
        mSpaceship.Cells[4, 1] = true;
        mSpaceship.Cells[0, 2] = true;
        mSpaceship.Cells[1, 2] = true;
        mSpaceship.Cells[2, 2] = true;
        mSpaceship.Cells[4, 2] = true;
        mSpaceship.Cells[5, 2] = true;
        mSpaceship.Cells[3, 3] = true;
        mSpaceship.Cells[4, 3] = true;
        return mSpaceship;
    }
    
    private static TemplatePattern GetHeavyWeightSpaceship()
    {
        var mSpaceship = new TemplatePattern
        {
            Name = "Large Spaceship",
            Cells = new bool[7, 4],
            PatternType = PatternType.Spaceship
        };
        mSpaceship.Cells[1, 0] = true;
        mSpaceship.Cells[2, 0] = true;
        mSpaceship.Cells[3, 0] = true;
        mSpaceship.Cells[4, 0] = true;
        mSpaceship.Cells[0, 1] = true;
        mSpaceship.Cells[1, 1] = true;
        mSpaceship.Cells[2, 1] = true;
        mSpaceship.Cells[3, 1] = true;
        mSpaceship.Cells[4, 1] = true;
        mSpaceship.Cells[5, 1] = true;
        mSpaceship.Cells[0, 2] = true;
        mSpaceship.Cells[1, 2] = true;
        mSpaceship.Cells[2, 2] = true;
        mSpaceship.Cells[3, 2] = true;
        mSpaceship.Cells[5, 2] = true;
        mSpaceship.Cells[6, 2] = true;
        mSpaceship.Cells[4, 3] = true;
        mSpaceship.Cells[5, 3] = true;
        return mSpaceship;
    }
    
    #endregion
    #region Oscillators
    
    private static TemplatePattern GetToad()
    {
        var toad = new TemplatePattern
        {
            Name = "Toad",
            Cells = new bool[4, 4],
            PatternType = PatternType.Oscillator
        };
        toad.Cells[2, 0] = true;
        toad.Cells[0, 1] = true;
        toad.Cells[3, 1] = true;
        toad.Cells[0, 2] = true;
        toad.Cells[3, 2] = true;
        toad.Cells[1, 3] = true;
        return toad;
    }
    
    private static TemplatePattern GetBlinker()
    {
        var blinker = new TemplatePattern
        {
            Name = "Blinker",
            Cells = new bool[1, 3],
            PatternType = PatternType.Oscillator
        };
        blinker.Cells[0, 0] = true;
        blinker.Cells[0, 1] = true;
        blinker.Cells[0, 2] = true;
        return blinker;
    }
    
    private static TemplatePattern GetBeacon()
    {
        var blinker = new TemplatePattern
        {
            Name = "Beacon",
            Cells = new bool[4, 4],
            PatternType = PatternType.Oscillator
        };
        blinker.Cells[0, 0] = true;
        blinker.Cells[1, 0] = true;
        blinker.Cells[0, 1] = true;
        blinker.Cells[1, 1] = true;
        blinker.Cells[2, 2] = true;
        blinker.Cells[3, 2] = true;
        blinker.Cells[2, 3] = true;
        blinker.Cells[3, 3] = true;
        return blinker;
    }
    
    #endregion
}