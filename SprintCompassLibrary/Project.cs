using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Project
    {
        private string name;
        private string description;
        private List<Sprint> sprints;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public List<Sprint> Sprints
        {
            get
            {
                return sprints;
            }
        }

        public Project(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.sprints = new List<Sprint>();
        }

        public void AddSprint(Sprint sprint)
        {
            sprints.Add(sprint);
        }

        public override string ToString()
        {
            return name;
        }
    }
}