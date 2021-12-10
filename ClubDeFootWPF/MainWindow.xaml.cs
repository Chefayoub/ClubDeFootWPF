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

namespace ClubDeFootWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnMembre_Click(object sender, RoutedEventArgs e)
        {
            View.Membre f = new View.Membre();
            f.ShowDialog();
        }

        private void btnClub_Click(object sender, RoutedEventArgs e)
        {
            View.Club f = new View.Club();
            f.ShowDialog();
        }

        private void btnEquipe_Click(object sender, RoutedEventArgs e)
        {
            View.Equipe f = new View.Equipe();
            f.ShowDialog();
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            View.Match f = new View.Match();
            f.ShowDialog();
        }

        private void btnEntrainement_Click(object sender, RoutedEventArgs e)
        {
            View.Entrainement f = new View.Entrainement();
            f.ShowDialog();
        }

        private void btnTerrain_Click(object sender, RoutedEventArgs e)
        {
            View.Terrain f = new View.Terrain();
            f.ShowDialog();
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
