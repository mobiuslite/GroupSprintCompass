using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Sprint
    {
        private List<Subtask> subtasks;
        public string Name { get; set; }

        public Sprint(string n) {

            subtasks = new List<Subtask>();
            Name = n;

        }


        public List<Subtask> GetSubtasks() {

            return subtasks;

        }

        public List<string> GetSubtasksName() {

            List<string> names = new List<string>();

            foreach (Subtask subtask in subtasks)
                names.Add(subtask.name);

            return names;

        }

        public void AddSubtasks(string name) {

            subtasks.Add(new Subtask(name));
        
        }

    }

    public struct Subtask{

        public string name;
        public Subtask(string n) {
            name = n;
        }
    }

}
