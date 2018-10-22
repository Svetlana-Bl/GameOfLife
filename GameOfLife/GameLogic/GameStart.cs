using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.GameLogic;

namespace GameOfLife
{
    public class GameStart
    {
        private static Mutex mut = new Mutex();
        private int LifeCellsNumber { get; set; }
        private int FieldSize { get; set; }
        private int GameCount { get; set; }
        private List<bool[,]> allCurrentGames;

        public GameStart(int fieldSize, int gameCount)
        {
            if (fieldSize < 3) FieldSize = 3;
            else if(fieldSize>20) FieldSize = 20;
            else FieldSize = fieldSize;

            GameCount = gameCount;
            allCurrentGames = new List<bool[,]>();
        }

        public void StartAllGames(bool generateThousandGames)
        {
            UniverseField newField;
            if (generateThousandGames == true)
            {
                //Thread GenerationThread = new Thread(new ThreadStart(GenerateThousandGames));
                //GenerationThread.Name = String.Format("ThreadGenerator");
                //GenerationThread.Start();
            }
            else {
                for (int i = 0; i < GameCount; i++) {
                    newField = new UniverseField(FieldSize);
                    allCurrentGames.Add(newField.GenerateField());
                }
            }

            //Thread StopThread = new Thread(new ThreadStart(StopIterations));
            //StopThread.Name = String.Format("StopThread");
            //StopThread.Start();

            for (int i = 0; Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape|| i < GameCount; i++)
            {
                Thread GamesThread = new Thread(new ThreadStart(StartIterations));
                GamesThread.Name = String.Format("Thread{0}", i + 1);
                GamesThread.Start();
            }
        }

        //private void StopIterations() {
        //    while (!Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) { }
        //    //Thread.CurrentThread.Suspend();
            
        //    //Save to file
        //    SaveRestoreGame saveAllGamesToFile = new SaveRestoreGame();
        //    saveAllGamesToFile.SaveDataToFile(allCurrentGames);
        //}

        //private void GenerateThousandGames() {
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        UniverseField newField = new UniverseField(FieldSize);
        //        allCurrentGames.Add(newField.GenerateField());
        //    }
        //}

        private void StartIterations(){
            FieldLifeCreation lifeCreation = new FieldLifeCreation();
            CountLiveCellsOfField countLiveCells = new CountLiveCellsOfField();
            OutputField outputCurrentField = new OutputField();
            for (int j = 0; !(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape); j++) {
                if (mut.WaitOne(1000))
                {
                    int idThread=Thread.CurrentThread.ManagedThreadId;
                    LifeCellsNumber = 0;
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Iteration {0}", j);

                    for (int i = 0; i < GameCount; i++)
                    {
                        if (mut.WaitOne() && idThread == Thread.CurrentThread.ManagedThreadId)
                        {

                            outputCurrentField.ShowField(allCurrentGames[i],FieldSize);
                            LifeCellsNumber += countLiveCells.CountOfLiveCells(allCurrentGames[i], FieldSize);
                            Console.WriteLine("Live cells count: {0}", countLiveCells.CountOfLiveCells(allCurrentGames[i], FieldSize));
                            allCurrentGames[i]= lifeCreation.LifeCreation(allCurrentGames[i], FieldSize);
                        }
                    }
                    Console.WriteLine("Total life cell count {0}", LifeCellsNumber);
                    Console.WriteLine("Total games count {0}", GameCount);
                    mut.ReleaseMutex();
                }
            }
        }
    }
}
