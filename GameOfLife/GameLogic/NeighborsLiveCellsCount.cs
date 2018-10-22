using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class NeighborsLiveCellsCount
    {
        public int NeighborsLiveCount(int i, int j, bool[,] universe, int FieldSize)
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

    }
}
