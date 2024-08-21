using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a Bowmen unit and their stats
    /// </summary>
    public class Bowmen : Villager
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
        /// <param name="owner">Determine the owner of the bowmen unit</param>
        public Bowmen(int XCoor, int YCoor, String owner)
            :base(XCoor, YCoor, owner)
        {
            AttackRange = 2;
        }
    }
}
