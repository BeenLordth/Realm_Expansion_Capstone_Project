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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Realm_Expansion_Capstone_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// shut down the whole game when the player clicks on quit
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MM_quit_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// lead the player to the settings screen when clicked on play
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MM_play_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Settings window = new Settings();
            window.ShowDialog();
            this.Show();
        }
    }
}
