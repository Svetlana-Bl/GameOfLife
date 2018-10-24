using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.GameLogic;
using GameOfLife.Model;
using GameOfLife.Models;

namespace GameOfLife
{
    public class StartAllGames
    {
        public static bool StopAllGamesOutput = false;
        private static Mutex mut = new Mutex();

        private Field currentField = new Field();
        private SavedGame savedGame = new SavedGame();
        private CurrentGames currentGames = new CurrentGames();
        private List<Thread> currentThreads = new List<Thread>();
        private NewGameGenerator newGameGenerator = new NewGameGenerator();
        private int IterationNumber = 0;


        public void GameParametersSet(int FieldSize, int GameCount)
        {
            currentField.FieldSize = FieldSize;
            currentGames.AllCurrentGames = new List<bool[,]>();
            currentGames.GameCount = GameCount;
            newGameGenerator.GenerateGamesFields(currentGames, currentField);
        }

        public void StartIterationsForAllGames(bool restoreFromFile)
        {
            if (restoreFromFile == true)
            {
                savedGame = SaveRestoreGame.RestoreDataFromFile();
                currentField.FieldSize = savedGame.FieldSize;
                currentGames.AllCurrentGames = savedGame.gameUniverse;
                currentGames.GameCount = savedGame.GameCount;
                IterationNumber = savedGame.Iteration;
            }
            for (int i = 0; i < currentGames.GameCount; i++)
            {
                if (StopAllGamesOutput == false)
                {
                    Thread GamesThread = new Thread(new ThreadStart(StartIterations));
                    GamesThread.Name = String.Format("Thread{0}", i + 1);
                    currentThreads.Add(GamesThread);
                    currentThreads[i].Start();
                }
            }
        }

        public static void StopIterations()
        {
            StopAllGamesOutput = true;
        }

        public static void ContinueIterations() {
            StopAllGamesOutput = false;
        }

        private void StartIterations(){
            LiveCellsOfField countLiveCells = new LiveCellsOfField();
            
                for (int j = 0; !(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape); j++)
                {
                    if (mut.WaitOne(1000))
                    {
                        if (StopAllGamesOutput == false)
                        {
                            IterationNumber++;
                            int idThread = Thread.CurrentThread.ManagedThreadId;
                            currentGames.LifeCellsNumber = 0;
                            Thread.Sleep(1000);
                            //Console.Clear();
                            Console.SetCursorPosition(0, 0);//new way, more clear
                            Console.WriteLine("Iteration {0}", IterationNumber);

                            for (int i = 0; i < currentGames.GameCount; i++)
                            {
                                if (mut.WaitOne() && idThread == Thread.CurrentThread.ManagedThreadId)
                                {
                                    OutputField.ShowField(currentGames.AllCurrentGames[i], currentField.FieldSize);
                                    currentGames.LifeCellsNumber += countLiveCells.CountLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize);
                                    Console.WriteLine("Live cells count: {0}", countLiveCells.CountLiveCells(currentGames.AllCurrentGames[i], currentField.FieldSize));
                                    currentGames.AllCurrentGames[i] = FieldNextGeneration.NextIterationOfLife(currentGames.AllCurrentGames[i], currentField.FieldSize);
                                }
                            }
                            Console.WriteLine("\nTotal life cell count {0}", currentGames.LifeCellsNumber);
                            Console.WriteLine("Total games count {0}", currentGames.GameCount);
                        }
                        else
                        {
                            SavedGame gameToSave = new SavedGame();
                            gameToSave.gameUniverse = currentGames.AllCurrentGames;
                            gameToSave.Iteration = IterationNumber;
                            gameToSave.GameCount = currentGames.GameCount;
                            gameToSave.FieldSize = currentField.FieldSize;
                            SaveRestoreGame.SaveDataToFile(gameToSave);
                            Console.WriteLine("Pause. Press c to continue");
                            Environment.Exit(0);
                        }
                        mut.ReleaseMutex();
                    }
                }
        }
    }
}
