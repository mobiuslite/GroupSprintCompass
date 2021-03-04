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
        private string projectName;
        private DateTime projectStartDate;
        private int hourPerPoint;
        private int estimatedStoryPoints;
        private double appCost;
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
                return projectName;
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
                return hourPerPoint;
            }
        }

        public int EstimatedStoryPoints
        {
            get
            {
                return estimatedStoryPoints;
            }
        }

        public double AppCost
        {
            get
            {
                return appCost;
            }
        }

        public Project(string teamname, string productname, DateTime projectStartDate, int storypointcost, int estimatedstorypoints, double appcost, List<Sprint> sprints)
        {
            this.teamname = teamname;
            this.projectName = productname;
            this.projectStartDate = projectStartDate;
            this.hourPerPoint = storypointcost;
            this.estimatedStoryPoints = estimatedstorypoints;
            this.appCost = appcost;
            this.sprints = sprints;
        }

        public void AddSprint(Sprint sprint)
        {
            sprints.Add(sprint);
        }

        public override string ToString()
        {
            return projectName + " by " +teamname;
        }
    }
}