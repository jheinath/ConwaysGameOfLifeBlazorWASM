namespace ConwaysGameOfLifeBlazorWASM
{
    public class GameBoard
    {
        public bool[,] Cells { get; }

        private GameBoard(int size, bool[,] startingCells)
        {
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

    }
}
