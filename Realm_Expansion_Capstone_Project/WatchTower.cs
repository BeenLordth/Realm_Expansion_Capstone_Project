using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a watch tower found within a game board
    /// </summary>
    public class WatchTower
    {
        /// <summary>
        /// Identifies the current level of the watch tower 
        /// </summary>
        private int Level = 1;

        /// <summary>
        /// identifies the X coordinate of the watch tower (Horizontal)
        /// </summary>
        private int XCoordinate;

        /// <summary>
        /// identifies the Y coordinate of the watch tower (Vertical)
        /// </summary>
        private int YCoordinate;

        /// <summary>
        /// Identifies the owner of the watch tower 
        /// </summary>
        private String Owner;

        /// <summary>
        /// Determintes the current health of the watch tower 
        /// </summary>
        private int Health = 550;

        /// <summary>
        /// Determinte the current attack range of the watch tower
        /// </summary>
        private int AttackRange = 3;

        /// <summary>
        /// Determinte the current attack damage of the watch tower
        /// </summary>
        private int AttackDamage = 200;

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="XCoor">Determine where along the X axis of the board the watch tower will be placed</param>
        /// <param name="YCoor">Determine where along the Y axis of the board the watch tower will be placed</param>
        /// <param name="owner">Determine the owner of the watch tower</param>
        public WatchTower(int XCoor, int YCoor, String owner)
        {
            XCoordinate = XCoor;
            YCoordinate = YCoor;
            Owner = owner;
        }
    }
}
