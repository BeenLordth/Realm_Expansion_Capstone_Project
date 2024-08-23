using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a swordmen unit and their stats
    /// </summary>
    public class Swordmen : Villager
    {
        /// <summary>
        /// Identifies the current level of the unit
        /// </summary>
        private int Level = 1;

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="XCoor">Determine where along the X axis of the board the unit will be placed</param>
        /// <param name="YCoor">Determine where along the Y axis of the board the unit will be placed</param>
        /// <param name="owner">Determine the owner of the swordmen unit</param>
        public Swordmen(int XCoor, int YCoor, String owner) 
            : base(XCoor, YCoor, owner)
        {
            XCoordinate = XCoor;
            YCoordinate = YCoor;
            Owner = owner;
            AttackDamage = 350;
        }

        /// <summary>
        /// getter for the Level variable 
        /// </summary>
        /// <returns>current level of the swordmen</returns>
        public int getLevel()
        {
            return Level;
        }

        /// <summary>
        /// setter for the Level variable 
        /// </summary>
        public void setLevel()
        {
            Level++;
        }
    }
}
