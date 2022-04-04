using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VirtualEcosystemTwo.Utility;

namespace VirtualEcosystemTwo
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Use { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsEdible { get; set; }
        public bool CanEquip { get; set; }
        public bool CanBeCrafted { get; set; }
        public string ImageSource { get; set; }

        public Item()
        {

        }
        public Item(string name, string description, string use, int quantity, string imageSource, double price)
        {
            string path = "../../Info/Items.xml";
            ReadInfo.ReadItem(path);

            Name = name;
            Description = description;
            Use = use;
            Quantity = quantity;
            ImageSource = imageSource;
            Price = price;
        }

        Player player = new Player();
        public string PrintItemInfo(string name)
        {
            string info = $"\n (Available: {Quantity}X)\n {Name}\n >> Use: {Use}\n >>{Description}\n";
            if (Name == name)
            {
                Print(info);
            }
            return info;
        }

        // Subtracts amount needed to 
        public int GetItemAmount(string itemName, int amount)
        {
            if (itemName == Name)
            {
                Quantity -= amount;
            }
            return Quantity;
        }

        public string PrintRecipe(string itemName)
        {
            string recipe = $"\n{Name} - Requirements to Craft:\n >>{Description}";
            if (itemName == Name)
            {
                Print(recipe);
            }
            return recipe;
        }

        //public double SellItem(string itemName)
        //{
        //    switch (itemName)
        //    {
        //        case "Brick":
        //            player.Currency += Price;
        //            break;
        //        case "Plastic Bottle":
        //            player.Currency += Price;
        //            break;
        //        case "Ductape":
        //            player.Currency += Price;
        //            break;
        //        case "Rope":
        //            player.Currency += Price;
        //            break;
        //        case "Cloth":
        //            player.Currency += Price;
        //            break;
        //        case "Healing Potion":
        //            player.Currency += Price;
        //            break;
        //        case "Shelter":
        //            player.Currency += Price;
        //            break;
        //        case "Cooling Suit":
        //            player.Currency += Price;
        //            break;
        //        default:
        //            break;
        //    }
        //    return player.Currency;


        //}


    }
}
