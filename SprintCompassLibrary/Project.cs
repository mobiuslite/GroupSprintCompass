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
        private string teamname;
        private string productname;
        private DateTime projectStartDate;
        private int storypointcost;
        private int estimatedstorypoints;
        private double appcost;
        private List<Sprint> sprints;

        public string TeamName
        {
            get
            {
                return teamname;
            }
        }

        public string ProjectName
        {
            get
            {
                return productname;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return projectStartDate;
            }
        }

        public int StoryPointHours
        {
            get
            {
                return storypointcost;
            }
        }

        public int EstimatedStoryPoints
        {
            get
            {
                return estimatedstorypoints;
            }
        }

        public double AppCost
        {
            get
            {
                return appcost;
            }
        }

        public Project(string teamname, string productname, DateTime projectStartDate, int storypointcost, int estimatedstorypoints, double appcost, List<Sprint> sprints)
        {
            this.teamname = teamname;
            this.productname = productname;
            this.projectStartDate = projectStartDate;
            this.storypointcost = storypointcost;
            this.estimatedstorypoints = estimatedstorypoints;
            this.appcost = appcost;
            this.sprints = sprints;
        }

        public void AddSprint(Sprint sprint)
        {
            sprints.Add(sprint);
        }

        public override string ToString()
        {
            return productname + " by " +teamname;
        }
    }
}