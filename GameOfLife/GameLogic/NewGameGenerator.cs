using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife.GameLogic
{
    public class NewGameGenerator
    {
        public CurrentGames GenerateGamesFields(CurrentGames currentGames, Field currentField)
        {
            NewFieldGeneration generateNewField = new NewFieldGeneration();

            for (int i = 0; i < currentGames.GameCount; i++)
            {
                currentGames.AllCurrentGames.Add(generateNewField.GenerateFieldOfOneGame(currentField.FieldSize));
            }
            return currentGames;
        }
    }
}
