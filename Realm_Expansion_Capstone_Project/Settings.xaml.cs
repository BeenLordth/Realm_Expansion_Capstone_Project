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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void S_quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void S_play_Click(object sender, RoutedEventArgs e)
        {
            String input = S_name_txtbx.Text.ToString();
            if (isValidName(input))
            {
                this.Close();
                Game game = new Game(input, getEnemyCount(), getSelectedDifficulty());
                game.ShowDialog();
            }
        }

        private Boolean isValidName(String input)
        {
            char[] inputChars = new char[input.Length];

            for(int i = 0; i < inputChars.Length; i++)
            {
                inputChars[i] = input[i];
            }

            if(input.Length < 1)
            {
                S_warning_label.Visibility = Visibility.Visible;
                S_warning_label.Content = "Name is too short";
                return false;
            } else if(input.Length > 15)
            {
                S_warning_label.Visibility = Visibility.Visible;
                S_warning_label.Content = "Name is too long";
                return false;
            }

            foreach (char i in inputChars)
            {
                if (!char.IsLetter(i))
                {
                    S_warning_label.Visibility = Visibility.Visible;
                    S_warning_label.Content = "Letters only";
                    return false;
                }
            }

            return true;
        }

        private int getEnemyCount()
        {
            if (S_enemies_one_btn.IsChecked == true)
            {
                return 1;
            }
            else if (S_enemies_two_btn.IsChecked == true)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private String getSelectedDifficulty()
        {
            if (S_difficulty_easy_btn.IsChecked == true)
            {
                return "Easy";
            } else
            {
                return "Hard";
            }
        }
    }
}
