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
        protected int TravelRange = 1;

        /// <summary>
        /// Identifies the current level of the unit
        /// </summary>
        protected Boolean CanMove = true;

        protected Boolean CanAttack = true;

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
        /// identify if villager cn ataack or not
        /// </summary>
        /// <returns></returns>
        public Boolean getCanAttack()
        {
            return CanAttack;
        }

        /// <summary>
        /// change if villager can attack
        /// </summary>
        /// <param name="canattack"></param>
        public void setCanAttack(Boolean canattack)
        {
            CanAttack = canattack;
        }

        /// <summary>
        /// getter for the Level variable 
        /// </summary>
        /// <returns>current level of the bowmen</returns>
        public Boolean getCanMove()
        {
            return CanMove;
        }

        /// <summary>
        /// setter for the Level variable 
        /// </summary>
        public void setCanMove(Boolean canmove)
        {
            CanMove = canmove;
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

        /// <summary>
        /// find a villager within a list
        /// </summary>
        /// <param name="villager">villager to be found</param>
        /// <param name="villagers">list of villages to find villager in</param>
        /// <returns></returns>
        public static Villager findVillagerInBlocks(Block villager, List<Villager> villagers)
        {
            foreach (Villager village in villagers)
            {
                if (village.getXCoordinate() == villager.getXCoordinate() && village.getYCoordinate() == villager.getYCoordinate())
                {
                    return village;
                }
            }
            return null;
        }

        /// <summary>
        /// change the coordinates of a unit
        /// </summary>
        /// <param name="oldVillage">old village </param>
        /// <param name="newVillage">new village</param>
        /// <param name="villagers">list of villages to find the villages in</param>
        public static void changeCoordinates(Villager oldVillage, Block newVillage, List<Villager> villagers)
        {
            foreach (Villager vil  in villagers)
            {
                if (vil.getXCoordinate() == oldVillage.getXCoordinate() && vil.getYCoordinate() == oldVillage.getYCoordinate())
                {
                    vil.setXCoordinate(newVillage.getXCoordinate());
                    vil.setYCoordinate(newVillage.getYCoordinate());
                }
            }
        }

        /// <summary>
        /// display information about a villager
        /// </summary>
        /// <param name="village">villager to display</param>
        /// <param name="villages">list of villagers to find village in</param>
        public static void displayVillager(Villager village, List<Villager> villages)
        {
            foreach(Villager vil in villages)
            {
                if (village.XCoordinate == vil.getXCoordinate() && village.YCoordinate == vil.getYCoordinate())
                {
                    String msg = "Health: " + vil.getHealth();
                    msg += "\nAttack Damage: " + vil.getAttackDamage();
                    msg += "\nAttack Range: " + vil.getAttackRange();
                    msg += "\nTravel Range: " + vil.getTravelRange();
                    MessageBox.Show(msg, "Villager Army Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
        }

        /// <summary>
        /// determine how the villager attacks different enemy types
        /// </summary>
        /// <param name="village">attacker</param>
        /// <param name="target">target</param>
        /// <param name="villages">list of villages to get info</param>
        /// <param name="cities">list of cities to get info </param>
        /// <param name="watchtowers">list of tower to get info</param>
        /// <param name="player">player instance</param>
        /// <param name="blocks">array of blocks to update info</param>
        /// <param name="buttons">array of buttons to update info</param>
        /// <param name="enemies">array of enemies to get info</param>
        public static void attackEnemy(Villager village, Block target, List<Villager> villages, List<City> cities, List<WatchTower> watchtowers, Player player, Block[] blocks, Button[] buttons, Enemy[] enemies)
        {
            Villager vilToRemove = null;
            //find enemy village unit, if it exists
            foreach (Villager TargetVil in villages)
            {
                if (target.getXCoordinate() == TargetVil.getXCoordinate() && target.getYCoordinate() == TargetVil.getYCoordinate())
                {
                    //find the attacking village
                    foreach (Villager AttackingVillage in villages)
                    {
                        if (village.getXCoordinate() == AttackingVillage.getXCoordinate() && village.getYCoordinate() == AttackingVillage.getYCoordinate())
                        {
                            int damageToEnemy = AttackingVillage.getAttackDamage();
                            int damageToSelf = TargetVil.getAttackDamage() / 4;

                            //change the unit health of each one
                            TargetVil.setHealth(TargetVil.getHealth() - damageToEnemy);
                            AttackingVillage.setHealth(AttackingVillage.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            // display battle results
                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingVillage.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining enemy soldiers: " + TargetVil.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            // get rid of dead units
                            if(TargetVil.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(TargetVil.getXCoordinate(), TargetVil.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, AttackingVillage.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                vilToRemove = TargetVil;
                            }
                            if (AttackingVillage.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(AttackingVillage.getXCoordinate(), AttackingVillage.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, TargetVil.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                vilToRemove = AttackingVillage;
                            }
                            break;
                        }
                    }
                }
            }
            villages.Remove(vilToRemove);
            vilToRemove = null;
            //find the enemy city, if it exists
            foreach (City TargetCity in cities)
            {
                if (target.getXCoordinate() == TargetCity.getXCoordinate() && target.getYCoordinate() == TargetCity.getYCoordinate())
                {
                    // find the attacking village
                    foreach (Villager AttackingVillage in villages)
                    {
                        if (village.getXCoordinate() == AttackingVillage.getXCoordinate() && village.getYCoordinate() == AttackingVillage.getYCoordinate())
                        {
                            int damageToEnemy = AttackingVillage.getAttackDamage();
                            int damageToSelf = TargetCity.getAttackDamage() / 2;

                            //change the unit health of each one
                            TargetCity.setHealth(TargetCity.getHealth() - damageToEnemy);
                            AttackingVillage.setHealth(AttackingVillage.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            //display the battle results
                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingVillage.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining city soldiers: " + TargetCity.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                            // get rid of dead units
                            if(TargetCity.getHealth() <= 0)
                            {
                                TargetCity.setHealth(800);
                                TargetCity.setOwner(AttackingVillage.getOwner());
                                Block cityBlock = Block.findBlock(TargetCity.getXCoordinate(), TargetCity.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(cityBlock, TargetCity.getOwner(), "City", buttons, blocks, enemies, player);
                            }
                            if (AttackingVillage.getHealth() <= 0)
                            {
                                Block enemyBlock = Block.findBlock(AttackingVillage.getXCoordinate(), AttackingVillage.getYCoordinate(), blocks);
                                Block.updateBlockAppearance(enemyBlock, TargetCity.getOwner(), "Grassland", buttons, blocks, enemies, player);
                                vilToRemove = AttackingVillage;
                            }
                            break;
                        }
                    }
                }
            }
            villages.Remove(vilToRemove);
            //find the enemy tower, if it exists
            foreach (WatchTower TargetTower in watchtowers)
            {
                if (target.getXCoordinate() == TargetTower.getXCoordinate() && target.getYCoordinate() == TargetTower.getYCoordinate())
                {
                    // find the attacking village
                    foreach (Villager AttackingVillage in villages)
                    {
                        if (village.getXCoordinate() == AttackingVillage.getXCoordinate() && village.getYCoordinate() == AttackingVillage.getYCoordinate())
                        {
                            int damageToEnemy = AttackingVillage.getAttackDamage();
                            int damageToSelf = TargetTower.getAttackDamage() / 4;

                            // update the unit health of each one
                            TargetTower.setHealth(TargetTower.getHealth() - damageToEnemy);
                            AttackingVillage.setHealth(AttackingVillage.getHealth() - damageToSelf);
                            player.setTotalKills(player.getTotalKills() + damageToEnemy);
                            player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                            // display the battle results
                            String msg = "Damage taken: " + damageToSelf;
                            msg += "\nRemaining soldiers: " + AttackingVillage.getHealth();
                            msg += "\n\nDamage dealt: " + damageToEnemy;
                            msg += "\nRemaining watch tower soldiers: " + TargetTower.getHealth();
                            MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// take a city if it is no occupied
        /// </summary>
        /// <param name="space">block of unit</param>
        /// <param name="occupied">list of occupied cities</param>
        /// <param name="unoccupied">list of not occupied cities</param>
        /// <param name="Blocks">array of blocks to update info</param>
        /// <param name="Buttons">array of buttons to update info</param>
        /// <param name="Enemies">array of enemies to get info</param>
        /// <param name="Player">player instance</param>
        public static void ClaimCity(Block space, List<City> occupied, List<City> unoccupied, Block[] Blocks, Button[] Buttons, Enemy[] Enemies, Player Player)
        {
            int unitX = space.getXCoordinate();
            int unitY = space.getYCoordinate();

            // go through units surrounding blocks and see if one of them is a lone city
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }
                    int newX = unitX + x;
                    int newY = unitY + y;
                    if (newX >= 0 && newX <= 29 && newY >= 0 && newY <= 29)
                    {
                        Block surroundingBlock = Block.findBlock(newX, newY, Blocks);

                        for (int i = 0; i < unoccupied.Count; i++)
                        {
                            // take city if it is alone and within unit range
                            if (unoccupied[i].getXCoordinate() == surroundingBlock.getXCoordinate() && unoccupied[i].getYCoordinate() == surroundingBlock.getYCoordinate())
                            {
                                unoccupied[i].setOwner(space.getOwner());
                                occupied.Add(unoccupied[i]);
                                unoccupied.RemoveAt(i);
                                Block.updateBlockAppearance(surroundingBlock, space.getOwner(), "City", Buttons, Blocks, Enemies, Player);
                                i--;
                            }
                        }
                    }
                }
            }
        }


    }
}
