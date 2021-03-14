using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Userstory
    {

        public string name;
        public List<Subtask> subtasks { get; }
        public Userstory(string name)
        {
            this.name = name;
            subtasks = new List<Subtask>();
        }

        public List<string> GetSubtaskNames()
        {

            List<string> names = new List<string>();

            foreach (Subtask subtask in subtasks)
            {

                names.Add(subtask.name);

            }
            return names;
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
