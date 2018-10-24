using System;

namespace GameOfLife
{
    public class UserInterfaceMenu
    {
        public void OutputMenu()
        {
            bool menuOutput = true;
            while (menuOutput)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("-----Welcome to game of Life----");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n--------------Menu--------------");
                Console.WriteLine("1. Start new game.");
                Console.WriteLine("2. Restore games from file.");
                Console.WriteLine("--------------------------------");
                var answer = 0;

                answer = CheckInputParameter("Choice: ");
                StartAllGames start = new StartAllGames();
                switch (answer)
                {
                    case (int)MenuChoice.RunGamesOrStartNew:
                        
                        var fieldSize = CheckInputParameter("Enter field size, then press Enter: ");
                        var gameCount = CheckInputParameter("Enter number of games, then press Enter: ");
                        GamePause.On();
                        start.GameParametersSet(fieldSize, gameCount);
                        start.StartIterationsForAllGames(false);
                        Console.Clear();
                        menuOutput = false;
                        break;
                    case (int)MenuChoice.RestoreAllGames:
                        GamePause.On();
                        start.StartIterationsForAllGames(true);
                        Console.Clear();
                        menuOutput = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Write the number of your choice.");
                        menuOutput = false;
                        break;
                }
            }
            Console.ReadKey();
        }

        private int CheckInputParameter(string outputString)
        {
            bool Valid = false;
            int parameterToInt;
            string parameter = "";

            Console.WriteLine(outputString);
            while (Valid == false)
            {
                parameter = Console.ReadLine();
                if (int.TryParse(parameter, out parameterToInt))
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please, try again!");
                }
            }
            return Convert.ToInt32(parameter);
        }
    }
}