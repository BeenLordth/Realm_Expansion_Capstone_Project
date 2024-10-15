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
        /// <summary>
        /// determine if the watch tower can attack or not
        /// </summary>
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

        /// <summary>
        /// determine if the tower can attack or not
        /// </summary>
        /// <returns>CanAttack</returns>
        public Boolean getCanAttack()
        {
            return CanAttack;
        }

        /// <summary>
        /// change whether the tower can attack or not
        /// </summary>
        /// <param name="canattack"></param>
        public void setCanAttack(Boolean canattack)
        {
            CanAttack = canattack;
        }

        /// <summary>
        /// display information about the watch tower in a popup
        /// </summary>
        /// <param name="tower">name of tower to display</param>
        /// <param name="towers">list of towers to find tower in</param>
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

        /// <summary>
        /// find and return a tower from within a given list
        /// </summary>
        /// <param name="watchtower">the tower that needs to be found</param>
        /// <param name="watchtowers">the list to find the tower in</param>
        /// <returns>the tower instance, if found</returns>
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

        /// <summary>
        /// determine the actions of the watch tower when attacking enemies
        /// </summary>
        /// <param name="watchtower">the attacker</param>
        /// <param name="target">the target</param>
        /// <param name="villages">list of villagers to get info from</param>
        /// <param name="cities">list of cities to get info from</param>
        /// <param name="watchtowers">list of watch towers to get info form</param>
        /// <param name="player">the player</param>
        /// <param name="blocks">array of blocks to update info</param>
        /// <param name="buttons">array of buttons to update info</param>
        /// <param name="enemies">array of enemies to get info</param>
        public static void attackEnemy(WatchTower watchtower, Block target, List<Villager> villages, List<City> cities, List<WatchTower> watchtowers, Player player, Block[] blocks, Button[] buttons, Enemy[] enemies)
        {
            WatchTower wtToRemove = null;
            Villager vilToRemove = null;
            // find the village target, if it exists
            foreach (Villager TargetVil in villages)
            {
                if (target.getXCoordinate() == TargetVil.getXCoordinate() && target.getYCoordinate() == TargetVil.getYCoordinate())
                {
                    //find the attacking tower
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetVil.getAttackDamage() / 4;

                            // update the health of each unit
                            TargetVil.setHealth(TargetVil.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            // display changes 
                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingTower.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining enemy soldiers: " + TargetVil.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            // get rid of dead units
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
            // find the city target, if it exists
            foreach (City TargetCity in cities)
            {
                if (target.getXCoordinate() == TargetCity.getXCoordinate() && target.getYCoordinate() == TargetCity.getYCoordinate())
                {
                    // find the attacking tower
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetCity.getAttackDamage() / 4;

                            // update unit stats
                            TargetCity.setHealth(TargetCity.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            //display results
                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingTower.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining city soldiers: " + TargetCity.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            // delete dead units
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
            // find the tower target if it exists
            foreach (WatchTower TargetTower in watchtowers)
            {
                if (target.getXCoordinate() == TargetTower.getXCoordinate() && target.getYCoordinate() == TargetTower.getYCoordinate())
                {
                    // find the attcking tower
                    foreach (WatchTower AttackingTower in watchtowers)
                    {
                        if (watchtower.getXCoordinate() == AttackingTower.getXCoordinate() && watchtower.getYCoordinate() == AttackingTower.getYCoordinate())
                        {
                            int damageToEnemy = AttackingTower.getAttackDamage();
                            int damageToSelf = TargetTower.getAttackDamage() / 4;

                            // change stats
                            TargetTower.setHealth(TargetTower.getHealth() - damageToEnemy);
                            AttackingTower.setHealth(AttackingTower.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            //display results
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