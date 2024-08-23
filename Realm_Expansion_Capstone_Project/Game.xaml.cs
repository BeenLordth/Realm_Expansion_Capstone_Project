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
            "GGGGGCGGGGGGWWWGGGGGGGGGGGGGGG" + // Row 29
            "GGGGGGGGGGGGWWWWGGGGGCGGGGGGGG";  // Row 30

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

                if (TerrainCharArray[i] == 'M')
                {
                    Block block = new Block("Mountain", "NA", false);
                    xcoord = updateXCoordSetUp(xcoord, ycoord);
                    ycoord = updateYcoordSetUp(xcoord, ycoord);
                    block.setXCoordinate(xcoord);
                    block.setYCoordinate(ycoord);
                    Blocks[i] = block;
                    button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString(); // test
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/mountain.jpg", UriKind.Relative));
                } else if (TerrainCharArray[i] == 'G')
                {
                    Block block = new Block("Grassland", "NA", true);
                    xcoord = updateXCoordSetUp(xcoord, ycoord);
                    ycoord = updateYcoordSetUp(xcoord, ycoord);
                    block.setXCoordinate(xcoord);
                    block.setYCoordinate(ycoord);
                    Blocks[i] = block;
                    button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString(); // test
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/grassland.jpg", UriKind.Relative));

                } else if (TerrainCharArray[i] == 'W')
                {
                    Block block = new Block("Water", "NA", false);
                    xcoord = updateXCoordSetUp(xcoord, ycoord);
                    ycoord = updateYcoordSetUp(xcoord, ycoord);
                    block.setXCoordinate(xcoord);
                    block.setYCoordinate(ycoord);
                    Blocks[i] = block;
                    button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString(); // test
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/water.jpg", UriKind.Relative));

                } else
                {
                    Block block = new Block("City", "NA", false);
                    xcoord = updateXCoordSetUp(xcoord, ycoord);
                    ycoord = updateYcoordSetUp(xcoord, ycoord);
                    block.setXCoordinate(xcoord);
                    block.setYCoordinate(ycoord);
                    Blocks[i] = block;
                    button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString(); // test
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
                }   

                button.Content = terrainImg;
                button.Click += testClick;
                G_game_board_stack_panel.Children.Add(button);
            }
        }

        private int updateXCoordSetUp(int x, int y)
        {
            if(x < 29)
            {
                x++;
            } else
            {
                x = 0;
            }
            return x;
        }

        private int updateYcoordSetUp(int x , int y)
        {
            if (x == 0)
            {
                y++;
            }
            return y;
        }

        private void testClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            MessageBox.Show($"{clickedButton.Name} was clicked");
        }
    }
}
