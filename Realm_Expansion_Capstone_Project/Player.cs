using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represent a player and holds all of their stats
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Keeps track of how many times the player has lost a match 
        /// </summary>
        private int TotalDefeats = 0;

        /// <summary>
        /// keeps track of  how many times the player has won a match
        /// </summary>
        private int TotalVictories = 0;

        /// <summary>
        /// keeps track of how many enemy soldiers a player has killed over their career
        /// </summary>
        private int TotalKills = 0;
        
        /// <summary>
        /// keeps track of how many soldiers the player has lost in combat over their career
        /// </summary>
        private int TotalDeaths = 0;

        /// <summary>
        /// getter for the TotalDefeats variable 
        /// </summary>
        /// <returns>Total defeats of the player</returns>
        public int getTotalDefeats()
        {
            return TotalDefeats;
        }

        /// <summary>
        /// setter for the TotalDefeats variable 
        /// </summary>
        /// <param name="newDefeats">new amount of defeats</param>
        public void setTotalDefeats(int newDefeats)
        {
            TotalDefeats = newDefeats;
        }

        /// <summary>
        /// getter for the TotalVictories variable
        /// </summary>
        /// <returns>Total victories of the player</returns>
        public int getTotalVictories()
        {
            return TotalVictories;
        }

        /// <summary>
        /// setter for the TotalVictories variable 
        /// </summary>
        /// <param name="newVictories">the new amount of victories</param>
        public void setTotalVictories(int newVictories)
        {
            TotalVictories = newVictories;
        }

        /// <summary>
        /// getter for the TotalKills variable 
        /// </summary>
        /// <returns>Total kills of the player</returns>
        public int getTotalKills()
        {
            return TotalKills;
        }

        /// <summary>
        /// setter for the TotalKills variable 
        /// </summary>
        /// <param name="newKills">the new amount of kills by the player</param>
        public void setTotalKills(int newKills)
        {
            TotalKills = newKills;
        }

        /// <summary>
        /// getter for the TotalDeaths variable 
        /// </summary>
        /// <returns>the total deaths from the player</returns>
        public int getTotalDeaths()
        {
            return TotalDeaths;
        }

        /// <summary>
        /// setter for the TotalDeaths variable 
        /// </summary>
        /// <param name="newDeaths">the new amount of deaths for the player</param>
        public void setTotalDeaths(int newDeaths)
        {
            TotalDeaths = newDeaths;
        }
    }
}
