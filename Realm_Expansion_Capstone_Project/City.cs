using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a city found within a game board
    /// </summary>
    public class City
    {
        /// <summary>
        /// Identifies the current level of the city 
        /// </summary>
        private int Level = 1;

        /// <summary>
        /// Identifies the X coordinate of the city (horizontal)
        /// </summary>
        private int XCoordinate;

        /// <summary>
        /// Identifies the Y coordinate of the city (vertical)
        /// </summary>
        private int YCoordinate;

        /// <summary>
        /// Identifies the owner of the city
        /// </summary>
        private String Owner;

        /// <summary>
        /// Determintes the current health of the city
        /// </summary>
        private int Health = 800;

        /// <summary>
        /// Determinte the current attack range of the city
        /// </summary>
        private int AttackRange = 0;

        /// <summary>
        /// Determinte the current attack damage of the city 
        /// </summary>
        private int AttackDamage = 0;

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="XCoor">Determine where along the X axis of the board the city will be placed</param>
        /// <param name="YCoor">Determine where along the Y axis of the board the city will be placed</param>
        /// <param name="owner">Determine the owner of the city</param>
        public City(int XCoor, int YCoor, String owner)
        {
            XCoordinate = XCoor;
            YCoordinate = YCoor;
            Owner = owner;
        }
    }
}
