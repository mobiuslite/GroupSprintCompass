using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Sprint
    {
        public List<Userstory> UserStories { get; }
        public string Name { get; set; }

        public Sprint(string name) {

            UserStories = new List<Userstory>();
            Name = name;

        }


        public List<Userstory> GetUserStories() {

            return UserStories;

        }

        public List<string> GetUserStoryNames() {

            List<string> names = new List<string>();

            foreach (Userstory subtask in UserStories)
                names.Add(subtask.name);

            return names;

        }

        public void AddUserStory(string name) {

            UserStories.Add(new Userstory(name));
        
        }

    }

    

    

}
