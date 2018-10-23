using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
 
namespace GameOfLife
{
    public class SaveRestoreGame
    {
        public void SaveDataToFile(IList<bool[,]> gameUniverse)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Desktop\\GameOfLife.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, gameUniverse);
            stream.Close();
        }

        public List<bool[,]> RestoreDataFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Desktop\\GameOfLife.txt", FileMode.Open, FileAccess.Read);
            List<bool[,]> gameUniverse = (List<bool[,]>)formatter.Deserialize(stream);
            return gameUniverse;
        }
    }
}
