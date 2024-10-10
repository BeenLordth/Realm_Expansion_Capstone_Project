using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    public class Realm
    {
        protected int totalVillagers = 0;

        protected int totalWatchTowers = 0;

        protected String Name;

        protected List<Villager> villagers = new List<Villager>();

        protected List<WatchTower> watchTowers = new List<WatchTower>();

        public int getTotalVillagers()
        {
            return totalVillagers;
        }

        public int getTotalWatchTowers()
        {
            return totalWatchTowers;
        }

        public String getName()
        {
            return Name;
        }

        public void setTotalVillagers(int total)
        {
            totalVillagers = total;
        }

        public void setTotalWatchTowers(int total)
        {
            totalWatchTowers = total;
        }

        public void setName(String name)
        {
            Name = name;
        }

        public int TotalUnits()
        {
            return totalVillagers;
        }

        public static int calculateGoldIncome(String name, Block[] Blocks)
        {
            int gold = 0;
            foreach (Block block in Blocks)
            {
                if (block.getOwner() == name)
                {
                    gold += 50;
                }
            }
            return gold;
        }
    }
}
