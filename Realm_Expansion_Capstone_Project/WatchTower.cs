using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Represents a watch tower found within a game board
    /// </summary>
    public class WatchTower : City
    {

        protected Boolean CanAttack = true;

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

        public Boolean getCanAttack()
        {
            return CanAttack;
        }

        public void setCanAttack(Boolean canattack)
        {
            CanAttack = canattack;
        }

        public static void displayWatchTower(WatchTower tower, List<WatchTower> towers)
        {
            foreach (WatchTower wt in towers)
            {
                if (wt.getXCoordinate() == tower.getXCoordinate() && wt.getYCoordinate() == tower.getYCoordinate())
                {
                    String msg = "Health: " + wt.getHealth();
                    msg += "\nAttack Damage: " + wt.getAttackDamage();
                    msg += "\nAttack Range: " + wt.getAttackRange();
                    MessageBox.Show(msg, "WatchTower Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
        }

        public static WatchTower findWatchTowerInBlocks(Block watchtower, List<WatchTower> watchtowers)
        {
            foreach (WatchTower wt in watchtowers)
            {
                if(watchtower.getXCoordinate() == wt.getXCoordinate() && watchtower.getYCoordinate() == wt.getYCoordinate())
                {
                    return wt;
                }
            }
            return null;
        }

        public static void attackEnemy(WatchTower watchtower, Block target, List<Villager> villages, List<City> cities, List<WatchTower> watchtowers, Player player, Block[] blocks, Button[] buttons, Enemy[] enemies)
        {
            WatchTower wtToRemove = null;
            Villager vilToRemove = null;
            foreach (Villager TargetVil in villages)
            {
                if (target.getXCoordinate() == TargetVil.getXCoordinate() && target.getYCoordinate() == TargetVil.getYCoordinate())
                {
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetVil.getAttackDamage() / 4;

                            TargetVil.setHealth(TargetVil.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingTower.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining enemy soldiers: " + TargetVil.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (TargetVil.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(TargetVil.getXCoordinate(), TargetVil.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, AttackingTower.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                vilToRemove = TargetVil;
                            }
                            if (AttackingTower.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(AttackingTower.getXCoordinate(), AttackingTower.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, TargetVil.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                wtToRemove = AttackingTower;
                            }
                            break;
                        }
                    }
                }
            }
            villages.Remove(vilToRemove);
            watchtowers.Remove(wtToRemove);
            wtToRemove = null;
            foreach (City TargetCity in cities)
            {
                if (target.getXCoordinate() == TargetCity.getXCoordinate() && target.getYCoordinate() == TargetCity.getYCoordinate())
                {
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetCity.getAttackDamage() / 4;

                            TargetCity.setHealth(TargetCity.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingTower.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining city soldiers: " + TargetCity.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (TargetCity.getHealth() <= 0)
                            {
                                TargetCity.setHealth(800);
                                TargetCity.setOwner(AttackingTower.getOwner());
                                Block cityBlock = Block.findBlock(TargetCity.getXCoordinate(), TargetCity.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(cityBlock, TargetCity.getOwner(), "City", buttons, blocks, enemies, player);
                            }
                            if (AttackingTower.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(AttackingTower.getXCoordinate(), AttackingTower.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, TargetCity.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                wtToRemove = AttackingTower;
                            }
                            break;
                        }
                    }
                }
            }
            watchtowers.Remove(wtToRemove);
            foreach (WatchTower TargetTower in watchtowers)
            {
                if (target.getXCoordinate() == TargetTower.getXCoordinate() && target.getYCoordinate() == TargetTower.getYCoordinate())
                {
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetTower.getAttackDamage() / 4;

                            TargetTower.setHealth(TargetTower.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingTower.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining watch tower soldiers: " + TargetTower.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
            }
        }
    }
}