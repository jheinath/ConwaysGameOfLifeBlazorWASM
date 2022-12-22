using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeBlazorWASM.Domain
{
    public class GameBoard
    {
        public Array2D Cells { get; private set; }
        public const int Size = 50;
        private IEnumerable<TemplatePattern> TemplatePatterns { get; }
        public IEnumerable<TemplatePattern> OscillatorTemplatePattern =>
            TemplatePatterns.Where(x => x.PatternType == PatternType.Oscillator);
        public IEnumerable<TemplatePattern> SpaceshipTemplatePattern =>
            TemplatePatterns.Where(x => x.PatternType == PatternType.Spaceship);

        private GameBoard()
        {
            TemplatePatterns = TemplatePatternsLibrary.GetTemplatePatterns();
            Cells = new Array2D(Size, Size);
        }

        public static GameBoard Create()
        {
            return new GameBoard();
        }

        public async Task<bool> Update()
        {
            var updatedCells = new Array2D(Cells.Height, Cells.Width);
            var taskCollection = new List<Task<bool>>();
            for (var i = 0; i < Size; i += 10)
            {
                var row = i;
                taskCollection.Add(Task.Run(() => UpdateCellArea(0, row, Size - 1, row + 9, updatedCells)));
            }
            var tasks = Task.WhenAll(taskCollection);

            var results = await tasks;
            var isAnyCellAlive = results.Any(x => x);

            Cells = updatedCells;
            return isAnyCellAlive;
        }

        private bool UpdateCellArea(int startX, int startY, int endX, int endY, Array2D updatedCells)
        {
            var result = false;
            for (var i = startX; i <= endX; i++)
            {
                for (var j = startY; j <= endY; j++)
                {
                    var shouldCellBeAlive = ShouldCellBeAlive(i, j);
                    updatedCells[i, j] = shouldCellBeAlive;
                    if (shouldCellBeAlive)
                        result = true;
                }
            }

            return result;
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
                    if ((i + x < 0 || i + x >= Cells.Width) ||
                        (j + y < 0 || j + y >= Cells.Height)) continue;

                    if ((i == 0 && j == 0) == false)
                        result.Add(Cells[i+x, j+y]);
                }
            }


            return result;
        }

        public void Randomize()
        {
            var random = new Random();

            for (var i = 0; i < Cells.Width; i++)
            {
                for (var j = 0; j < Cells.Height; j++)
                {
                    Cells[i, j] = random.Next(-1, 2) == 0;
                }
            }
        }

        public void Reset()
        {
            for (var i = 0; i < Cells.Width; i++)
            {
                for (var j = 0; j < Cells.Height; j++)
                {
                    Cells[i, j] = false;
                }
            }
        }

        public void ApplyTemplatePattern(string templatePatternName, int x, int y)
        {
            var selectedTemplate = TemplatePatterns.FirstOrDefault(pattern => pattern.Name == templatePatternName);
            if (selectedTemplate is null) return;
            
            for (var i = 0; i < selectedTemplate.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < selectedTemplate.Cells.GetLength(1); j++)
                {
                    var calculatedX = i + x;
                    var calculatedY = y + j;
                    if (calculatedX >= Cells.Width) return;
                    if (calculatedY >= Cells.Height) return;
                    Cells[calculatedX, calculatedY] = selectedTemplate.Cells[i, j];
                }
            }
        }
    }
}
