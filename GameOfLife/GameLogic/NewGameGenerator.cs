using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife.GameLogic
{
    public class NewGameGenerator
    {
        public CurrentGames GenerateGamesFields(CurrentGames currentGames, Field currentField)
        {
            for (int i = 0; i < currentGames.GameCount; i++)
            {
                currentGames.AllCurrentGames.Add(NewFieldGeneration.GenerateFieldOfOneGame(currentField.FieldSize));
            }
            return currentGames;
        }
    }
}
