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
        /// Identifies the index of the block in the list created when map is being created
        /// </summary>
        private int Index;

        /// <summary>
        /// Identifies if the block can be used by villagers or watchtowers. 
        /// </summary>
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

        /// <summary>
        /// returns the current habitable status of the block
        /// </summary>
        /// <returns>isHabitated</returns>
        public Boolean getHabitated()
        {
            return isHabitated;
        }

        /// <summary>
        /// changes the habitable status of the block 
        /// </summary>
        /// <param name="hab">the new habitable status</param>
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

        /// <summary>
        /// returns the index of the block within the Block list
        /// </summary>
        /// <returns>Index</returns>
        public int getIndex()
        {
            return Index;
        }

        /// <summary>
        /// declares the index of the block within the Block list
        /// </summary>
        /// <param name="index">declared index</param>
        public void setIndex(int index)
        {
            Index = index;
        }

        /// <summary>
        /// finds and returns a block found within a list based on given coordinates
        /// </summary>
        /// <param name="x">x coordinate of desired block</param>
        /// <param name="y">y coordinate of desired block</param>
        /// <param name="blocks">list to search block in</param>
        /// <returns>the desired block, if found</returns>
        public static Block findBlock(int x, int y, Block[] blocks)
        {
            // returns a null block if block is not found
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

        /// <summary>
        /// determine what x coordinate to give to a block so that it can be used to determine available rows
        /// </summary>
        /// <param name="x">old x coordinate used to determine new x coordinate</param>
        /// <returns>new x coordinate</returns>
        public static int updateXCoordSetUp(int x)
        {
            if (x < 29) { x++; }
            else { x = 0; }
            return x;
        }

        /// <summary>
        /// determintes what y coordiante to give to a block so that it can be used to determine available columns
        /// </summary>
        /// <param name="x">x coordinate of old y coordinate used to determine new y coordinate</param>
        /// <param name="y">old y coordinate</param>
        /// <returns>new y coordinate</returns>
        public static int updateYcoordSetUp(int x, int y)
        {
            if (x == 0) { y++; }
            return y;
        }

        /// <summary>
        /// update the apparance of a block and updates the arrays to reflect the visual changes
        /// </summary>
        /// <param name="block">the block that will be changed</param>
        /// <param name="owner">the name of the realm who owns the block</param>
        /// <param name="blockType">the type of terrain in this block</param>
        /// <param name="Buttons">array of buttons to update apperance</param>
        /// <param name="Blocks">array of blocks to update block based on its physical appearance</param>
        /// <param name="Enemies">array of enemies to get color of enemy if needed</param>
        /// <param name="player">player to verify if block belongs to player based on the name</param>
        public static void updateBlockAppearance(Block block, String owner, String blockType, Button[] Buttons, Block[] Blocks, Enemy[] Enemies, Player player)
        {
            Color color = Colors.White;
            Enemy blockOwner = Enemy.getEnemyByName(owner, Enemies);

            //determine the color to overlay in the block
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
                //find the block within the block list
                if (Blocks[i].getXCoordinate() == block.getXCoordinate() && Blocks[i].getYCoordinate() == block.getYCoordinate())
                {
                    Blocks[i].setOwner(owner);
                    Button button = Buttons[i];

                    // determine which image the button will be updated with
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
                        Blocks[i].setHabitated(true); //change its habitated status to true since a unit is placed here
                        terrainImg.Source = new BitmapImage(new Uri("Assets/Images/WatchTower.jpg", UriKind.Relative));
                    }
                    else if (blockType == "Unit_Villager")
                    {
                        Blocks[i].setHabitated(true); //change its habitated status to true since a unit is placed here
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

                    // give the button a color overlay representing the owner, but only if the block actually has an owner
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

                    //apply all the changes to the button now that all has been determined
                    button.Content = terrainImg;
                }
            }
        }

        /// <summary>
        /// give each realm some land that surrounds their initial city
        /// </summary>
        /// <param name="Buttons"> array of buttons where land will be found</param>
        /// <param name="Blocks">array of blocks where land will be found</param>
        /// <param name="Enemies">array of enemies to pass to the updateBlockAppearance method</param>
        /// <param name="OccupiedCities"> list of cities to loop through and find all realms that need to be given land</param>
        /// <param name="player">player instance to pass to the updateBlockAppearance method</param>
        public static void giveBeginnerLand(Button[] Buttons, Block[] Blocks, Enemy[] Enemies, List<City> OccupiedCities, Player player)
        {
            foreach (City city in OccupiedCities)
            {
                int cityX = city.getXCoordinate();
                int cityY = city.getYCoordinate();
                String owner = city.getOwner();

                // nested loop to get all surrounding blocks of the city
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        // skip the city block itself
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

        /// <summary>
        /// create the base for each realm so that they have a place to start out in. 
        /// </summary>
        /// <param name="owner">name of the owner who will get the city</param>
        /// <param name="color">color of the owner so that button is updated with the proper color overlay</param>
        /// <param name="Buttons">array of buttons to update the city being taken</param>
        /// <param name="Blocks">array of blocks to update the city being taken</param>
        /// <param name="nonOccupiedCities">list of non occupied cities that the realm can choose from to take</param>
        /// <param name="OccupiedCities">list of occupied cities that the the taken city will be added to once a realm chooses it</param>
        public static void createBase(String owner, Color color, Button[] Buttons, Block[] Blocks, List<City> nonOccupiedCities, List<City> OccupiedCities)
        {
            Random random = new Random();
            int randomNumber = random.Next(nonOccupiedCities.Count); //pick random city from the non occupied cities 
            City selectedCity = nonOccupiedCities[randomNumber];
            nonOccupiedCities.RemoveAt(randomNumber); // remove picked city from list so that it can't be picked by another realm 

            City city = new City(selectedCity.getXCoordinate(), selectedCity.getYCoordinate(), owner);
            OccupiedCities.Add(city); 

            // update appearance of the city to represent the new owner
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

            // update the block and button lists with the new changes 
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
