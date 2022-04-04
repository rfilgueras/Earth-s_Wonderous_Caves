using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VirtualEcosystemTwo.Utility;

namespace VirtualEcosystemTwo
{
    public class Environment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitialTemp { get; set; }
        public int IdealTemp { get; set; }
        public bool IsIdealTemp { get; set; }

       // public static List<Environment> environments { get; set; } = new List<Environment>();

        Player player = new Player();
        public Environment()
        {

        }
        public Environment(string name, string description, int initialTemp, int idealTemp)
        {
            Name = name;
            Description = description;
            IdealTemp = idealTemp;
            InitialTemp = initialTemp;          

            string path = "../../Info/Environments.xml";
            ReadInfo.ReadEnvironment(path);
        }

        public string PrintEnvironmentInfo(string environmentName)
        {            
            string environmentInfo = $"\n {Name}\n\nIdeal Temp:{IdealTemp} F\n\n  >> {Description}";
            if (Name == environmentName)
            {
                Print(environmentInfo);
            }
            return environmentInfo;
        }

        public string TempStatusMssg(string environmentName)
        {
            string tempStatus = "";
            if (Name == environmentName && environmentName != null)
            {
               tempStatus =  CheckTempStatus();
            }
            return Print(tempStatus);
        }

        // returns a different string after all temp conditions are checked.
        public string CheckTempStatus()
        {
            string message;
            // 
            if (IsIdealTemp != true)
            {
                if (LowTempCheck(true))
                {
                    message = WarningTxt($"Brrr!\n {player.Name}, it's too cold for the organism that lives here. Quickly! adjust the temperature to save it before the timer runs out!");
                }
                else
                {
                    HighTempCheck(true);
                    message = WarningTxt($"Uggh It feels like my flashlight is melting!\n{player.Name}, it's too hot for the organism that lives here.  Quickly! adjust the temperature to save it before the timer runs out!");
                }               
            }
            else
            {              
                IdealTempCheck(true);
                message = $"Perfect weather we're having today {player.Name}!";
            }
            return message;
        }
        // Checks if random temp is less than ideal temp
        public bool LowTempCheck(bool tempIsLow)
        {
            if (InitialTemp < IdealTemp)
            {
                IsIdealTemp = false;
                tempIsLow = true;
            }
            return tempIsLow;
        }
        // Checks if random temp is greater than ideal temp
        public bool HighTempCheck(bool tempIsHigh)
        {
            if (InitialTemp > IdealTemp)
            {
                IsIdealTemp = false;
                tempIsHigh = true;
            }
            return tempIsHigh;
        }

        // Checks if random temp is equal to ideal temp
        public bool IdealTempCheck(bool perfectTemp)
        {
            if (InitialTemp == IdealTemp)
            {
                IsIdealTemp = true;
                perfectTemp = true;
            }
            return perfectTemp;
        }

        // Sets random temp between 20 and 144
        public int SetRandomTemp(string environmentName)
        {
            Random rad = new Random();
            
            if (environmentName == Name)
            {
                InitialTemp = rad.Next(20, 146); 
            }
            return InitialTemp;
        }

        // Increments initial temp by one
        public int RaiseTemp(int newTemp)
        {
            if (LowTempCheck(true))
            {
               newTemp = InitialTemp +1;
            }                         
            return newTemp;
        }

        // Decrements initial temp by one
        public int LowerTemp(int newTemp)
        {
            if (HighTempCheck(true))
            {
                newTemp = InitialTemp -1;
            }               
            return newTemp;
        }
    }
}
