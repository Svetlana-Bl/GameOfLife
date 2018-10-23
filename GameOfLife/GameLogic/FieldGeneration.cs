using System;
using GameOfLife.Model;

namespace GameOfLife
{
    public class FieldGeneration
    {
        public bool[,] GenerateField(int FieldSize)
        {
            Field newfield = new Field();

            bool[,] universeField;
            universeField = new bool[FieldSize, FieldSize];
            Random rand = new Random();
            Console.Clear();
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (rand.Next(0, 2) == 0) universeField[i, j] = true;
                    else universeField[i, j] = false;
                }
            }
            return universeField;
        }
    }
}