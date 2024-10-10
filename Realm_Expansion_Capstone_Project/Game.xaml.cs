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
        private Button[] Buttons = new Button[900];
        private Block[] Blocks = new Block[900];
        private List<City> nonOccupiedCities = new List<City>();
        private List<City> OccupiedCities = new List<City>();
        private Enemy[] Enemies = new Enemy[3];
        private Player Player = new Player();

        private List<Villager> Villagers = new List<Villager>();
        private List<WatchTower> WatchTowers = new List<WatchTower>();

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

            for (int i = 0; i < Blocks.Length; i++)
            {
                Button button = new Button();
                button.Width = 30;
                button.Height = 30;
                button.BorderThickness = new Thickness(0);
                Image terrainImg = new Image();
                Block block;

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

            foreach(Villager vil in Villagers)
            {
                if(vil.getOwner() == Player.getName())
                {
                    vil.setCanMove(true);
                    vil.setCanAttack(true);
                }
            }

            Random random = new Random();

            foreach (Enemy enemy in Enemies)
            {
                if(enemy != null)
                {
                    enemy.setCoins(enemy.getCoins() + Realm.calculateGoldIncome(enemy.getName(), Blocks));

                    foreach (City city in OccupiedCities)
                    {
                        if (city.getOwner() == enemy.getName())
                        {

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

            EnemyAIturn();
        }

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

        List<Block> availableSpots = new List<Block>();
        Villager movingVillager = null;
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

        List<Block> attackableBlocks = new List<Block>();
        Villager attackingVillager = null;
        WatchTower attackingWatchtower = null;
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

        private void selectAttackTarget(Block block)
        {
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

        public void updateKD()
        {
            G_death_count_label.Content = Player.getTotalDeaths().ToString();
            G_kill_count_label.Content = Player.getTotalKills().ToString();
        }

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
            msg += "\nActive Armies: " + Player.getTotalVillagers();

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

        private void EnemyAIturn()
        {
            Random random = new Random();

            foreach (Enemy enemy in Enemies)
            {
                if (enemy != null)
                {
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
                }
            }
        }

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

        private void MoveEnemyVillager(Villager enemyVillager, Block targetBlock)
        {

            Block block = Block.findBlock(enemyVillager.getXCoordinate(), enemyVillager.getYCoordinate(), Blocks);
            Block.updateBlockAppearance(block, block.getOwner(), "Grassland", Buttons, Blocks, Enemies, Player);

            // Update the enemy villager's coordinates
            enemyVillager.setXCoordinate(targetBlock.getXCoordinate());
            enemyVillager.setYCoordinate(targetBlock.getYCoordinate());

            Block.updateBlockAppearance(targetBlock, enemyVillager.getOwner(), "Unit_Villager", Buttons, Blocks, Enemies, Player);
        }

    }
}
