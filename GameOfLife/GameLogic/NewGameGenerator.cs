using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife.GameLogic
{
    public class NewGameGenerator
    {
        public CurrentGames GenerateGamesFields(CurrentGames currentGames, Field currentField)
        {
            FieldGeneration generateNewField = new FieldGeneration();

            for (int i = 0; i < currentGames.GameCount; i++)
            {
                currentGames.AllCurrentGames.Add(generateNewField.GenerateField(currentField.FieldSize));
            }
            return currentGames;
        }
    }
}
