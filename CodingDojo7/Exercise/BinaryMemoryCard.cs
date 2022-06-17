using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodingDojo7.Exercise
{
    public class BinaryMemoryCard : IMemoryCard
    {
        private BinaryFormatter binaryFormatter = new BinaryFormatter();
        private string savePath = "save.txt";

        private string SavePath => $"./{savePath}";
        
        public void Save(Dictionary<string, object> obj)
        {
            FileStream fs = new FileStream(SavePath, FileMode.OpenOrCreate);
            
            binaryFormatter.Serialize(fs, obj);
        }

        public Dictionary<string, object> Load()
        {
            if (ContainsState())
            {
                return null;
            }
            
            FileStream fs = new FileStream(SavePath, FileMode.OpenOrCreate);

            return (Dictionary<string, object>)binaryFormatter.Deserialize(fs);
        }

        public bool ContainsState() => File.Exists(SavePath);
    }
}