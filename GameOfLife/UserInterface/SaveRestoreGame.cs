using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
 
namespace GameOfLife
{
    public class SaveRestoreGame
    {
        public static void SaveDataToFile(SavedGame game)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, game);
            stream.Close();
        }

        public static SavedGame RestoreDataFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Open, FileAccess.Read);
            SavedGame game = (SavedGame)formatter.Deserialize(stream);
            return game;
        }
    }
}
