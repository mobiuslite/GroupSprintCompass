using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SprintCompassLibrary
{
    public class Serializer
    {
        public static void Serialize(List<TeamMember> teamMembers, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            string teamJson = JsonConvert.SerializeObject(teamMembers);
            sw.WriteLine(teamJson);
            sw.Close();
        }

        public static List<TeamMember> Deserialize(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            return JsonConvert.DeserializeObject<List<TeamMember>>(sr.ReadToEnd());
        }
    }
}
