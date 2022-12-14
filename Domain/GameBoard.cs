using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeBlazorWASM.Domain
{
    public class GameBoard
    {
        public bool[,] Cells { get; private set; }
        public IEnumerable<TemplatePattern> TemplatePatterns { get; }
        public IEnumerable<TemplatePattern> OscillatorTemplatePattern =>
            TemplatePatterns.Where(x => x.PatternType == PatternType.Oscillator);
        public IEnumerable<TemplatePattern> SpaceshipTemplatePattern =>
            TemplatePatterns.Where(x => x.PatternType == PatternType.Spaceship);

        public bool IsNoCellAlive()
        {
            for (var i = 0; i < Cells.GetLength(0); i++)
            {
                for (var j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j]) return false;
                }
            }

            return true;
        }
        private GameBoard(int size, bool[,] startingCells)
        {
            TemplatePatterns = GetTemplatePatterns();
            Cells = new bool[size, size];

            for (var i = 0; i < Cells.GetLength(0); i++)
            {
                for (var j = 0; j < Cells.GetLength(1); j++)
                {
                    if (startingCells[i, j])
                    {
                        Cells[i, j] = true;
                    }
                    else
                    {
                        Cells[i, j] = false;
                    }
                }
            }
        }

        public static GameBoard Create(int size, bool[,] startingCells)
        {
            return new GameBoard(size, startingCells);
        }

        public void Update()
        {
            var currentCells = Cells;
            var updatedCells = new bool[Cells.GetLength(0), Cells.GetLength(1)];
            for (var i = 0; i < currentCells.GetLength(0); i++)
            {
                for (var j = 0; j < currentCells.GetLength(1); j++)
                {
                    updatedCells[i, j] = ShouldCellBeAlive(i, j);
                }
            }

            Cells = updatedCells;
        }

        private bool ShouldCellBeAlive(int x, int y)
        {
            var isCellCurrentlyAlive = Cells[x, y];

            var neighborCells = GetNeighborCells(x, y);
            var neighborCellsAliveCount = neighborCells.Count(cell => cell);


            if (isCellCurrentlyAlive == false && neighborCellsAliveCount == 3)
                return true;

            if (isCellCurrentlyAlive && neighborCellsAliveCount < 2)
                return false;

            if (isCellCurrentlyAlive && (neighborCellsAliveCount == 2 || neighborCellsAliveCount == 3))
                return true;

            if (isCellCurrentlyAlive && neighborCellsAliveCount > 3)
                return false;

            return false;
        }

        private IEnumerable<bool> GetNeighborCells(int x, int y)
        {
            var result = new List<bool>();

            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if ((i + x < 0 || i + x >= Cells.GetLength(0)) ||
                        (j + y < 0 || j + y >= Cells.GetLength(1))) continue;

                    if ((i == 0 && j == 0) == false)
                        result.Add(Cells[i+x, j+y]);
                }
            }


            return result;
        }

        public void Randomize()
        {
            var random = new Random();

            for (var i = 0; i < Cells.GetLength(0); i++)
            {
                for (var j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = random.Next(-1, 2) == 0;
                }
            }
        }

        public void Reset()
        {
            for (var i = 0; i < Cells.GetLength(0); i++)
            {
                for (var j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = false;
                }
            }
        }

        private static IEnumerable<TemplatePattern> GetTemplatePatterns()
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
            
            return new List<TemplatePattern>
            {
                blinker,
                toad,
            };
        }

        public void ApplyTemplatePattern(string templatePatternName, int x, int y)
        {
            var selectedTemplate = TemplatePatterns.FirstOrDefault(pattern => pattern.Name == templatePatternName);
            if (selectedTemplate is null) return;
            
            for (var i = 0; i < selectedTemplate.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < selectedTemplate.Cells.GetLength(1); j++)
                {
                    Cells[i + x, y + j] = selectedTemplate.Cells[i, j];
                }
            }
        }
    }
}
