using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a Villager unit and their stats
    /// </summary>
    public class Villager
    {
        /// <summary>
        /// Identify the current X coordinate of the villager unit (horizontal)
        /// </summary>
        protected int XCoordinate;

        /// <summary>
        /// Identify the current Y coordinate of the villager unit (vertical)
        /// </summary>
        protected int YCoordinate;

        /// <summary>
        /// Identifies the owener of the villager unit 
        /// </summary>
        protected String Owner;

        /// <summary>
        /// Determinte the current health / the amount of villagers alive in the unit 
        /// </summary>
        protected int Health = 500;

        /// <summary>
        /// Determinte the attack range of the villagers
        /// </summary>
        protected int AttackRange = 1;

        /// <summary>
        /// Determinte the current attack damage of the villagers
        /// </summary>
        protected int AttackDamage = 250;

        /// <summary>
        /// determinte the current amount of blocks that the villagers can travel in 1 turn
        /// </summary>
        protected int TravelRange = 2;

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="XCoor">Determine where along the X axis of the board the unit will be placed</param>
        /// <param name="YCoor">Determine where along the Y axis of the board the unit will be placed</param>
        /// <param name="owner">Determine the owner of the villager unit</param>
        public Villager(int XCoor, int YCoor, String owner)
        {
            XCoordinate = XCoor;
            YCoordinate = YCoor;
            Owner = owner;
        }
    }
}
