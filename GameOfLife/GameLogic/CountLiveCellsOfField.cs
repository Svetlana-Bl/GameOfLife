namespace GameOfLife
{
    public class LiveCellsOfField
    {
        public int CountLiveCells(bool[,] universe, int FieldSize)
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