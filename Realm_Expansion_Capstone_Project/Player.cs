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
    }
}
