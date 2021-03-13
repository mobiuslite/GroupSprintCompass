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

    public class Subtask{

        public string name;
        public int hours;
        public Subtask(string n) {
            name = n;
            hours = 0;
        }
        public void updateHours(int newHours)
        {
            hours = newHours;
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

                names.Add("Subtask: " + subtask.name + " Hours: " + subtask.hours);
            }
            return names;
        }

        public bool updateHours(string name, int hours)
        {
            Console.WriteLine(name);
            int index = subtasks.FindIndex(x => $"Subtask: {x.name} Hours: {x.hours}" == name);
            if (index == -1)
                return false;
            subtasks[index].updateHours(hours);
            return true;
        }
    }

}
