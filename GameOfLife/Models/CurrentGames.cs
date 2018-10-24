using System.Collections.Generic;

namespace GameOfLife.Models
{
    public class CurrentGames
    {
        public List<bool[,]> AllCurrentGames;
        public int GameCount{get; set;}
        public int LifeCellsNumber { get; set; }
    }
}