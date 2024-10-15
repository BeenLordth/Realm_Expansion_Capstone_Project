using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// subclass of Realm to represent the player's opponent
    /// </summary>
    public class Enemy : Realm
    {
        /// <summary>
        /// the color that represents this enemy
        /// </summary>
        private Color color;

        /// <summary>
        /// the amount of coins that this enemy owns
        /// </summary>
        private int Coins = 0;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="name">identify the name of the enemy</param>
        /// <param name="color">identify the color that represents the enemy</param>
        public Enemy(String name, Color color)
        {
            Name = name;
            this.color = color;
        }

        /// <summary>
        /// returns the color of the enemy 
        /// </summary>
        /// <returns>Color</returns>
        public Color getColor()
        {
            return color;
        }
        
        /// <summary>
        /// returns the amount of coins that the enemy owns
        /// </summary>
        /// <returns>Coins</returns>
        public int getCoins()
        {
            return Coins;
        }

        /// <summary>
        /// change the color that identifies the enemy
        /// </summary>
        /// <param name="color">new identifying color</param>
        public void setColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// change the amount of coins that the enemy owns
        /// </summary>
        /// <param name="coins">new coin amount</param>
        public void setCoins(int coins)
        {
            Coins = coins;
        }

        /// <summary>
        /// find a return a enemy instance from a list based on their name
        /// </summary>
        /// <param name="name">the name of the enemy being searched</param>
        /// <param name="Enemies">the list where the enemy is being looked for</param>
        /// <returns></returns>
        public static Enemy getEnemyByName(string name, Enemy[] Enemies)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy != null && enemy.getName() == name)
                {
                    return enemy;
                }
            }
            return null; // return null if enemy is not found in the list given
        }

        /// <summary>
        /// create all the enemies that will participate in the game
        /// </summary>
        /// <param name="enemyCt">the amont of enemies</param>
        /// <param name="Buttons">array of buttons where enemy will be placed</param>
        /// <param name="Blocks">array of blocks where enemy will be placed</param>
        /// <param name="Enemies">array of enemies where the enemy will be added to</param>
        /// <param name="nonOccupiedCities">list of cities where the enemy can take recidence in</param>
        /// <param name="OccupiedCities">list of cities where the enemy cannot take recidence in</param>
        public static void createEnemies(int enemyCt, Button[] Buttons, Block[] Blocks, Enemy[] Enemies, List<City> nonOccupiedCities, List<City> OccupiedCities)
        {
            List<Color> enemyColors = new List<Color> { Colors.Red, Colors.Orange, Colors.Purple };
            List<String> Names = new List<String> { "Reach", "Dorne", "Crownlands", "Stormlands", "Ironlands", "Vale", "Riverlands", "Dothrak", "YiTi", "Nhai" };

            Random randomName = new Random();
            Random randomColor = new Random();

            for (int i = 0; i < enemyCt; i++)
            {
                int selectedNameIndex = randomName.Next(Names.Count);
                int selectedColorIndex = randomColor.Next(enemyColors.Count);

                String name = Names[selectedNameIndex];
                Names.Remove(name);

                Color color = enemyColors[selectedColorIndex];
                enemyColors.Remove(color);

                Enemy enemy = new Enemy(name, color);
                Enemies[i] = enemy;

                Block.createBase(Enemies[i].getName(), Enemies[i].getColor(), Buttons, Blocks, nonOccupiedCities, OccupiedCities);
            }
        }

    }
}
