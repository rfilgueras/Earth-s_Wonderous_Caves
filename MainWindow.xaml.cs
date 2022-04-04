/*
 * 
 * 
 * Earth's Wonderous Cave (Virtual EcoSystem Two)
 *  A WPF game where the player is able to control the environment in which they must help maintain the symbiotic relationship of a bee and a flower for each respective environment that they occupy. If the temperature of the current environment isn't equal to the ideal temperature, the player must quickly adjust it before the organism dies. If the player fails to adjust the temperature fast enough, both the organism and the plant's symbiotic relationship will be destroyed since one cannot exist without the other. The player will then be kickedout of that environment and be brought to the map to choose another one. They can no longer visit that environment if the symbiotic relationship fails. 
 * 
 * Rhona Filgueras
 * May 10 2021
 * 
 * Professor Janell Baxter helped me get the project started and helped me debug errors found during the project's development.
 * Austin Derrickson helped make collecting individual resources possible by turning it into a button instead of an image triggered by a button.
 * Owen Duffy helped debug some errors found during the project's development (the images weren't referenced right so nothing was showin on the xaml preview)
 * Professor Marc Temkin told me about the Queue and Dequeue in Game Engine Scripting class and I applied the same logic for this project
 * 
 * Code for Counter/ Displatch timer based on the class demo code on canvas
 * https://canvas.colum.edu/courses/21264/pages/demo-wpf-timer?module_item_id=1178223
 * DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
 * 
 * Tutorial Page will be based on Class Demo WPF One button to Rule Them All
 * https://canvas.colum.edu/courses/21264/pages/demo-wpf-overview-and-one-button-to-rule-them-all?module_item_id=1178123
 * 
 * Setting forground color of textblock in code behind from stack overflow
 * https://stackoverflow.com/questions/12727491/programmatically-set-textblock-foreground-color
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VirtualEcosystemTwo.Pages;

namespace VirtualEcosystemTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Player player = new Player();
        public static Item currentItem = new Item();
        public static Environment currentEnvironment = new Environment();
        public static Organism currentOrganism = new Organism();
        public static Resource currentResource = new Resource();
        public static Event currentEvent = new Event();
        public static Game game = new Game();
        public static Utility utils = new Utility();

        // Read externally from XML file.
        public static List<Organism> organisms = new List<Organism>();
        public static List<Item> items = new List<Item>();
        public static List<Resource> resources = new List<Resource>();
        public static List<Environment> environments = new List<Environment>();
        public MainWindow()
        {
            InitializeComponent();
            Title = "Earth's Wondrous Caves";
            NavigationFrame.Navigate(new GameStartPage());
            Set();           
        }

        public void Set()
        {
            string environmentPath = "../../Info/Environments.xml";
            environments = ReadInfo.ReadEnvironment(environmentPath);

            string resourcesPath = "../../Info/Resources.xml";
            resources = ReadInfo.ReadResource(resourcesPath);

            string organismPath = "../../Info/Organisms.xml";
            organisms = ReadInfo.ReadOrganism(organismPath);

            string itemPath = "../../Info/Items.xml";
            items = ReadInfo.ReadItem(itemPath);
        }
    }
}
