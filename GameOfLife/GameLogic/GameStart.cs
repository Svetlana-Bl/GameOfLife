using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.GameLogic;
using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife
{
    public class GameStart
    {
        private int LifeCellsNumber { get; set; }

        private static Mutex mut = new Mutex();
        Field currentField = new Field();
        CurrentGames currentGames;

        public void StartAllGames(int FieldSize, int GameCount)
        {
            FieldGeneration generateNewField;
            currentField = new Field();
            currentField.FieldSize = FieldSize;
            currentGames.AllCurrentGames = new List<bool[,]>();
            currentGames.GameCount = currentGames.GameCount;

            for (int i = 0; i < currentGames.GameCount; i++) {
                generateNewField = new FieldGeneration();
                currentGames.AllCurrentGames.Add(generateNewField.GenerateField(FieldSize));
            }
            
            for (int i = 0; Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape|| i < currentGames.GameCount; i++)
            {
                Thread GamesThread = new Thread(new ThreadStart(StartIterations));
                GamesThread.Name = String.Format("Thread{0}", i + 1);
                GamesThread.Start();
            }
        }

        private void StartIterations(){
            FieldNextIterationOfLife lifeCreation = new FieldNextIterationOfLife();
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

                    for (int i = 0; i < currentGames.GameCount; i++)
                    {
                        if (mut.WaitOne() && idThread == Thread.CurrentThread.ManagedThreadId)
                        {

                            outputCurrentField.ShowField(currentGames.AllCurrentGames[i], currentField.FieldSize);
                            LifeCellsNumber += countLiveCells.CountOfLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize);
                            Console.WriteLine("Live cells count: {0}", countLiveCells.CountOfLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize));
                            currentGames.AllCurrentGames[i]= lifeCreation.NextGeneration(currentGames.AllCurrentGames[i], currentField.FieldSize);
                        }
                    }
                    Console.WriteLine("Total life cell count {0}", LifeCellsNumber);
                    Console.WriteLine("Total games count {0}", currentGames.GameCount);
                    mut.ReleaseMutex();
                }
            }
        }
    }
}
