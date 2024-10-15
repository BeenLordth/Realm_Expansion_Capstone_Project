using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        /// <summary>
        /// array of buttons to hold all the buttons displayed on screen
        /// </summary>
        private Button[] Buttons = new Button[900];

        /// <summary>
        /// array of blocks to hold all the blocks being represented on screen by buttons
        /// </summary>
        private Block[] Blocks = new Block[900];

        /// <summary>
        /// list of cities to hold all cities that are not owned by player or enemies
        /// </summary>
        private List<City> nonOccupiedCities = new List<City>();

        /// <summary>
        /// list of cities to hold all cities that are owned by player or enemies
        /// </summary>
        private List<City> OccupiedCities = new List<City>();

        /// <summary>
        /// array of enemies to hold all the enemies that will be fighting the player
        /// </summary>
        private Enemy[] Enemies = new Enemy[3];

        /// <summary>
        /// player instance to hold all the info
        /// </summary>
        private Player Player = new Player();

        /// <summary>
        /// list of villagers to hold all the units currently in the battlefield
        /// </summary>
        private List<Villager> Villagers = new List<Villager>();

        /// <summary>
        /// list of watch tower to hold all the towers currently standing in the battlefield
        /// </summary>
        private List<WatchTower> WatchTowers = new List<WatchTower>();

        /// <summary>
        /// determines the current function of mouse click on buttons
        /// </summary>
        private String CurrentBlockClickFunction = "";

        /// <summary>
        /// initialize the game window
        /// </summary>
        /// <param name="name"></param>
        /// <param name="enemyCt"></param>
        public Game(String name, int enemyCt)
        {
            InitializeComponent();
            SetUpGameBoard();
            Block.createBase(name, Colors.Blue, Buttons, Blocks, nonOccupiedCities, OccupiedCities);
            Enemy.createEnemies(enemyCt, Buttons, Blocks, Enemies, nonOccupiedCities, OccupiedCities);
            Player.setName(name);
            Block.giveBeginnerLand(Buttons, Blocks, Enemies, OccupiedCities, Player);
        }

        /// <summary>
        /// initial set up of the board
        /// </summary>
        private void SetUpGameBoard()
        {
            String Terrain =
            "WWWWWWWWWWWWGGGGGGGGGGGGGGGGGG" + // Row 1
            "WWWWWWWWWWGGGGGGGGGGGGCGGGGGGG" + // Row 2
            "WWWWWWWWGGGGGGGGGGGGGGGGGGMMMM" + // Row 3
            "WWWWWWWGGGGGGGGGGGGGGGGGMMMMMM" + // Row 4
            "WWWWWWWGGGGGGGGGGGGGGGGMMMMMMM" + // Row 5
            "WWWWGGGGGGGGGGGGGGGGGGMMMMMMMM" + // Row 6
            "WWWWGGGGGGGGGGGGGGGGGGGMMMMMMM" + // Row 7
            "WWGGGGGGGGGGGGGGGGGGGGMMMMMMMM" + // Row 8
            "GGGCGGGGGGGGGGGCGGMMMMMMMMMMMM" + // Row 9
            "MMGGGGGGGGGGGGGGGMMMMMMMMMMMMM" + // Row 10
            "MMMMGMMGGGGGGGGGGGMMMMMMMMMMMM" + // Row 11
            "MMMMMMMMMGGGGGGGGGGGGMMMGGGGMM" + // Row 12
            "MMMMMMMMMGGGGGGGGGGGMMMMGGGGGM" + // Row 13
            "MMGGGGGGGGGGGGGGGGGGMMMGGCGGGG" + // Row 14
            "GGGGGGGGGGGGCGGGGGGGMMGGGGGGGG" + // Row 15
            "GGGGGGGGGGGGGGGGGGGGMMGGGGGGGG" + // Row 16
            "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGG" + // Row 17
            "GGGGGGGGGGGGWWGGGGGGGGGGGGGGGG" + // Row 18
            "GGGGGGGGGGGGWWWGGGCGGGGGGGGGGG" + // Row 19
            "GGGGGGGGGGGWWWWGGGGGGGGGGGGGGG" + // Row 20
            "GGGGGGGGGGWWWWGGGGGGGGGGGGGGGG" + // Row 21
            "GGGGGGGGGWWWWGGGGGGGGGGGGGGCGG" + // Row 22
            "GGGGCGGGGWWWWGGGGGGGGGGGGGGGGG" + // Row 23
            "GGGGGGGGGWWWWGGGGGGGGGGGGGGGGG" + // Row 24
            "GGGGGGGGGGWWWGGGGGGGGWWWGGGGGG" + // Row 25
            "GGGGGGGGGGGWWWGGGGGGWWWWWGGGGG" + // Row 26
            "GGGGGGGGGGGWWWGGGGGGGWWWWGGGGG" + // Row 27
            "GGGGGGGGGGGWWWWGGGGGGGGGGGGGGG" + // Row 28
            "GGGGGCGGGGGGWWWGGGGGGCGGGGGGGG" + // Row 29
            "GGGGGGGGGGGGWWWWGGGGGGGGGGGGGG";  // Row 30

            Char[] TerrainCharArray = Terrain.ToCharArray();
            int xcoord = -1;
            int ycoord = -1;

            //create all the buttons and blocks and fill them with initial values
            for (int i = 0; i < Blocks.Length; i++)
            {
                Button button = new Button();
                button.Width = 30;
                button.Height = 30;
                button.BorderThickness = new Thickness(0);
                Image terrainImg = new Image();
                Block block;

                //give a button a certain look depending on the string map
                if (TerrainCharArray[i] == 'M')
                {
                    block = new Block("Mountain", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/mountain.jpg", UriKind.Relative));
                } 
                else if (TerrainCharArray[i] == 'G')
                {
                    block = new Block("Grassland", "NA", true);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/grassland.jpg", UriKind.Relative));

                } 
                else if (TerrainCharArray[i] == 'W')
                {
                    block = new Block("Water", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/water.jpg", UriKind.Relative));

                } 
                else
                {
                    block = new Block("City", "NA", false);
                    terrainImg.Source = new BitmapImage(new Uri("Assets/Images/city.jpg", UriKind.Relative));
                }

                xcoord = Block.updateXCoordSetUp(xcoord);
                ycoord = Block.updateYcoordSetUp(xcoord, ycoord);
                block.setXCoordinate(xcoord);
                block.setYCoordinate(ycoord);
                block.setIndex(i);
                Blocks[i] = block;

                if(block.getTerrain() == "City")
                {
                    City city = new City(block.getXCoordinate(), block.getYCoordinate(), "Empty");
                    nonOccupiedCities.Add(city);
                }

                button.Name = "_" + block.getXCoordinate().ToString() + "_" + block.getYCoordinate().ToString();
                button.Content = terrainImg;
                button.Tag = block;
                button.Click += BlockClick;
                Buttons[i] = button;
                G_game_board_stack_panel.Children.Add(button);
            }
        }

        /// <summary>
        /// detect which block was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BlockClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if(clickedButton != null)
            {
                Block clickedBlock = clickedButton.Tag as Block;
                if(clickedButton != null)
                {
                    //display block info in the top of the screen
                    G_coordinate_display_label.Content = $"{clickedBlock.getXCoordinate()}, {clickedBlock.getYCoordinate()}";
                    G_owner_display_label.Content = $"{clickedBlock.getOwner()}\n";
                    G_terrain_display_label.Content = $"{clickedBlock.getTerrain()}\n";

                    if (CurrentBlockClickFunction == "")
                    {
                        inspectBlock(clickedBlock);
                    }
                    else if (CurrentBlockClickFunction == "Attack" && clickedBlock.getOwner() == Player.getName() && clickedBlock.getHabitated())
                    {
                        selectAttackUnit(clickedBlock);
                    }
                    else if (CurrentBlockClickFunction == "AttackConfirmation")
                    {
                        selectAttackTarget(clickedBlock);
                    }
                    else if (CurrentBlockClickFunction == "Move" && clickedBlock.getOwner() == Player.getName() && clickedBlock.getHabitated())
                    {
                        foreach (Villager vil in Villagers)
                        {
                            if (clickedBlock.getXCoordinate() == vil.getXCoordinate() && clickedBlock.getYCoordinate() == vil.getYCoordinate())
                            {
                                MoveUnit(clickedBlock);
                                break;
                            }
                        }
                    }
                    else if (CurrentBlockClickFunction == "MoveConfirmation" && clickedBlock.getHabitated() == false)
                    {
                        moveConfirmation(clickedBlock);
                    }
                    else if (CurrentBlockClickFunction == "BuyWatchtower" && clickedBlock.getOwner() == Player.getName() && clickedBlock.getIsWalkable() && clickedBlock.getHabitated() == false)
                    {
                        placeWatchTower(clickedButton, clickedBlock);
                    }
                    else if (CurrentBlockClickFunction == "BuyVillager" && clickedBlock.getOwner() == Player.getName() && clickedBlock.getIsWalkable() && clickedBlock.getHabitated() == false)
                    {
                        placeVillager(clickedButton, clickedBlock);
                    }
                }
            }
        }

        /// <summary>
        /// update player and enemy data accordingly. give enemy their turn to move and attack
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void G_end_turn_button_Click(object sender, RoutedEventArgs e)
        {
            // update turn number
            string turnLabelText = G_turn_number_label.Content.ToString();
            int turnNumber = int.Parse(turnLabelText) + 1;
            G_turn_number_label.Content = turnNumber.ToString();

            //update gold amount 
            string goldLabelText = G_gold_number_label.Content.ToString();
            int newGold = int.Parse(goldLabelText) + Realm.calculateGoldIncome(Player.getName(), Blocks);
            G_gold_number_label.Content = newGold.ToString();

            //allow villagers and towers to attack again
            foreach(Villager vil in Villagers)
            {
                if(vil.getOwner() == Player.getName())
                {
                    vil.setCanMove(true);
                    vil.setCanAttack(true);
                }
            }

            foreach (WatchTower wt in WatchTowers)
            {
                if(wt.getOwner() == Player.getName())
                {
                    wt.setCanAttack(true);
                }
            }

            Random random = new Random();

            // update the gold amount of each enemy and allow them to move and attack
            foreach (Enemy enemy in Enemies)
            {
                if(enemy != null)
                {
                    enemy.setCoins(enemy.getCoins() + Realm.calculateGoldIncome(enemy.getName(), Blocks));

                    foreach (City city in OccupiedCities)
                    {
                        if (city.getOwner() == enemy.getName())
                        {
                            // given a small chance that the enemy will spawn a new villager unit
                            if (random.Next(0, 5) == 0) 
                            {
                                List<Block> adjacentBlocks = GetAdjacentBlocks(city);

                                List<Block> availableSpots = adjacentBlocks.Where(block => block.getIsWalkable() && !block.getHabitated()).ToList();

                                if (availableSpots.Count > 0 && enemy.getCoins() >= 500)
                                {
                                    Block citySurrounding = availableSpots[random.Next(availableSpots.Count)];

                                    enemy.setCoins(enemy.getCoins() - 500);
                                    citySurrounding.setHabitated(true);
                                    Block.updateBlockAppearance(citySurrounding, enemy.getName(), "Unit_Villager", Buttons, Blocks, Enemies, Player);

                                    Villager villager = new Villager(citySurrounding.getXCoordinate(), citySurrounding.getYCoordinate(), enemy.getName());
                                    Villagers.Add(villager);
                                    enemy.setTotalVillagers(enemy.getTotalVillagers() + 1);

                                }
                            }
                        }
                    }
                }
            }
            // allow enemy to move and attack
            EnemyAIturn();
        }

        /// <summary>
        /// get the blocks that surround a city
        /// </summary>
        /// <param name="city">city to search around</param>
        /// <returns></returns>
        private List<Block> GetAdjacentBlocks(City city)
        {
            List<Block> adjacentBlocks = new List<Block>();
            int cityX = city.getXCoordinate();
            int cityY = city.getYCoordinate();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    int newX = cityX + x;
                    int newY = cityY + y;

                    if (newX >= 0 && newX <= 29 && newY >= 0 && newY <= 29)
                    {
                        Block surroundingBlock = Block.findBlock(newX, newY, Blocks);
                        adjacentBlocks.Add(surroundingBlock);
                    }
                }
            }

            return adjacentBlocks;
        }

        /// <summary>
        /// get the blcoks that surround a villager
        /// </summary>
        /// <param name="villager">villager to search the sides of</param>
        /// <returns>list of adjaent blocks</returns>
        private List<Block> GetAdjacentBlocks(Villager villager)
        {
            List<Block> adjacentBlocks = new List<Block>();
            int x = villager.getXCoordinate();
            int y = villager.getYCoordinate();

            // Check the four adjacent blocks (up, down, left, right)
            if (x > 0) adjacentBlocks.Add(Block.findBlock(x - 1, y, Blocks)); 
            if (x < 29) adjacentBlocks.Add(Block.findBlock(x + 1, y, Blocks));
            if (y > 0) adjacentBlocks.Add(Block.findBlock(x, y - 1, Blocks));  
            if (y < 29) adjacentBlocks.Add(Block.findBlock(x, y + 1, Blocks)); 

            return adjacentBlocks;
        }


        /// <summary>
        /// allow player to attack with their units and exit out of attack mode
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void G_attack_button_Click(object sender, RoutedEventArgs e)
        {
            if (Player.TotalUnits() != 0 || Player.getTotalWatchTowers() != 0)
            {
                if (G_attack_button.Content.ToString() == "Attack")
                {
                    G_attack_button.Content = "Cancel";
                    CurrentBlockClickFunction = "Attack";
                    flipButtonAvailability(G_buy_villager_button, G_buy_watchtower_button, G_move_button, G_end_turn_button, G_quit_button);
                } 
                else
                {
                    G_attack_button.Content = "Attack";
                    CurrentBlockClickFunction = "";
                    flipButtonAvailability(G_buy_villager_button, G_buy_watchtower_button, G_move_button, G_end_turn_button, G_quit_button);
                }
            } 
            else
            {
                MessageBox.Show("You need to buy units before you can attack!", "No Units Available", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// allow player to move their units and exit out of move mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_move_button_Click(object sender, RoutedEventArgs e)
        {
            if (Player.TotalUnits() != 0)
            {
                if(G_move_button.Content.ToString() == "Move")
                {
                    G_move_button.Content = "Cancel";
                    CurrentBlockClickFunction = "Move";
                    flipButtonAvailability(G_buy_villager_button, G_buy_watchtower_button, G_attack_button, G_end_turn_button, G_quit_button);
                } 
                else
                {
                    G_move_button.Content = "Move";
                    CurrentBlockClickFunction = "";
                    flipButtonAvailability(G_buy_villager_button, G_buy_watchtower_button, G_attack_button, G_end_turn_button, G_quit_button);
                }
            }
            else
            {
                MessageBox.Show("You need to buy units before you can move them!", "No Units Available", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// allow player to go into purchase mode for watch towers and also exit this mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_buy_watchtower_button_Click(object sender, RoutedEventArgs e)
        {
            if (G_buy_watchtower_text.Text == "Buy Watchtower")
            {
                G_buy_watchtower_text.Text = "Cancel";
                CurrentBlockClickFunction = "BuyWatchtower";
                flipButtonAvailability(G_buy_villager_button, G_move_button, G_attack_button, G_end_turn_button, G_quit_button);
            }
            else
            {
                G_buy_watchtower_text.Text = "Buy Watchtower";
                CurrentBlockClickFunction = "";
                flipButtonAvailability(G_buy_villager_button, G_move_button, G_attack_button, G_end_turn_button, G_quit_button);
            }
        }

        /// <summary>
        /// allow player to go into purchase mode for villagers and also exit this mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_buy_villager_button_Click(object sender, RoutedEventArgs e)
        {
            if (G_buy_villager_text.Text == "Buy Villager Unit")
            {
                G_buy_villager_text.Text = "Cancel";
                CurrentBlockClickFunction = "BuyVillager";
                flipButtonAvailability(G_buy_watchtower_button, G_move_button, G_attack_button, G_end_turn_button, G_quit_button);
            } 
            else
            {
                G_buy_villager_text.Text = "Buy Villager Unit";
                CurrentBlockClickFunction = "";
                flipButtonAvailability(G_buy_watchtower_button, G_move_button, G_attack_button, G_end_turn_button, G_quit_button);
            }
        }

        /// <summary>
        /// change the availability of buttons to the opposite of what they currently are at. 
        /// </summary>
        /// <param name="btn1">button</param>
        /// <param name="btn2">button</param>
        /// <param name="btn3">button</param>
        /// <param name="btn4">button</param>
        /// <param name="btn5">button</param>
        private void flipButtonAvailability(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5)
        {
            if (btn1.IsEnabled)
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
            } else
            {
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
            }
        }

        /// <summary>
        /// allow player to quick back to the main menu with a warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_quit_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to quit? You will lose all progress.",
                "Quit Game",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// allow player to pick a place to place a watch tower 
        /// </summary>
        /// <param name="button">button where the tower will be placed</param>
        /// <param name="block">block where the tower will be placed</param>
        private void placeWatchTower(Button button, Block block)
        {
            int gold = int.Parse(G_gold_number_label.Content.ToString());
            MessageBoxResult result = MessageBox.Show(
                "Do you want to place a watchtower here for 1000 gold?",
                "Place Watchtower",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (gold >= 1000)
                {
                    // Deduct 1000 gold from the player
                    gold -= 1000;
                    G_gold_number_label.Content = gold.ToString();
                    block.setHabitated(true);
                    Block.updateBlockAppearance(block, block.getOwner(), "WatchTower", Buttons, Blocks, Enemies, Player);
                    WatchTower tower = new WatchTower(block.getXCoordinate(), block.getYCoordinate(), block.getOwner());
                    WatchTowers.Add(tower);
                    Player.setTotalWatchTowers(Player.getTotalWatchTowers() + 1);

                    MessageBox.Show("Watchtower placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Notify the player if they don't have enough gold
                    MessageBox.Show("You don't have enough gold to place a watchtower!", "Not Enough Gold", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// allow player to pick a place to place a villager unit
        /// </summary>
        /// <param name="button">button where villager will be placed</param>
        /// <param name="block">block where villager will be placed</param>
        private void placeVillager(Button button, Block block)
        {
            int gold = int.Parse(G_gold_number_label.Content.ToString());
            MessageBoxResult result = MessageBox.Show(
                "Do you want to place a villager here for 500 gold?",
                "Place Villager",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (gold >= 500)
                {
                    // Deduct 500 gold from the player
                    gold -= 500;
                    G_gold_number_label.Content = gold.ToString();

                    block.setHabitated(true);
                    Block.updateBlockAppearance(block, block.getOwner(), "Unit_Villager", Buttons, Blocks, Enemies, Player);

                    Villager villager = new Villager(block.getXCoordinate(), block.getYCoordinate(), block.getOwner());
                    Villagers.Add(villager);
                    Player.setTotalVillagers(Player.getTotalVillagers() + 1);

                    MessageBox.Show("Villager placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Notify the player if they don't have enough gold
                    MessageBox.Show("You don't have enough gold to place a villager!", "Not Enough Gold", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// list of spots that the player can place unit in
        /// </summary>
        List<Block> availableSpots = new List<Block>();

        /// <summary>
        /// villager that is being moved
        /// </summary>
        Villager movingVillager = null;

        /// <summary>
        /// pick a place to move the unit to
        /// </summary>
        /// <param name="block">original place of villager</param>
        private void MoveUnit(Block block)
        {
            availableSpots.Clear();
            movingVillager = null;
            movingVillager = Villager.findVillagerInBlocks(block, Villagers);

            if (movingVillager.getCanMove())
            {
                int unitX = block.getXCoordinate();
                int unitY = block.getYCoordinate();

                for (int x = -1 * movingVillager.getTravelRange(); x <= movingVillager.getTravelRange(); x++)
                {
                    for (int y = -1 * movingVillager.getTravelRange(); y <= movingVillager.getTravelRange(); y++)
                    {
                        if(x == 0 && y == 0)
                        {
                            continue;
                        }

                        int newX = unitX + x;
                        int newY = unitY + y;

                        if (newX >= 0 && newX <= 29 && newY >= 0 && newY <= 29)
                        {
                            Block surroundingBlock = Block.findBlock(newX, newY, Blocks);
                            if (surroundingBlock.getIsWalkable() && surroundingBlock.getHabitated() == false)
                            {
                                availableSpots.Add(surroundingBlock);
                                Block.updateBlockAppearance(surroundingBlock, surroundingBlock.getOwner(), "UnitBase", Buttons, Blocks, Enemies, Player);
                            }
                        }
                    }
                }
                availableSpots.Add(block);
            
                CurrentBlockClickFunction = "MoveConfirmation";
                G_move_button.IsEnabled = false;
            } else
            {
                MessageBox.Show("You already moved this unit", "Move Limit", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// verify that the new block is available before moving unit here
        /// </summary>
        /// <param name="block">new block to move to</param>
        private void moveConfirmation(Block block)
        {
            Block confirmedBlock = null;
            foreach (Block available in availableSpots)
            {
                if(available.getXCoordinate() == block.getXCoordinate() && available.getYCoordinate() == block.getYCoordinate())
                {
                    confirmedBlock = available;
                    break;
                }
            }

            if(confirmedBlock != null)
            {
                foreach (Block available in availableSpots)
                {
                    Block.updateBlockAppearance(available, available.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);
                }
                Block.updateBlockAppearance(confirmedBlock, Player.getName(), "Unit_Villager", Buttons, Blocks, Enemies, Player);
                Villager.changeCoordinates(movingVillager, block, Villagers);
                movingVillager.setCanMove(false);
                Villager.ClaimCity(confirmedBlock, OccupiedCities, nonOccupiedCities, Blocks, Buttons, Enemies, Player);
                CurrentBlockClickFunction = "Move";
                G_move_button.IsEnabled = true;
            }
        }

        /// <summary>
        /// list of blocks that can be attacked
        /// </summary>
        List<Block> attackableBlocks = new List<Block>();

        /// <summary>
        /// villager that will be used to attack
        /// </summary>
        Villager attackingVillager = null;

        /// <summary>
        /// watch tower that will be used to attack 
        /// </summary>
        WatchTower attackingWatchtower = null;

        /// <summary>
        /// select the unit that will be used to attack 
        /// </summary>
        /// <param name="block"></param>
        private void selectAttackUnit(Block block)
        {
            availableSpots.Clear();
            attackableBlocks.Clear();
            attackingVillager = null;
            attackingWatchtower = null;
            attackingVillager = Villager.findVillagerInBlocks(block, Villagers);
            attackingWatchtower = WatchTower.findWatchTowerInBlocks(block, WatchTowers);
            int unitX = block.getXCoordinate();
            int unitY = block.getYCoordinate();
            // path if the unit is a villager
            if (attackingVillager != null && attackingWatchtower == null)
            {
                if (attackingVillager.getCanAttack() == true)
                {
                    for (int x = -1 * attackingVillager.getAttackRange(); x <= attackingVillager.getAttackRange(); x++)
                    {
                        for (int y = -1 * attackingVillager.getAttackRange(); y <= attackingVillager.getAttackRange(); y++)
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
                                if (surroundingBlock.getIsWalkable() && surroundingBlock.getHabitated() == false)
                                {
                                    availableSpots.Add(surroundingBlock);
                                    Block.updateBlockAppearance(surroundingBlock, surroundingBlock.getOwner(), "Attack_Symbol", Buttons, Blocks, Enemies, Player);
                                }
                                else if (surroundingBlock.getTerrain() == "City" || surroundingBlock.getHabitated() == true)
                                {
                                    attackableBlocks.Add(surroundingBlock);
                                }
                            }
                        }
                    }
                    CurrentBlockClickFunction = "AttackConfirmation";
                    G_attack_button.IsEnabled = false;
                } else
                {
                    MessageBox.Show("You already attacked with this unit", "Attack Limit", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } 
            //path if the unit is a watch tower
            else if (attackingVillager == null && attackingWatchtower != null)
            {
                if (attackingWatchtower.getCanAttack() == true)
                {
                    for (int x = -1 * attackingWatchtower.getAttackRange(); x <= attackingWatchtower.getAttackRange(); x++)
                    {
                        for (int y = -1 * attackingWatchtower.getAttackRange(); y <= attackingWatchtower.getAttackRange(); y++)
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
                                if (surroundingBlock.getIsWalkable() && surroundingBlock.getHabitated() == false)
                                {
                                    availableSpots.Add(surroundingBlock);
                                    Block.updateBlockAppearance(surroundingBlock, surroundingBlock.getOwner(), "Attack_Symbol", Buttons, Blocks, Enemies, Player);
                                }
                                else if (surroundingBlock.getTerrain() == "City" || surroundingBlock.getHabitated() == true)
                                {
                                    attackableBlocks.Add(surroundingBlock);
                                }
                            }
                        }
                    }
                    CurrentBlockClickFunction = "AttackConfirmation";
                    G_attack_button.IsEnabled = false;
                } else
                {
                    MessageBox.Show("You already attacked with this unit", "Attack Limit", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// select the block that player wants to attack
        /// </summary>
        /// <param name="block"></param>
        private void selectAttackTarget(Block block)
        {
            //path if attack unit is villager
            if (attackingVillager != null && attackingWatchtower == null)
            {
                if (attackingVillager.getXCoordinate() == block.getXCoordinate() && attackingVillager.getYCoordinate() == block.getYCoordinate())
                {
                    foreach (Block available in availableSpots)
                    {
                        Block.updateBlockAppearance(available, available.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);
                    }
                    CurrentBlockClickFunction = "Attack";
                    G_attack_button.IsEnabled = true;
                }
                else
                {
                    Block attackTarget = null;
                    foreach (Block attackable in attackableBlocks)
                    {
                        if (attackable.getXCoordinate() == block.getXCoordinate() && attackable.getYCoordinate() == block.getYCoordinate())
                        {
                            attackTarget = attackable;
                            break;
                        }
                    }

                    if (attackTarget != null && attackTarget.getOwner() != Player.getName())
                    {
                        foreach (Block available in availableSpots)
                        {
                            Block.updateBlockAppearance(available, available.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);
                        }
                        Villager.attackEnemy(attackingVillager, attackTarget, Villagers, OccupiedCities, WatchTowers, Player, Blocks, Buttons, Enemies);
                        attackingVillager.setCanAttack(false);
                        CurrentBlockClickFunction = "Attack";
                        G_attack_button.IsEnabled = true;
                    }
                }
            }
            //path if attacking unit is a watch tower
            else if (attackingVillager == null && attackingWatchtower != null)
            {
                if (attackingWatchtower.getXCoordinate() == block.getXCoordinate() && attackingWatchtower.getYCoordinate() == block.getYCoordinate())
                {
                    foreach (Block available in availableSpots)
                    {
                        Block.updateBlockAppearance(available, available.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);
                    }
                    CurrentBlockClickFunction = "Attack";
                    G_attack_button.IsEnabled = true;
                }
                else
                {
                    Block attackTarget = null;
                    foreach (Block attackable in attackableBlocks)
                    {
                        if (attackable.getXCoordinate() == block.getXCoordinate() && attackable.getYCoordinate() == block.getYCoordinate())
                        {
                            attackTarget = attackable;
                            break;
                        }
                    }

                    if (attackTarget != null && attackTarget.getOwner() != Player.getName())
                    {
                        foreach (Block available in availableSpots)
                        {
                            Block.updateBlockAppearance(available, available.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);
                        }
                        WatchTower.attackEnemy(attackingWatchtower, attackTarget, Villagers, OccupiedCities, WatchTowers, Player, Blocks, Buttons, Enemies);
                        attackingWatchtower.setCanAttack(false);
                        CurrentBlockClickFunction = "Attack";
                        G_attack_button.IsEnabled = true;
                    }
                }
            }
            updateKD();
            checkWin();
        }

        /// <summary>
        /// allow player to view information about a city or unit
        /// </summary>
        /// <param name="block"></param>
        private void inspectBlock(Block block)
        {
            foreach (Block space in Blocks)
            {
                if (space.getXCoordinate() == block.getXCoordinate() && space.getYCoordinate() == block.getYCoordinate())
                {
                    if (space.getTerrain() == "City")
                    {
                        City.displayCity(space, OccupiedCities);
                        break;
                    } 
                    else if (space.getTerrain() == "Grassland")
                    {
                        foreach (Villager vil in Villagers)
                        {
                            if(vil.getXCoordinate() == space.getXCoordinate() && vil.getYCoordinate() == space.getYCoordinate())
                            {
                                Villager.displayVillager(vil, Villagers);
                                break;
                            }
                            
                        }
                        foreach (WatchTower tower in WatchTowers)
                        {
                            if(tower.getXCoordinate() == space.getXCoordinate() && tower.getYCoordinate() == space.getYCoordinate())
                            {
                                WatchTower.displayWatchTower(tower, WatchTowers);
                                break;
                            }
                            
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// update screen with values of kills and deaths from the player class
        /// </summary>
        public void updateKD()
        {
            G_death_count_label.Content = Player.getTotalDeaths().ToString();
            G_kill_count_label.Content = Player.getTotalKills().ToString();
        }

        /// <summary>
        /// check if the player or enemy has won
        /// </summary>
        public void checkWin()
        {
            int playerCities = 0;
            int enemyCities = 0;

            foreach (City city in OccupiedCities)
            {
                if (city.getOwner() == Player.getName())
                {
                    playerCities++;
                } else
                {
                    enemyCities++;
                }
            }

            String msg = "The war is over now!";
            msg += "\nTotal kills: " + Player.getTotalKills();
            msg += "\nTotal Deaths: " + Player.getTotalDeaths();

            if (enemyCities == 0)
            {
                Player.setTotalVictories(Player.getTotalVictories() + 1);
                MessageBox.Show(msg, "VICTORY", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            } 
            if (playerCities == 0)
            {
                Player.setTotalDefeats(Player.getTotalDefeats() + 1);
                MessageBox.Show(msg, "Defeat", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
        }

        /// <summary>
        /// allow enemy to move and attack 
        /// </summary>
        private void EnemyAIturn()
        {
            Random random = new Random();

            foreach (Enemy enemy in Enemies)
            {
                if (enemy != null)
                {
                    //allow enemy to move all of their villagers and claim cities if they can
                    foreach (Villager enemyVillager in Villagers)
                    {
                        if (enemy.getName() == enemyVillager.getOwner())
                        {
                            List<Block> availableSpots = GetAvailableSpotsForEnemy(enemyVillager);

                            if (availableSpots.Count > 0)
                            {
                                // Randomly select one of the available spots
                                Block targetBlock = availableSpots[random.Next(availableSpots.Count)];

                                MoveEnemyVillager(enemyVillager, targetBlock); 

                                Villager.ClaimCity(targetBlock, OccupiedCities, nonOccupiedCities, Blocks, Buttons, Enemies, Player);
                            }
                        }
                    }
                    enemyAttack(); // allow enemy to attack

                }
            }
        }

        /// <summary>
        /// returns spots that the enemy can move their units to.
        /// </summary>
        /// <param name="enemyVillager">enemy that wants to be moved</param>
        /// <returns></returns>
        private List<Block> GetAvailableSpotsForEnemy(Villager enemyVillager)
        {
            List<Block> availableSpots = new List<Block>();
            int unitX = enemyVillager.getXCoordinate();
            int unitY = enemyVillager.getYCoordinate();

            for (int x = -1 * enemyVillager.getTravelRange(); x <= enemyVillager.getTravelRange(); x++)
            {
                for (int y = -1 * enemyVillager.getTravelRange(); y <= enemyVillager.getTravelRange(); y++)
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
                        if (surroundingBlock.getIsWalkable() && !surroundingBlock.getHabitated())
                        {
                            availableSpots.Add(surroundingBlock);
                        }
                    }
                }
            }

            return availableSpots;
        }

        /// <summary>
        /// confirm the move of a enemy unit from 1 place to another
        /// </summary>
        /// <param name="enemyVillager">moving unit</param>
        /// <param name="targetBlock">target block</param>
        private void MoveEnemyVillager(Villager enemyVillager, Block targetBlock)
        {

            Block block = Block.findBlock(enemyVillager.getXCoordinate(), enemyVillager.getYCoordinate(), Blocks);
            Block.updateBlockAppearance(block, block.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);

            // Update the enemy villager's coordinates
            enemyVillager.setXCoordinate(targetBlock.getXCoordinate());
            enemyVillager.setYCoordinate(targetBlock.getYCoordinate());

            Block.updateBlockAppearance(targetBlock, enemyVillager.getOwner(), "Unit_Villager", Buttons, Blocks, Enemies, Player);
        }

        /// <summary>
        /// allow enemy to attack nearby cities or player units
        /// </summary>
        public void enemyAttack()
        {
            List<Villager> villagersToRemove = new List<Villager>();  
            List<Villager> enemyVillagersToRemove = new List<Villager>();  

            foreach (Enemy enemy in Enemies)
            {
                foreach (Villager enemyVillager in Villagers.ToList()) 
                {
                    if (enemy.getName() == enemyVillager.getOwner())
                    {
                        List<Block> adjacentBlocks = GetAdjacentBlocks(enemyVillager);

                        Boolean hasAttacked = false;

                        foreach (Block targetBlock in adjacentBlocks)
                        {
                            if (hasAttacked)
                            {
                                break; // Exit if the unit has already attacked
                            }
                            // If the block is owned by the player, perform an attack
                            if (targetBlock.getOwner() == Player.getName())
                            {
                                attackPlayer(enemyVillager, targetBlock, Villagers, OccupiedCities, WatchTowers, Player, Blocks, Buttons, Enemies);

                                // If the enemy or player die, add them to list to remove later
                                if (enemyVillager.getHealth() <= 0)
                                {
                                    enemyVillagersToRemove.Add(enemyVillager);
                                }

                                Villager targetVillager = Villager.findVillagerInBlocks(targetBlock, Villagers);
                                if (targetVillager != null && targetVillager.getHealth() <= 0)
                                {
                                    villagersToRemove.Add(targetVillager);
                                }

                                hasAttacked = true;
                                updateKD();
                                checkWin();
                                break; 
                            }
                        }
                        if (hasAttacked) break;
                    }
                }
            }

            // Remove all villagers that died
            foreach (Villager vilToRemove in villagersToRemove)
            {
                Villagers.Remove(vilToRemove);
            }

            foreach (Villager enemyVilToRemove in enemyVillagersToRemove)
            {
                Villagers.Remove(enemyVilToRemove);
            }
        }

        /// <summary>
        /// logic to attack player units and cities
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="targetBlock"></param>
        /// <param name="villagers"></param>
        /// <param name="cities"></param>
        /// <param name="watchtowers"></param>
        /// <param name="player"></param>
        /// <param name="blocks"></param>
        /// <param name="buttons"></param>
        /// <param name="enemies"></param>
        public static void attackPlayer(Villager attacker, Block targetBlock, List<Villager> villagers, List<City> cities, List<WatchTower> watchtowers, Player player, Block[] blocks, Button[] buttons, Enemy[] enemies)
        {
            Villager vilToRemove = null;

            // find the villager that will be attacked
            foreach (Villager playerVillager in villagers)
            {
                if (Villager.findVillagerInBlocks(targetBlock, villagers) != null && targetBlock.getXCoordinate() == playerVillager.getXCoordinate() && targetBlock.getYCoordinate() == playerVillager.getYCoordinate())
                {
                    int damageToPlayer = attacker.getAttackDamage();
                    int damageToSelf = playerVillager.getAttackDamage() / 4;

                    // change the health of both units
                    playerVillager.setHealth(playerVillager.getHealth() - damageToPlayer);
                    attacker.setHealth(attacker.getHealth() - damageToSelf);
                    player.setTotalKills(player.getTotalKills() + damageToSelf); 
                    player.setTotalDeaths(player.getTotalDeaths() + damageToPlayer); 

                    // Show battle results
                    String msg = "Damage taken: " + damageToPlayer;
                    msg += "\nRemaining soldiers: " + playerVillager.getHealth();
                    msg += "\n\nDamage dealt: " + damageToSelf;
                    msg += "\nRemaining enemy soldiers: " + attacker.getHealth();
                    MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Remove dead units
                    if (playerVillager.getHealth() <= 0)
                    {
                        Block enemyBlock = Block.findBlock(playerVillager.getXCoordinate(), playerVillager.getYCoordinate(), blocks);
                        Block.updateBlockAppearance(enemyBlock, attacker.getOwner(), "Grassland", buttons, blocks, enemies, player);
                        vilToRemove = playerVillager;
                    }

                    if (attacker.getHealth() <= 0)
                    {
                        Block attackerBlock = Block.findBlock(attacker.getXCoordinate(), attacker.getYCoordinate(), blocks);
                        Block.updateBlockAppearance(attackerBlock, playerVillager.getOwner(), "Grassland", buttons, blocks, enemies, player);
                        vilToRemove = attacker; 
                    }
                    break;
                }
            }
            villagers.Remove(vilToRemove);
            vilToRemove = null;

            foreach (City targetCity in cities)
            {
                if (Villager.findVillagerInBlocks(targetBlock, villagers) == null && targetBlock.getXCoordinate() == targetCity.getXCoordinate() && targetBlock.getYCoordinate() == targetCity.getYCoordinate())
                {
                    int damageToPlayer = attacker.getAttackDamage();
                    int damageToSelf = targetCity.getAttackDamage() / 2;

                    // change health of both units
                    targetCity.setHealth(targetCity.getHealth() - damageToPlayer);
                    attacker.setHealth(attacker.getHealth() - damageToSelf);
                    player.setTotalKills(player.getTotalKills() + damageToPlayer);
                    player.setTotalDeaths(player.getTotalDeaths() + damageToSelf);

                    // Show battle results
                    String msg = "Damage taken: " + damageToPlayer;
                    msg += "\nRemaining soldiers: " + targetCity.getHealth();
                    msg += "\n\nDamage dealt: " + damageToSelf;
                    msg += "\nRemaining city soldiers: " + attacker.getHealth();
                    MessageBox.Show(msg, "Battle results", MessageBoxButton.OK, MessageBoxImage.Information);

                    // remove dead unis
                    if (targetCity.getHealth() <= 0)
                    {
                        targetCity.setHealth(800); 
                        targetCity.setOwner(attacker.getOwner()); 
                        Block cityBlock = Block.findBlock(targetCity.getXCoordinate(), targetCity.getYCoordinate(), blocks);
                        Block.updateBlockAppearance(cityBlock, targetCity.getOwner(), "City", buttons, blocks, enemies, player);
                    }

                    if (attacker.getHealth() <= 0)
                    {
                        Block attackerBlock = Block.findBlock(attacker.getXCoordinate(), attacker.getYCoordinate(), blocks);
                        Block.updateBlockAppearance(attackerBlock, targetCity.getOwner(), "Grassland", buttons, blocks, enemies, player);
                        vilToRemove = attacker; 
                    }
                    break;
                }
            }
        }

    }
}
