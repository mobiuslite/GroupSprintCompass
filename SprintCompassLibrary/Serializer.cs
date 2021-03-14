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
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                string json = JsonConvert.SerializeObject(serializable, Formatting.Indented);
                sw.WriteLine(json);
                sw.Close();
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"File not found, message:{fex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception: {ex.Message}");
            }
        }

        public static T Deserialize<T>(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    StreamReader sr = new StreamReader(filename);
                    return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                }
                return default(T);

            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"File not found, message:{fex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception: {ex.Message}");
            }
            return default(T);
        }

    }
}
