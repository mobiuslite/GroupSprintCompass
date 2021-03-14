using System;
using System.Collections.Generic;
using System.Text;

namespace SprintCompassLibrary
{
    [Serializable]
    public class Subtask
    {

        public string name;
        public Subtask(string name)
        {
            this.name = name;
        }
    }
}
