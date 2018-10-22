using System;

namespace GameOfLife
{
    public class UniverseField
    {
        private int FieldSize { get; set; }

        public UniverseField(int FieldSize)
        {
            this.FieldSize = FieldSize;
        }

        public bool[,] GenerateField()
        {
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
