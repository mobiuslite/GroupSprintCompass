using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Sprint
    {
        private List<Userstory> userStories;
        public string Name { get; set; }

        public Sprint(string n) {

            userStories = new List<Userstory>();
            Name = n;

        }


        public List<Userstory> GetUserStories() {

            return userStories;

        }

        public List<string> GetUserStoryNames() {

            List<string> names = new List<string>();

            foreach (Userstory subtask in userStories)
                names.Add(subtask.name);

            return names;

        }

        public void AddUserStory(string name) {

            userStories.Add(new Userstory(name));
        
        }

    }

    public struct Subtask{

        public string name;
        public Subtask(string n) {
            name = n;
        }
    }

    public struct Userstory
    {

        public string name;
        public List<Subtask> subtasks;
        public Userstory(string n)
        {
            name = n;
            subtasks = new List<Subtask>();
        }

        public List<string> GetSubtaskNames() {

            List<string> names = new List<string>();

            foreach (Subtask subtask in subtasks) {

                names.Add(subtask.name);

            }
            return names;
        }

    }

}
