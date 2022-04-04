using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace VirtualEcosystemTwo
{
    class ReadInfo
    {
        public static List<Item> ReadItem (string fileName)
        {
            List<Item> item = new List<Item>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList itemList = root.SelectNodes("/Items/Item");
            foreach (XmlElement i in itemList)
            {
                Item tempItem = new Item
                {
                    Name = i.GetAttribute("name"),
                    Description = i.GetAttribute("description"),
                    Use = i.GetAttribute("use"),
                    ImageSource = i.GetAttribute("imageSource")
                };

                // String to int
                string value = i.GetAttribute("quantity");
                if (int.TryParse(value, out int quantity))
                    tempItem.Quantity = quantity;

                // String to double
                string itemPrice = i.GetAttribute("price");
                if (float.TryParse(itemPrice, out float price))
                    tempItem.Price = Math.Round(price, 2);

                // String to bool
                string isEdible = i.GetAttribute("isEdible");
                if (isEdible == "false")
                    tempItem.IsEdible = false;
                else
                    tempItem.IsEdible = true;


                string canEquip = i.GetAttribute("canEquip");
                if (canEquip == "false")
                    tempItem.CanEquip = false;
                else
                    tempItem.CanEquip = true;

                item.Add(tempItem);
            }

            return item;
        }

        public static List<Organism> ReadOrganism(string fileName)
        {
            List<Organism> organism = new List<Organism>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList organismList = root.SelectNodes("/Organisms/Organism");
            foreach (XmlElement o in organismList)
            {
                Organism tempOrganism = new Organism
                {
                    Name = o.GetAttribute("name"),
                    Description = o.GetAttribute("description"),
                    Type = o.GetAttribute("type"),
                    ImageSource = o.GetAttribute("imageSource"),
                };

                // String to bool
                string isAlive = o.GetAttribute("isAlive");
                if (isAlive == "false")
                    tempOrganism.IsAlive = false;
                else
                    tempOrganism.IsAlive = true;

                organism.Add(tempOrganism);
            }
            return organism;
        }

        public static List<Resource> ReadResource(string fileName)
        {
            List<Resource> resources = new List<Resource>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList resourceList = root.SelectNodes("/Resources/Resource");

            foreach (XmlElement r in resourceList)
            {
                Resource tempResource = new Resource
                {
                    Name = r.GetAttribute("name"),
                    Description = r.GetAttribute("description"),
                    ImageSource = r.GetAttribute("imageSource")
                };

                // String to int
                string amount = r.GetAttribute("resourceAmount");
                if (int.TryParse(amount, out int resourceAmount))
                    tempResource.ResourceAmount = resourceAmount;

                // String to bool
                string isEdible = r.GetAttribute("isEdible");
                if (isEdible == "false")
                    tempResource.IsEdible = false;
                else
                    tempResource.IsEdible = true;

                resources.Add(tempResource);
            }
            return resources;
        }

        public static List<Environment> ReadEnvironment(string fileName)
        {
            List<Environment> environments = new List<Environment>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList environmentList = root.SelectNodes("/Environments/Environment");
            foreach (XmlElement e in environmentList)
            {
                Environment tempEnvironment = new Environment
                {
                    Name = e.GetAttribute("name"),
                    Description = e.GetAttribute("description")
                };

                // String to int
                string temp = e.GetAttribute("idealTemp");
                if (int.TryParse(temp, out int idealTemp))
                    tempEnvironment.IdealTemp = idealTemp;

                string firstTemp = e.GetAttribute("initialTemp");
                if (int.TryParse(firstTemp, out int initialTemp))
                    tempEnvironment.InitialTemp = initialTemp;

                environments.Add(tempEnvironment);
            }
            return environments;
        }
    }
}
