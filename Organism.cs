using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VirtualEcosystemTwo.Utility;

namespace VirtualEcosystemTwo
{
    public class Organism
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsAlive { get; set; }
        public int Health { get; set; } = 3;
        public string Description { get; set; }
        public string ImageSource { get; set; }

        public Organism()
        {

        }

        public Organism(string name, string description, string type)
        {
            string path = "../../Info/Organisms.xml";
            ReadInfo.ReadOrganism(path);

            Name = name;
            Description = description;
            Type = type;
        }
        public string PrintOrganismInfo(string organismName)
        {
            string info = $"\n {Name}\n Type:{Type}\n >> {Description}";
            if (organismName == Name)
            {
                return info;
            }
            return Print(info);
        }

       
    }
}
