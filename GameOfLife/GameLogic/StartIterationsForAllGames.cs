using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.GameLogic;
using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife
{
    public class StartIterationsForAllGames
    {
        private static Mutex mut = new Mutex();
        Field currentField = new Field();
        CurrentGames currentGames=new CurrentGames();
        FieldGeneration generateNewField = new FieldGeneration();
        public void StartAllGames(int FieldSize, int GameCount)
        {
            currentField.FieldSize = FieldSize;
            currentGames.AllCurrentGames = new List<bool[,]>();
            currentGames.GameCount = GameCount;

            for (int i = 0; i < currentGames.GameCount; i++) {
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
                    currentGames.LifeCellsNumber = 0;
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Iteration {0}", j);

                    for (int i = 0; i < currentGames.GameCount; i++)
                    {
                        if (mut.WaitOne() && idThread == Thread.CurrentThread.ManagedThreadId)
                        {

                            outputCurrentField.ShowField(currentGames.AllCurrentGames[i], currentField.FieldSize);
                            currentGames.LifeCellsNumber += countLiveCells.CountOfLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize);
                            Console.WriteLine("Live cells count: {0}", countLiveCells.CountOfLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize));
                            currentGames.AllCurrentGames[i]= lifeCreation.NextGeneration(currentGames.AllCurrentGames[i], currentField.FieldSize);
                        }
                    }
                    Console.WriteLine("Total life cell count {0}", currentGames.LifeCellsNumber);
                    Console.WriteLine("Total games count {0}", currentGames.GameCount);
                    mut.ReleaseMutex();
                }
            }
        }
    }
}
