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
        protected int Level = 1;

        /// <summary>
        /// Identifies the X coordinate of the city (horizontal)
        /// </summary>
        protected int XCoordinate;

        /// <summary>
        /// Identifies the Y coordinate of the city (vertical)
        /// </summary>
        protected int YCoordinate;

        /// <summary>
        /// Identifies the owner of the city
        /// </summary>
        protected String Owner;

        /// <summary>
        /// Determintes the current health of the city
        /// </summary>
        protected int Health = 800;

        /// <summary>
        /// Determinte the current attack range of the city
        /// </summary>
        protected int AttackRange = 0;

        /// <summary>
        /// Determinte the current attack damage of the city 
        /// </summary>
        protected int AttackDamage = 0;

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

        /// <summary>
        /// getter for the Level variable 
        /// </summary>
        /// <returns>current level of the city</returns>
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

        /// <summary>
        /// getter for the XCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the city</returns>
        public int getXCoordinate()
        {
            return XCoordinate;
        }

        /// <summary>
        /// setter for the XCoordinate variable 
        /// </summary>
        /// <param name="newXCoord">the new coordinates of the city</param>
        public void setXCoordinate(int newXCoord)
        {
            XCoordinate = newXCoord;
        }

        /// <summary>
        /// getter for the YCoordinate variable 
        /// </summary>
        /// <returns>current coordinates of the city</returns>
        public int getYCoordinate()
        {
            return YCoordinate;
        }

        /// <summary>
        /// setter for the YCoordinate variable 
        /// </summary>
        /// <param name="newYCoord">new coordinates of the city</param>
        public void setYCoordinate(int newYCoord)
        {
            YCoordinate = newYCoord;
        }

        /// <summary>
        /// getter for the Owner varaible 
        /// </summary>
        /// <returns>owner of the city</returns>
        public String getOwner()
        {
            return Owner;
        }

        /// <summary>
        /// setter of the Owner variable 
        /// </summary>
        /// <param name="newOwner">the new owner of the city</param>
        public void setOwner(String newOwner)
        {
            Owner = newOwner;
        }

        /// <summary>
        /// getter for the Health variable 
        /// </summary>
        /// <returns>the current health of the city</returns>
        public int getHealth()
        {
            return Health;
        }

        /// <summary>
        /// setter for the Health variable 
        /// </summary>
        /// <param name="newHealth">the new health amont for the city</param>
        public void setHealth(int newHealth)
        {
            Health = newHealth;
        }

        /// <summary>
        /// getter for the AttackRange variable 
        /// </summary>
        /// <returns>the current attack range of the city</returns>
        public int getAttackRange()
        {
            return AttackRange;
        }

        /// <summary>
        /// setter for the AttackRange variable 
        /// </summary>
        /// <param name="newAttackRange">the new attack range of the city</param>
        public void setAttackRange(int newAttackRange)
        {
            AttackRange = newAttackRange;
        }

        /// <summary>
        /// getter for the AttackDamage variable 
        /// </summary>
        /// <returns>the current attack damage of the city</returns>
        public int getAttackDamage()
        {
            return AttackDamage;
        }

        /// <summary>
        /// setter for the AttackDamage variable 
        /// </summary>
        /// <param name="newAttackDamage">the new attackdamage for the city</param>
        public void setAttackDamage(int newAttackDamage)
        {
            AttackDamage = newAttackDamage;
        }
    }
}
