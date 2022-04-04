using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualEcosystemTwo
{
    public class Event
    {
        public string Name { get; set; }

        public Event()
        {
            string[] events =
            {
                "Low Temp",
                "High Temp",
                "Storm",
                "Mine Collapse",
                "Game Over"
            };
        }
    }
}
