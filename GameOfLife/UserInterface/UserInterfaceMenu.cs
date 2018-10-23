using System;

namespace GameOfLife
{
    public class UserInterfaceMenu
    {
        public void OutputMenu() {
            bool menuOutput = true;
            while (menuOutput)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("-----Welcome to game of Life----");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n--------------Menu--------------");
                Console.WriteLine("1. Start game.");
                Console.WriteLine("2. Delete all games from file.");
                Console.WriteLine("--------------------------------");
                var answer = 0;

                answer = CheckInputParameter("Choice: ");

                switch (answer)
                {
                    case (int)MenuChoice.RunGamesOrStartNew:
                        StartAllGames start = new StartAllGames();
                        start.StartIterationsForAllGames(CheckInputParameter("Enter field size, then press Enter: "), CheckInputParameter("Enter number of games, then press Enter: "));
                        Console.Clear();
                        menuOutput = false;
                        break;
                    case (int)MenuChoice.DeleteAllGames:
                        menuOutput = true;
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