using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represent a block within a game board
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Identifies the X coordinate of the block (horizontal)
        /// </summary>
        private int XCoordinate;

        /// <summary>
        /// Identifies the Y coordinate of the block (vertical)
        /// </summary>
        private int YCoordinate;

        /// <summary>
        /// Identifies the type of terrain contained within the block 
        /// </summary>
        private String Terrain;

        /// <summary>
        /// Identifies the owner of the block 
        /// </summary>
        private String Owner;

        /// <summary>
        /// Determines if this block can be used by the player or not. 
        /// </summary>
        private Boolean isWalkable;

        /// <summary>
        /// 
        /// </summary>
        private int Index;

        private Boolean isHabitated = false;


        /// <summary>
        /// Class constructor  
        /// </summary>
        /// <param name="terrain">declares the type of terrain</param>
        /// <param name="owner">declares the owner</param>
        /// <param name="walkable">declare if the block can be walked in</param>
        public Block(String terrain, String owner, Boolean walkable)
        {
            Terrain = terrain;
            Owner = owner;
            isWalkable = walkable;
        }

        public Boolean getHabitated()
        {
            return isHabitated;
        }

        public void setHabitated(Boolean hab)
        {
            isHabitated = hab;
        }

        /// <summary>
        /// getter for the XCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the block</returns>
        public int getXCoordinate()
        {
            return XCoordinate;
        }

        /// <summary>
        /// setter for the XCoordinate variable 
        /// </summary>
        /// <param name="newXCoord">the new coordinates of the block</param>
        public void setXCoordinate(int newXCoord)
        {
            XCoordinate = newXCoord;
        }

        /// <summary>
        /// getter for the YCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the block</returns>
        public int getYCoordinate()
        {
            return YCoordinate;
        }

        /// <summary>
        /// setter for the YCoordinate variable 
        /// </summary>
        /// <param name="newYCoord">new coordinates of the block</param>
        public void setYCoordinate(int newYCoord)
        {
            YCoordinate = newYCoord;
        }

        /// <summary>
        /// getter for the Terrain variable 
        /// </summary>
        /// <returns>the terrain type</returns>
        public String getTerrain()
        {
            return Terrain;
        }

        public void setTerrain(String terrain)
        {
            Terrain = terrain;
        }

        /// <summary>
        /// getter for the Owner variable 
        /// </summary>
        /// <returns>the owner of the block</returns>
        public String getOwner()
        {
            return Owner;
        }

        /// <summary>
        /// the setter for the Owner variable 
        /// </summary>
        /// <param name="newOwner">the name of the new owner</param>
        public void setOwner(String newOwner)
        {
            Owner = newOwner; 
        }

        /// <summary>
        /// getter for the isWalkable variable 
        /// </summary>
        /// <returns>true if isWalkable, false if not</returns>
        public Boolean getIsWalkable()
        {
            return isWalkable;
        }

        public int getIndex()
        {
            return Index;
        }

        public void setIndex(int index)
        {
            Index = index;
        }

        public static Block findBlock(int x, int y, Block[] blocks)
        {
            Block block = null;
            foreach (Block b in blocks)
            {
                if (b.getXCoordinate() == x && b.getYCoordinate() == y)
                {
                    block = b;
                    break;
                }
            }
            return block;
        }

        public static int updateXCoordSetUp(int x)
        {
            if (x < 29) { x++; }
            else { x = 0; }
            return x;
        }

        public static int updateYcoordSetUp(int x, int y)
        {
            if (x == 0) { y++; }
            return y;
        }

        public static void updateBlockAppearance(Block block, String owner, String blockType, Button[] Buttons, Block[] Blocks, Enemy[] Enemies, Player player)
        {
            Color color = Colors.White;
            Enemy blockOwner = Enemy.getEnemyByName(owner, Enemies);

            if (blockOwner != null)
            {
                color = blockOwner.getColor();
            }
            if (owner == player.getName())
            {
                color = Colors.Blue;
            }

            for (int i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i].getXCoordinate() == block.getXCoordinate() && Blocks[i].getYCoordinate() == block.getYCoordinate())
                {
                    Blocks[i].setOwner(owner);
                    Button button = Buttons[i];

                    Image terrainImg = new Image();
                    if (blockType == "Grassland")
                    {
                        Blocks[i].setHabitated(false);
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/grassland.jpg", UriKind.Relative));
                    }
                    else if (blockType == "Mountain")
                    {
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/mountain.jpg", UriKind.Relative));
                    }
                    else if (blockType == "Water")
                    {
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/water.jpg", UriKind.Relative));
                    }
                    else if (blockType == "City")
                    {
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
                    }
                    else if (blockType == "WatchTower")
                    {
                        Blocks[i].setHabitated(true);
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/WatchTower.jpg", UriKind.Relative));
                    }
                    else if (blockType == "Unit_Villager")
                    {
                        Blocks[i].setHabitated(true);
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/Unit_Villager.jpg", UriKind.Relative));
                    }
                    else if (blockType == "UnitBase")
                    {
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/unitbase.jpg", UriKind.Relative));
                    }
                    else if (blockType == "Attack_Symbol")
                    {
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/Attack_Symbol.jpg", UriKind.Relative));
                    }

                    if (owner != "NA")
                    {

                        terrainImg.OpacityMask = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"pack://application:,,,/Assets/Images/{blockType.ToLower()}.jpg", UriKind.RelativeOrAbsolute)),
                            Opacity = 0.5
                        };

                    


                        terrainImg.Effect = new System.Windows.Media.Effects.DropShadowEffect
                        {
                            Color = color,
                            Opacity = 100,
                            ShadowDepth = 0,
                            BlurRadius = 0
                        };
                    }

                    button.Content = terrainImg;
                }
            }
        }

        public static void giveBeginnerLand(Button[] Buttons, Block[] Blocks, Enemy[] Enemies, List<City> OccupiedCities, Player player)
        {
            foreach (City city in OccupiedCities)
            {
                int cityX = city.getXCoordinate();
                int cityY = city.getYCoordinate();
                String owner = city.getOwner();

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0)
                        {
                            continue;
                        }

                        Block block = Block.findBlock(cityX + x, cityY + y, Blocks);
                        block.setOwner(owner);
                        Block.updateBlockAppearance(block, owner, "Grassland", Buttons, Blocks, Enemies, player);
                    }
                }
            }
        }

        public static void createBase(String owner, Color color, Button[] Buttons, Block[] Blocks, List<City> nonOccupiedCities, List<City> OccupiedCities)
        {
            Random random = new Random();
            int randomNumber = random.Next(nonOccupiedCities.Count);
            City selectedCity = nonOccupiedCities[randomNumber];
            nonOccupiedCities.RemoveAt(randomNumber);

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
    }
}
