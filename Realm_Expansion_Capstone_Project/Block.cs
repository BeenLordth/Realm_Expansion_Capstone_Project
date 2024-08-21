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

        public Block(String terrain, String owner, Boolean walkable)
        {
            Terrain = terrain;
            Owner = owner;
            isWalkable = walkable;
        }

        public String getTerrain()
        {
            return Terrain;
        }
    }
}
