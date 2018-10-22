namespace GameOfLife
{
    public class GameRules
    {
        public bool[,] LifeCreation(bool[,] universe, int FieldSize)
        {
            bool[,] nextGeneration = new bool[FieldSize, FieldSize];
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    int neighborsLiveNumber = NeighborsLiveCount(i, j, universe, FieldSize);
                    if (universe[i, j] == true)
                    {
                        if (neighborsLiveNumber < 2 || neighborsLiveNumber > 3) nextGeneration[i, j] = false;
                        if (neighborsLiveNumber == 2 || neighborsLiveNumber == 3) nextGeneration[i, j] = true;
                    }
                    else if (neighborsLiveNumber == 3) nextGeneration[i, j] = true;
                }
            }
            universe = nextGeneration;
            return universe;
        }

        private int NeighborsLiveCount(int i, int j, bool[,] universe, int FieldSize)
        {
            var LiveNeighborsNumber = 0;
            int startRowCoordinate = i - 1, endRowCoordinate = i + 2, startColumnCoordinate = j - 1, endColumnCoordinate = j + 2;

            if (i == 0) startRowCoordinate = i;
            if (i == FieldSize - 1) endRowCoordinate = FieldSize;
            if (j == 0) startColumnCoordinate = j;
            if (j == FieldSize - 1) endColumnCoordinate = FieldSize;

            for (int rowCoordinate = startRowCoordinate; rowCoordinate < endRowCoordinate; rowCoordinate++)
            {
                for (int columnCoordinate = startColumnCoordinate; columnCoordinate < endColumnCoordinate; columnCoordinate++)
                {
                    if (rowCoordinate == i && columnCoordinate == j) continue;
                    if (universe[rowCoordinate, columnCoordinate] == true) LiveNeighborsNumber++;
                }
            }
            return LiveNeighborsNumber;
        }

        public int CountOfLiveCells(bool[,] universe, int FieldSize)
        {
            int cellsCount = 0;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (universe[i, j] == true)
                        cellsCount++;
                }
            }
            return cellsCount;
        }
    }
}
