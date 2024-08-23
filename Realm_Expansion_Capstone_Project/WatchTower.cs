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
    public class WatchTower : City
    {
        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="XCoor">Determine where along the X axis of the board the watch tower will be placed</param>
        /// <param name="YCoor">Determine where along the Y axis of the board the watch tower will be placed</param>
        /// <param name="owner">Determine the owner of the watch tower</param>
        public WatchTower(int XCoor, int YCoor, String owner)
            :base(XCoor, YCoor, owner)
        {
            XCoordinate = XCoor;
            YCoordinate = YCoor;
            Owner = owner;
            Health = 550;
            AttackRange = 3;
            AttackDamage = 200;
        }
    }
}