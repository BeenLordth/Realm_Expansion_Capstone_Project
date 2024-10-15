using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// base class for enemies and player
    /// </summary>
    public class Realm
    {
        /// <summary>
        /// identifies the total number of villager units owned by the realm 
        /// </summary>
        protected int totalVillagers = 0;

        /// <summary>
        /// identifies the total number of watchtowers owned by the realm
        /// </summary>
        protected int totalWatchTowers = 0;

        /// <summary>
        /// identifies the name of the realm
        /// </summary>
        protected String Name;

        /// <summary>
        /// a list of all the villagers owned by the realm
        /// </summary>
        protected List<Villager> villagers = new List<Villager>();

        /// <summary>
        /// a list of all the watch towrs owned by the realm
        /// </summary>
        protected List<WatchTower> watchTowers = new List<WatchTower>();

        /// <summary>
        /// return the number of villager units that the realm ahas
        /// </summary>
        /// <returns>totalVillagers</returns>
        public int getTotalVillagers()
        {
            return totalVillagers;
        }

        /// <summary>
        /// returns the total watch towers that the realm owns
        /// </summary>
        /// <returns>totalWatchTowrs</returns>
        public int getTotalWatchTowers()
        {
            return totalWatchTowers;
        }

        /// <summary>
        /// returns the name of the realm 
        /// </summary>
        /// <returns>name</returns>
        public String getName()
        {
            return Name;
        }

        /// <summary>
        /// changes the total villager units alive
        /// </summary>
        /// <param name="total">new total</param>
        public void setTotalVillagers(int total)
        {
            totalVillagers = total;
        }

        /// <summary>
        /// changes the total watch towers standing
        /// </summary>
        /// <param name="total">new total</param>
        public void setTotalWatchTowers(int total)
        {
            totalWatchTowers = total;
        }

        /// <summary>
        /// determines the name of the realm
        /// </summary>
        /// <param name="name">the name of the realm</param>
        public void setName(String name)
        {
            Name = name;
        }

        /// <summary>
        /// determines the amount of units that can move
        /// </summary>
        /// <returns>totalVillagers</returns>
        public int TotalUnits()
        {
            return totalVillagers;
        }

        /// <summary>
        /// calculate the amount of gold that they can earn based on the amount of blocks that the realm owns
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Blocks"></param>
        /// <returns></returns>
        public static int calculateGoldIncome(String name, Block[] Blocks)
        {
            int gold = 0;
            foreach (Block block in Blocks)
            {
                if (block.getOwner() == name)
                {
                    gold += 50; // earn 50 gold for each block owned
                }
            }
            return gold;
        }
    }
}
