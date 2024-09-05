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
        private Button[] Buttons = new Button[900];
        private Block[] Blocks = new Block[900];
        private List<Block> BlockCities = new List<Block>();
        private List<City> OccupiedCities = new List<City>();
        private String PlayerName;  
        private Boolean isHard;

        public Game(String name, int enemyCt, string difficulty)
        {
            InitializeComponent();
            SetUpGameBoard();
            createBase(name, Colors.Blue);
            createEnemies(enemyCt);
            PlayerName = name;
            if(difficulty == "Easy") { isHard = false; }
            else { isHard = true; }
            giveBeginnerLand();
        }

        private void giveBeginnerLand()
        {
            foreach (City city in OccupiedCities)
            {
                int cityX = city.getXCoordinate();
                int cityY = city.getYCoordinate();

                for(int x = -1; x <= 1; x++)
                {
                    for(int y = -1; y <= 1; y++)
                    {
                        if (x != 0 && y != 0)
                        {
                            Block block = findBlock(cityX + x, cityY + y);

                            for(int i = 0; i < Blocks.Length; i++)
                            {
                                if (Blocks[i].getXCoordinate() == block.getXCoordinate() && Blocks[i].getYCoordinate() == block.getYCoordinate())
                                {
                                    Blocks[i].setOwner(city.getOwner());
                                }
                            }
                        }
                    }
                }
            }
        }

        private Block findBlock(int x, int y)
        {
            Block block = null;
            foreach(Block b in Blocks)
            {
                if (b.getXCoordinate() == x && b.getYCoordinate() == y)
                {
                    block = b;
                    break;
                }
            }
            return block;
        }

        private void SetUpGameBoard()
        {
            String Terrain =
            "WWWWWWWWWWWWGGGGGGGGGGGGGGGGGG" + // Row 1
            "WWWWWWWWWWGGGGGGGGGGGGCGGGGGGG" + // Row 2
            "WWWWWWWWGGGGGGGGGGGGGGGGGGMMMM" + // Row 3
            "WWWWWWWGGGGGGGGGGGGGGGGGMMMMMM" + // Row 4
            "WWWWWWWGGGGGGGGGGGGGGGGMMMMMMM" + // Row 5
            "WWWWGGGGGGGGGGGGGGGGGGMMMMMMMM" + // Row 6
            "WWWWGGGGGGGGGGGGGGGGGGGMMMMMMM" + // Row 7
            "WWGGGGGGGGGGGGGGGGGGGGMMMMMMMM" + // Row 8
            "GGGCGGGGGGGGGGGCGGMMMMMMMMMMMM" + // Row 9
            "MMGGGGGGGGGGGGGGGMMMMMMMMMMMMM" + // Row 10
            "MMMMGMMGGGGGGGGGGGMMMMMMMMMMMM" + // Row 11
            "MMMMMMMMMGGGGGGGGGGGGMMMGGGGMM" + // Row 12
            "MMMMMMMMMGGGGGGGGGGGMMMMGGGGGM" + // Row 13
            "MMGGGGGGGGGGGGGGGGGGMMMGGCGGGG" + // Row 14
            "GGGGGGGGGGGGCGGGGGGGMMGGGGGGGG" + // Row 15
            "GGGGGGGGGGGGGGGGGGGGMMGGGGGGGG" + // Row 16
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Row 17
            "GGGGGGGGGGGGWWGGGGGGGGGGGGGGGG" + // Row 18
            "GGGGGGGGGGGGWWWGGGCGGGGGGGGGGG" + // Row 19
            "GGGGGGGGGGGWWWWGGGGGGGGGGGGGGG" + // Row 20
            "GGGGGGGGGGWWWWGGGGGGGGGGGGGGGG" + // Row 21
            "GGGGGGGGGWWWWGGGGGGGGGGGGGGCGG" + // Row 22
            "GGGGCGGGGWWWWGGGGGGGGGGGGGGGGG" + // Row 23
            "GGGGGGGGGWWWWGGGGGGGGGGGGGGGGG" + // Row 24
            "GGGGGGGGGGWWWGGGGGGGGWWWGGGGGG" + // Row 25
            "GGGGGGGGGGGWWWGGGGGGWWWWWGGGGG" + // Row 26
            "GGGGGGGGGGGWWWGGGGGGGWWWWGGGGG" + // Row 27
            "GGGGGGGGGGGWWWWGGGGGGGGGGGGGGG" + // Row 28
            "GGGGGCGGGGGGWWWGGGGGGCGGGGGGGG" + // Row 29
            "GGGGGGGGGGGGWWWWGGGGGGGGGGGGGG";  // Row 30

            Char[] TerrainCharArray = Terrain.ToCharArray();
            int xcoord = -1;
            int ycoord = -1;

            for (int i = 0; i < Blocks.Length; i++)
            {
                Button button = new Button();
                button.Width = 30;
                button.Height = 30;
                button.BorderThickness = new Thickness(0);
                Image terrainImg = new Image();
                Block block;

                if (TerrainCharArray[i] == 'M')
                {
                    block = new Block("Mountain", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/mountain.jpg", UriKind.Relative));
                } 
                else if (TerrainCharArray[i] == 'G')
                {
                    block = new Block("Grassland", "NA", true);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/grassland.jpg", UriKind.Relative));

                } 
                else if (TerrainCharArray[i] == 'W')
                {
                    block = new Block("Water", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/water.jpg", UriKind.Relative));

                } 
                else
                {
                    block = new Block("City", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
                }

                xcoord = updateXCoordSetUp(xcoord, ycoord);
                ycoord = updateYcoordSetUp(xcoord, ycoord);
                block.setXCoordinate(xcoord);
                block.setYCoordinate(ycoord);
                Blocks[i] = block;

                if(block.getTerrain() == "City")
                {
                    BlockCities.Add(block);
                }

                button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString(); // test
                button.Content = terrainImg;
                button.Tag = block;
                button.Click += BlockClick;
                Buttons[i] = button;
                G_game_board_stack_panel.Children.Add(button);
            }
        }

        public void createEnemies(int enemyCt)
        {
            List<Color> enemyColors = new List<Color> { Colors.Red, Colors.Orange, Colors.Purple };
            List<String> Names = new List<String> { "Reach", "Dorne", "Crownlands", "Stormlands", "Ironlands", "Vale", "Riverlands", "Dothrak", "YiTi", "Nhai" };

            Random randomName = new Random();
            Random randomColor = new Random();

            for (int i = 0; i < enemyCt; i++)
            {
                int selectedNameIndex = randomName.Next(Names.Count);
                int selectedColorIndex = randomColor.Next(enemyColors.Count);
                String name = Names[selectedNameIndex];
                Names.Remove(name);
                Color color = enemyColors[selectedColorIndex];
                enemyColors.Remove(color);
                createBase(name, color);
            }
        }

        private int updateXCoordSetUp(int x, int y)
        {
            if(x < 29) { x++; } 
            else { x = 0; }
            return x;
        }

        private int updateYcoordSetUp(int x , int y)
        {
            if (x == 0) { y++; }
            return y;
        }

        private void createBase(String owner, Color color)
        {
            Random random = new Random();
            int randomNumber = random.Next(BlockCities.Count);
            Block selectedCity = BlockCities[randomNumber];
            BlockCities.RemoveAt(randomNumber);

            City city = new City(selectedCity.getXCoordinate(), selectedCity.getYCoordinate(), owner);
            OccupiedCities.Add(city);

            // change image
            Image terrainImg = new Image();
            terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
            terrainImg.OpacityMask = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/city.jpg", UriKind.RelativeOrAbsolute)),
                Opacity = 0.5
            };
            terrainImg.Effect = new System.Windows.Media.Effects.DropShadowEffect
            {
                Color = color,
                Opacity = 100,
                ShadowDepth = 0,
                BlurRadius = 0
            };

            // change the owner on text display and the game board
            for (int i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i].getXCoordinate() == city.getXCoordinate() && Blocks[i].getYCoordinate() == city.getYCoordinate())
                {
                    Blocks[i].setOwner(owner);
                    Buttons[i].Content = terrainImg;
                }
            }
        }

        private void BlockClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if(clickedButton != null)
            {
                Block clickedBlock = clickedButton.Tag as Block;
                if(clickedButton != null)
                {
                    G_coordinate_display_label.Content = $"{clickedBlock.getXCoordinate()}, {clickedBlock.getYCoordinate()}";
                    G_owner_display_label.Content = $"{clickedBlock.getOwner()}\n";
                    G_walkable_display_label.Content = $"{clickedBlock.getIsWalkable()}";
                    G_terrain_display_label.Content = $"{clickedBlock.getTerrain()}\n";
                }
            }
        }

        private int calculateGoldIncome()
        {
            int gold = 0;
            foreach(Block block in Blocks)
            {
                if (block.getOwner() == PlayerName)
                {
                    gold =+ 100;
                }
            }
            return gold;
        }

        private void G_end_turn_button_Click(object sender, RoutedEventArgs e)
        {
            // update turn number
            string turnLabelText = G_turn_number_label.Content.ToString();
            int turnNumber = int.Parse(turnLabelText) + 1;
            G_turn_number_label.Content = turnNumber.ToString();

            //update gold amount 
            string goldLabelText = G_gold_number_label.Content.ToString();
            int newGold = int.Parse(goldLabelText) + calculateGoldIncome();
            G_gold_number_label.Content = newGold.ToString();
        }

        private void G_attack_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G_move_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G_buy_watchtower_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G_buy_villager_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G_quit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void G_save_button_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
