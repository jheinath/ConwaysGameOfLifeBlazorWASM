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
            GetPulsar(),
            GetPentaDecathlon(),

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

    private static TemplatePattern GetPulsar()
    {
        var pulsar = new TemplatePattern
        {
            Name = "Pulsar",
            Cells = new bool[13, 13],
            PatternType = PatternType.Oscillator
        };
        pulsar.Cells[2, 0] = true;
        pulsar.Cells[3, 0] = true;
        pulsar.Cells[9, 0] = true;
        pulsar.Cells[10, 0] = true;

        pulsar.Cells[3, 1] = true;
        pulsar.Cells[4, 1] = true;
        pulsar.Cells[8, 1] = true;
        pulsar.Cells[9, 1] = true;

        pulsar.Cells[0, 2] = true;
        pulsar.Cells[3, 2] = true;
        pulsar.Cells[5, 2] = true;
        pulsar.Cells[7, 2] = true;
        pulsar.Cells[9, 2] = true;
        pulsar.Cells[12, 2] = true;

        pulsar.Cells[0, 3] = true;
        pulsar.Cells[1, 3] = true;
        pulsar.Cells[2, 3] = true;
        pulsar.Cells[4, 3] = true;
        pulsar.Cells[5, 3] = true;
        pulsar.Cells[7, 3] = true;
        pulsar.Cells[8, 3] = true;
        pulsar.Cells[10, 3] = true;
        pulsar.Cells[11, 3] = true;
        pulsar.Cells[12, 3] = true;

        pulsar.Cells[1, 4] = true;
        pulsar.Cells[3, 4] = true;
        pulsar.Cells[5, 4] = true;
        pulsar.Cells[7, 4] = true;
        pulsar.Cells[9, 4] = true;
        pulsar.Cells[11, 4] = true;

        pulsar.Cells[2, 5] = true;
        pulsar.Cells[3, 5] = true;
        pulsar.Cells[4, 5] = true;
        pulsar.Cells[8, 5] = true;
        pulsar.Cells[9, 5] = true;
        pulsar.Cells[10, 5] = true;

        //Inversed from here

        pulsar.Cells[2, 7] = true;
        pulsar.Cells[3, 7] = true;
        pulsar.Cells[4, 7] = true;
        pulsar.Cells[8, 7] = true;
        pulsar.Cells[9, 7] = true;
        pulsar.Cells[10, 7] = true;

        pulsar.Cells[1, 8] = true;
        pulsar.Cells[3, 8] = true;
        pulsar.Cells[5, 8] = true;
        pulsar.Cells[7, 8] = true;
        pulsar.Cells[9, 8] = true;
        pulsar.Cells[11, 8] = true;

        pulsar.Cells[0, 9] = true;
        pulsar.Cells[1, 9] = true;
        pulsar.Cells[2, 9] = true;
        pulsar.Cells[4, 9] = true;
        pulsar.Cells[5, 9] = true;
        pulsar.Cells[7, 9] = true;
        pulsar.Cells[8, 9] = true;
        pulsar.Cells[10, 9] = true;
        pulsar.Cells[11, 9] = true;
        pulsar.Cells[12, 9] = true;

        pulsar.Cells[0, 10] = true;
        pulsar.Cells[3, 10] = true;
        pulsar.Cells[5, 10] = true;
        pulsar.Cells[7, 10] = true;
        pulsar.Cells[9, 10] = true;
        pulsar.Cells[12, 10] = true;

        pulsar.Cells[3, 11] = true;
        pulsar.Cells[4, 11] = true;
        pulsar.Cells[8, 11] = true;
        pulsar.Cells[9, 11] = true;

        pulsar.Cells[2, 12] = true;
        pulsar.Cells[3, 12] = true;
        pulsar.Cells[9, 12] = true;
        pulsar.Cells[10, 12] = true;

        return pulsar;
    }

    private static TemplatePattern GetPentaDecathlon()
    {
        var pentaDecathlon = new TemplatePattern
        {
            Name = "Penta-Decathlon",
            Cells = new bool[3, 16],
            PatternType = PatternType.Oscillator
        };
        pentaDecathlon.Cells[1, 0] = true;

        pentaDecathlon.Cells[0, 1] = true;
        pentaDecathlon.Cells[2, 1] = true;

        pentaDecathlon.Cells[0, 4] = true;
        pentaDecathlon.Cells[1, 4] = true;
        pentaDecathlon.Cells[2, 4] = true;

        pentaDecathlon.Cells[0, 5] = true;
        pentaDecathlon.Cells[1, 5] = true;
        pentaDecathlon.Cells[2, 5] = true;

        pentaDecathlon.Cells[1, 6] = true;
        
        //Inversed from here on
        
        pentaDecathlon.Cells[1, 9] = true;
        
        pentaDecathlon.Cells[0, 10] = true;
        pentaDecathlon.Cells[1, 10] = true;
        pentaDecathlon.Cells[2, 10] = true;
        
        pentaDecathlon.Cells[0, 11] = true;
        pentaDecathlon.Cells[1, 11] = true;
        pentaDecathlon.Cells[2, 11] = true;
        
        pentaDecathlon.Cells[0, 14] = true;
        pentaDecathlon.Cells[2, 14] = true;
        
        pentaDecathlon.Cells[1, 15] = true;

        return pentaDecathlon;
    }

    #endregion
}