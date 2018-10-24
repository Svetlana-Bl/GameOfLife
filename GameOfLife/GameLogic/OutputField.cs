using System;

namespace GameOfLife.GameLogic
{
    public class OutputField
    {
        public static void ShowField(bool[,] universeToShow, int FieldSize)
        {
            Console.WriteLine(" ");
            char outputValue;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (universeToShow[i, j] == true) outputValue = '■';
                    else outputValue = '-';
                    Console.Write(String.Format("{0,3}", outputValue));
                }
                Console.WriteLine();
            }
        }
    }
}
