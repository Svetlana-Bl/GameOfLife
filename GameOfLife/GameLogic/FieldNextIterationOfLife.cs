namespace GameOfLife
{
    public class FieldNextIterationOfLife
    {
        public bool[,] NextGeneration(bool[,] universe, int FieldSize)
        {
            NeighborsLiveCellsCount neighborsLiveCellsCount = new NeighborsLiveCellsCount();
            bool[,] nextGeneration = new bool[FieldSize, FieldSize];
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    int neighborsLiveNumber = neighborsLiveCellsCount.NeighborsLiveCount(i, j, universe, FieldSize);
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
    }
}
