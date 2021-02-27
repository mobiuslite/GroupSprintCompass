using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class TeamMember
    {
        private string name;
        private string position;
        private string contact;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }
        }

        public TeamMember(string name, string position, string contact)
        {
            this.name = name;
            this.position = position;
            this.contact = contact;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
