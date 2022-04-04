using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static VirtualEcosystemTwo.Utility;

namespace VirtualEcosystemTwo
{
    public class Player
    {
        public string Name { get; set; } = "Jane Doe";
        //public double Currency { get; set; } = 25;
        public bool IsAlive { get; set; }
        public bool IsInInventory { get; set; }

        public static List<Resource> Resources { get; set; } = new List<Resource>();
        public static List<Item> Items { get; set; } = new List<Item>();
        public static List<Item> Inventory { get; set; } = new List<Item>();

        public Player()
        {

        }

        //// Allows players to craft items
        //public void CraftItem(string itemName)
        //{
        //    switch (itemName)
        //    {
        //        case "Brick":
        //            // Requirements 3 limestone and 1 cool water 
        //            CraftBrick();
        //            Items[0].Quantity ++;
        //            break;
        //        case "Rope":
        //            // Requires 5 wild grass and 2 thyme
        //            CraftRope();
        //            Items[4].Quantity++;
        //            break;
        //        case "Cloth":
        //            // Requires 4 wildgrass and 1 basalt
        //            CraftCloth();
        //            Items[1].Quantity++;
        //            break;
        //        case "Shelter":
        //            // Requires 10 limestone and 5 crystal
        //            CraftShelter();
        //            Items[6].Quantity++;
        //            break;
        //        case "CoolingSuit":
        //            // Requires 5 wildgrass and 5 cool water 
        //            CraftCoolingSuit();
        //            Items[7].Quantity++;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public bool CheckInventory()
        //{
        //    return true;
        //}

        public bool CheckPlayerName (bool isEntered)
        {
            if (Name != null)
            {
                return isEntered;
            }
            else
            return false;
        }

        public string WelcomePlayerMssg (string greeting)
        {
            string welcomeMssg = "";
            if (CheckPlayerName(true))
            {
                welcomeMssg = $"Hello {Name}! Press Start when you are ready to start exploring! ";
                return Print(welcomeMssg);
            }
            else
                return WarningTxt("Please Enter a name.");
        }

        public bool CheckBrickIngredients(bool canCraft)
        {
            string path = "../../Info/Resources.xml";
            Resources = ReadInfo.ReadResource(path);
            if (Resources[6].Quantity >= 3 && Resources[11].Quantity >= 1)
            {
                Resources[6].Quantity -= 3;
                Resources[11].Quantity -= 1;
                canCraft = true;
            }
            
            return canCraft;
        }

        public bool CheckRopeIngredients(bool canCraft)
        {
            string path = "../../Info/Resources.xml";
            Resources = ReadInfo.ReadResource(path);
            if (Resources[8].Quantity >= 4 && Resources[11].Quantity >= 1)
            {
                Resources[8].Quantity -= 4;
                Resources[11].Quantity--;
                Items[4].CanBeCrafted = true;
            }

            return canCraft;
        }

        public bool CheckClothIngredients(bool canCraft)
        {
            string path = "../../Info/Resources.xml";
            Resources = ReadInfo.ReadResource(path);
            if (Resources[8].Quantity >= 3 && Resources[11].Quantity >= 3)
            {
                Resources[8].Quantity -= 3;
                Resources[11].Quantity-= 3;
                Items[4].CanBeCrafted = true;
            }

            return canCraft;
        }

        public bool CheckShelterIngredients(bool canCraft)
        {
            string path = "../../Info/Resources.xml";
            Resources = ReadInfo.ReadResource(path);
            if (Resources[5].Quantity >= 10 && Resources[0].Quantity >= 5)
            {
                Resources[5].Quantity -= 10;
                Resources[0].Quantity -= 5;
                Items[6].CanBeCrafted = true;
            }

            return canCraft;
        }

        public bool CheckCoolingSuitIngredients(bool canCraft)
        {
            string path = "../../Info/Resources.xml";
            Resources = ReadInfo.ReadResource(path);

            // Requires 5 wildgrass and 5 cool water 
            if (Resources[8].Quantity >= 5 && Resources[9].Quantity >= 5)
            {
                Resources[8].Quantity -= 5;
                Resources[9].Quantity -= 5;
                Items[7].CanBeCrafted = true;
            }

            return canCraft;
        }
        public int CraftBrick()
        {
            string path = "../../Info/Items.xml";
            Items = ReadInfo.ReadItem(path);
            Inventory.Add(Items[0]);
            Items[0].Quantity++;
            return Items[0].Quantity;
        }

        public int CraftRope()
        {
            Inventory.Add(Items[1]);
            Items[1].Quantity++;
            return Items[1].Quantity;
        }

        public int CraftCloth()
        {
            // Requires 4 wildgrass and 1 basalt           
            Inventory.Add(Items[4]);
            Items[4].Quantity++;
            return Items[4].Quantity;
        }       

        public int CraftShelter()
        {           
            Inventory.Add(Items[6]);
            Items[6].Quantity++;
            return Items[6].Quantity;
        }

        public int CraftCoolingSuit()
        {                    
            Inventory.Add(Items[7]);
            Items[7].Quantity++;
            return Items[7].Quantity;
        }
    }
}
