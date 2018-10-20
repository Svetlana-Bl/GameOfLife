using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class SaveRestoreGame
    {
        private void SaveDataToFile(UniverseField gameUniverse)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Desktop", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, gameUniverse);
            stream.Close();
        }

        private UniverseField RestoreDataFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Desktop", FileMode.Open, FileAccess.Read);
            UniverseField gameUniverse = (UniverseField)formatter.Deserialize(stream);
            return gameUniverse;
        }
    }
}
