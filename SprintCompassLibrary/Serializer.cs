using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SprintCompassLibrary
{
    public class Serializer
    {
        public static void Serialize<T>(T serializable, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            string json = JsonConvert.SerializeObject(serializable);
            sw.WriteLine(json);
            sw.Close();
        }

        public static T Deserialize<T>(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
            return default(T);
        }
    }
}
