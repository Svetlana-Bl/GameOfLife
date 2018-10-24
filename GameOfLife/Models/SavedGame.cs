using System;
using System.Collections.Generic;

namespace GameOfLife
{
    [Serializable]
    public class SavedGame
    {
        public List<bool[,]> gameUniverse;
        public int GameCount;
        public int Iteration;
        public int FieldSize;
    }
}
