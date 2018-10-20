using System;

namespace GameOfLife
{
    public class UniverseField
    {
        private int FieldSize { get; set; }
        private bool[,] universeField;

        public UniverseField(int FieldSize)
        {
            if (FieldSize <= 3)
            {
                Console.WriteLine("Entered size is too short. Min field size is 3 by default.");
                this.FieldSize = 3;
            }
            else
            {
                if (FieldSize >= 20)
                {
                    Console.WriteLine("Entered size is too large. Max field size is 20 by default.");
                    this.FieldSize = 20;
                }
                else
                    this.FieldSize = FieldSize;
            }
        }

        public bool[,] GenerateField()
        {
            Console.Clear();
            Console.WriteLine("Generated field:");
            universeField = new bool[FieldSize, FieldSize];
            Random rand = new Random();

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
