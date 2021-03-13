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
        public string TeamName { get; }
        public string ProjectName { get; }
        public DateTime ProjectStartDate { get; }
        public int EstimatedStoryPoints { get; }
        public int HourPerPoint { get; }
        public double AppCost { get; }
        public List<Sprint> Sprints { get; }

        //public string TeamName
        //{
        //    get
        //    {
        //        return teamname;
        //    }
        //}

        //public string ProjectName
        //{
        //    get
        //    {
        //        return projectName;
        //    }
        //}

        //public DateTime StartDate
        //{
        //    get
        //    {
        //        return projectStartDate;
        //    }
        //}

        //public int StoryPointHours
        //{
        //    get
        //    {
        //        return hourPerPoint;
        //    }
        //}

        //public int EstimatedStoryPoints
        //{
        //    get
        //    {
        //        return estimatedStoryPoints;
        //    }
        //}

        //public double AppCost
        //{
        //    get
        //    {
        //        return appCost;
        //    }
        //}

        public Project(string teamname, string projectName, DateTime projectStartDate, int hourPerPoint, int estimatedstorypoints, double appcost, List<Sprint> sprints)
        {
            TeamName = teamname;
            ProjectName = projectName;
            ProjectStartDate = projectStartDate;
            HourPerPoint = hourPerPoint;
            EstimatedStoryPoints = estimatedstorypoints;
            AppCost = appcost;
            if (sprints != null)
            {
                Sprints = sprints;
            } else
            {
                Sprints = new List<Sprint>();
            }
        }

        public void AddSprint(Sprint sprint)
        {
            Sprints.Add(sprint);
        }

        public override string ToString()
        {
            return ProjectName + " by " + TeamName;
        }
    }
}