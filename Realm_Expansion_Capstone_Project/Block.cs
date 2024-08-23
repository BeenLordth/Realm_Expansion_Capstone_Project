using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
