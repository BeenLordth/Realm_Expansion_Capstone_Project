using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Realm_Expansion_Capstone_Project
{
    public class Enemy : Realm
    {

        private Color color;

        private int Coins = 0;

        public Enemy(String name, Color color)
        {
            Name = name;
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }
        
        public int getCoins()
        {
            return Coins;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public void setCoins(int coins)
        {
            Coins = coins;
        }

        public static Enemy getEnemyByName(string name, Enemy[] Enemies)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy != null && enemy.getName() == name)
                {
                    return enemy;
                }
            }
            return null;
        }

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
