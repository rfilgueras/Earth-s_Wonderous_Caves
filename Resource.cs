using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VirtualEcosystemTwo.Utility;

namespace VirtualEcosystemTwo
{
    public class Resource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ResourceAmount { get; set; }
        public int Quantity { get; set; }
        public bool IsEdible { get; set; }
        public string ImageSource { get; set; }

        public Resource()
        {

        }
        public Resource(string name, string description, int resourceAmount, int quantity, string imageSource)
        {
            Name = name;
            Description = description;
            ResourceAmount = resourceAmount;
            Quantity = quantity;
            ImageSource = imageSource;
        }

        public string PrintResourceInfo(string name)
        {
            string info = $"\n Name: {Name}\n Available: {ResourceAmount}X\n>> {Description}\n\n Collected: {Quantity}X";
            if (Name == name && name != null)
            {
                return info;
            }
            return Print(info);
        }

        public int CollectResource(string resourceName)
        {
            if (resourceName == Name)
            {
                ResourceAmount--;
            }            
            return ResourceAmount;
        }

        public int AddQuantity(string resourceName)
        {
            if (resourceName == Name)
            {
                Quantity++;
            }
            return Quantity;
        }

        public int SetRandomSpawn()
        {
            Random rad = new Random();
            int spawnAmount = rad.Next(5, 10);
            return spawnAmount;
        }


    }
}
