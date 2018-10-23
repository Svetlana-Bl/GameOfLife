namespace GameOfLife
{
    public class CountLiveCellsOfField
    {
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