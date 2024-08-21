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
using System.Windows.Shapes;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Block[] Blocks = new Block[900];
        

        public Game()
        {
            InitializeComponent();
            SetUpGameBoard();
        }

        private void SetUpGameBoard()
        {
            String Terrain =
            "WWWWWWGGGGGGGGGGGGGGGGGGGGGGGG" + // Larger water body in the top left
            "WWWWWWGGGGGGGGGGGGGGGGGGGGGGGG" + // Continue the water body down
            "WWWWWWGGGGGGGGGGGGGGGGGGGGGGGG" + // Continue the water body down
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGMMMMGGGGGGGGGGGGGGGGGGGGGG" + // Small mountain range starts
            "GGGGMMMMGGGGGGGGGGGGGGGGGGGGGG" + // Continue the small mountain range
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGMMMMMMMMGGGGGGGGGG" + // Larger mountain range in the south
            "GGGGGGGGGGGGMMMMMMMMGGGGGGGGGG" + // Continue the larger mountain range
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "MMMMGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Another small mountain
            "MMMMGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Continue the small mountain
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Grassland area continues
            "WWWWGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Another larger water body
            "WWWWGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Continue the larger water body
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG";  // Grassland area continues

            Char[] TerrainCharArray = Terrain.ToCharArray();

            for (int i = 0; i < Blocks.Length; i++)
            {
                if (TerrainCharArray[i] == 'M')
                {
                    Block block = new Block("Mountain", "NA", false);
                    Blocks[i] = block;
                    Button button = new Button();
                    button.Width = 30;
                    button.Height = 30;
                    Image terrainImg = new Image();
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/mountain.jpg", UriKind.Relative));
                    button.Content = terrainImg;
                    G_game_board_stack_panel.Children.Add(button);

                } else if (TerrainCharArray[i] == 'G')
                {
                    Block block = new Block("Grassland", "NA", true);
                    Blocks[i] = block;
                    Button button = new Button();
                    button.Width = 30;
                    button.Height = 30;
                    Image terrainImg = new Image();
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/grassland.jpg", UriKind.Relative));
                    button.Content = terrainImg;
                    G_game_board_stack_panel.Children.Add(button);

                } else if (TerrainCharArray[i] == 'W')
                {
                    Block block = new Block("Water", "NA", false);
                    Blocks[i] = block;
                    Button button = new Button();
                    button.Width = 30;
                    button.Height = 30;
                    Image terrainImg = new Image();
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/water.jpg", UriKind.Relative));
                    button.Content = terrainImg;
                    G_game_board_stack_panel.Children.Add(button);

                } else
                {
                    Block block = new Block("Cities", "NA", false);
                    Blocks[i] = block;
                    Button button = new Button();
                    button.Width = 30;
                    button.Height = 30;
                    Image terrainImg = new Image();
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
                    button.Content = terrainImg;
                    G_game_board_stack_panel.Children.Add(button);
                }  
                
            }
        }
    }
}
