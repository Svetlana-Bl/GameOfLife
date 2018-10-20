using System;

namespace GameOfLife
{
    class UserInterfaceMenu
    {
        enum MenuChoice {RunGamesOrStartNew = 1, SaveGamesToFile, DeleteAllGames};

        public void MenuOutput() {
            bool menuOutput = true;
            bool choiceEnter = true;
            while (menuOutput)
            {
                Console.WriteLine("-----Welcome to game of Life----");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n--------------Menu--------------");
                Console.WriteLine("1. Start game.");
                Console.WriteLine("2. Save to file.");
                Console.WriteLine("3. Delete all games.");
                Console.WriteLine("--------------------------------");
                var answer=0;

                if (choiceEnter)
                {
                    Console.WriteLine("\nChoice : ");
                    answer = Convert.ToInt32(Console.ReadLine());
                }

                switch (answer)
                {
                    case (int)MenuChoice.RunGamesOrStartNew:
                        GameStart gameStart = new GameStart();
                        gameStart.Start(InputParameterCheck("Enter field size, then press Enter: "), InputParameterCheck("Enter number of games, then press Enter: "));
                        Console.Clear();
                        break;
                    case (int)MenuChoice.SaveGamesToFile:

                        break;
                    case (int)MenuChoice.DeleteAllGames:

                        break;
                    default:
                        Console.WriteLine("Incorrect input. Write the number of your choice.");
                        break;
                }
            }
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
