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

        /// <summary>
        /// getter for the XCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the unit</returns>
        public int getXCoordinate()
        {
            return XCoordinate;
        }

        /// <summary>
        /// setter for the XCoordinate variable 
        /// </summary>
        /// <param name="newXCoord">the new coordinates of the unit</param>
        public void setXCoordinate(int newXCoord)
        {
            XCoordinate = newXCoord;
        }

        /// <summary>
        /// getter for the YCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the unit</returns>
        public int getYCoordinate()
        {
            return YCoordinate;
        }

        /// <summary>
        /// setter for the YCoordinate variable 
        /// </summary>
        /// <param name="newYCoord">new coordinates of the unit</param>
        public void setYCoordinate(int newYCoord)
        {
            YCoordinate = newYCoord;
        }

        /// <summary>
        /// getter for the Owner varaible 
        /// </summary>
        /// <returns>owner of the unit</returns>
        public String getOwner()
        {
            return Owner;
        }

        /// <summary>
        /// setter of the Owner variable 
        /// </summary>
        /// <param name="newOwner">the new owner of the unit</param>
        public void setOwner(String newOwner)
        {
            Owner = newOwner;
        }

        /// <summary>
        /// getter for the Health variable 
        /// </summary>
        /// <returns>the current health of the unit</returns>
        public int getHealth()
        {
            return Health;
        }

        /// <summary>
        /// setter for the Health variable 
        /// </summary>
        /// <param name="newHealth">the new health amont for the unit</param>
        public void setHealth(int newHealth)
        {
            Health = newHealth;
        }

        /// <summary>
        /// getter for the AttackRange variable 
        /// </summary>
        /// <returns>the current attack range of the unit</returns>
        public int getAttackRange()
        {
            return AttackRange;
        }

        /// <summary>
        /// setter for the AttackRange variable 
        /// </summary>
        /// <param name="newAttackRange">the new attack range of the unit</param>
        public void setAttackRange(int newAttackRange)
        {
            AttackRange = newAttackRange;
        }

        /// <summary>
        /// getter for the AttackDamage variable 
        /// </summary>
        /// <returns>the current attack damage of the unit</returns>
        public int getAttackDamage()
        {
            return AttackDamage;
        }

        /// <summary>
        /// setter for the AttackDamage variable 
        /// </summary>
        /// <param name="newAttackDamage">the new attackdamage for the unit</param>
        public void setAttackDamage(int newAttackDamage)
        {
            AttackDamage = newAttackDamage;
        } 

        /// <summary>
        /// getter for the TravelRange variable
        /// </summary>
        /// <returns>the current travel range of the unit</returns>
        public int getTravelRange()
        {
            return TravelRange;
        }

        /// <summary>
        /// setter for the TravelRange unit
        /// </summary>
        /// <param name="newTravelRange">the new travel range of the unit</param>
        public void setTravelRange(int newTravelRange)
        {
            TravelRange = newTravelRange;
        }
    }
}
