using System;

namespace GameOfLife
{
    public class UserInterfaceMenu
    {
        enum MenuChoice {RunGamesOrStartNew = 1, DeleteAllGames};

        public void MenuOutput() {
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
                var answer=0;

                answer=InputParameterCheck("Choice: ");

                switch (answer)
                {
                    case (int)MenuChoice.RunGamesOrStartNew:
                        GameStart gameStart = new GameStart(InputParameterCheck("Enter field size, then press Enter: "), InputParameterCheck("Enter number of games, then press Enter: "));
                        gameStart.StartAllGames(false);//TODO make logic for parameter
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

        private int InputParameterCheck(string outputString)
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
