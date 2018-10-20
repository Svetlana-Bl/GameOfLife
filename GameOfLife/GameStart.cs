using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    class GameStart
    {
        private static Mutex mut = new Mutex();
        private int LifeCellsNumber { get; set; }
        private int IterationNumber { get; set; }
        private int FieldSize { get; set; }
        private int GameCount { get; set; }
        private bool[,] universeField;
        private List<bool[,]> allCurrentGames;

        public void Start(int fieldSize, int gameCount)
        {
            FieldSize = fieldSize;
            GameCount = gameCount;
            UniverseField newField;
            //for (int i = 0; i < gameCount; i++) {
                newField = new UniverseField(FieldSize);
                newField.GenerateField();
            //}
            universeField = newField.GenerateField();
            ThreadTest();

            //Thread.Sleep(1000);
            //while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            //{
            //    Console.Clear();
            //    Console.WriteLine("Universe:\n");
            //    LifeCreation();
            //    ShowField();
            //    StatisticOutput();
            //    IterationNumber++;
            //    Console.WriteLine("Press ESC to stop and back to menu.");
            //    Thread.Sleep(1000);
            //}

        }

        public void ThreadTest() {

            for (int i = 0; i < GameCount; i++)
            {
                Thread newThread = new Thread(new ThreadStart(Test));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

        }

        public void Test(){
            for (int i = 1; i < GameCount; i++) {
                if (mut.WaitOne(1000))
                {
                    ShowField();
                    Thread.Sleep(2000);
                    mut.ReleaseMutex();
                    Console.WriteLine("{0} has released the mutex",Thread.CurrentThread.Name);
                }else
                {
                    Console.WriteLine("{0} will not acquire the mutex",Thread.CurrentThread.Name);
                }
            }
        }

        private int NeighborsLiveCount(int i, int j)
        {
            var LiveNeighborsNumber = 0;
            int startRowCoordinate = i - 1, endRowCoordinate = i + 2, startColumnCoordinate = j - 1, endColumnCoordinate = j + 2;

            if (i == 0) startRowCoordinate = i;
            if (i == FieldSize - 1) endRowCoordinate = FieldSize;
            if (j == 0) startColumnCoordinate = j;
            if (j == FieldSize - 1) endColumnCoordinate = FieldSize;

            for (int rowCoordinate = startRowCoordinate; rowCoordinate < endRowCoordinate; rowCoordinate++)
            {
                for (int columnCoordinate = startColumnCoordinate; columnCoordinate < endColumnCoordinate; columnCoordinate++)
                {
                    if (rowCoordinate == i && columnCoordinate == j) continue;
                    if (universeField[rowCoordinate, columnCoordinate] == true) LiveNeighborsNumber++;
                }
            }
            return LiveNeighborsNumber;
        }

        private void LifeCreation()
        {
            bool[,] nextGeneration = new bool[FieldSize, FieldSize];
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    int neighborsLiveNumber = NeighborsLiveCount(i, j);
                    if (universeField[i, j] == true)
                    {
                        if (neighborsLiveNumber < 2 || neighborsLiveNumber > 3) nextGeneration[i, j] = false;
                        if (neighborsLiveNumber == 2 || neighborsLiveNumber == 3) nextGeneration[i, j] = true;
                    }
                    else if (neighborsLiveNumber == 3) nextGeneration[i, j] = true;
                }
            }
            universeField = nextGeneration;
            CountOfLiveCells();
        }

        private void CountOfLiveCells()
        {
            int cellsCount = 0;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (universeField[i, j] == true)
                        cellsCount++;
                }
            }
            LifeCellsNumber = cellsCount;
        }

        private void ShowField()
        {
            char outputValue;
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (universeField[i, j] == true) outputValue = '■';
                    else outputValue = '-';
                    Console.Write(String.Format("{0,3}", outputValue));
                }
                Console.WriteLine();
            }
        }
    }
}
