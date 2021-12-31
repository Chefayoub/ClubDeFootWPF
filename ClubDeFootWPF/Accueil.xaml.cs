using System;
using System.Collections.Generic;
using System.IO;
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
using Projet_BD_ClubDeSportWPF.Classes;

namespace ClubDeFootWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        private ViewModel.VM_Accueil LocalEquipe;
        private ViewModel.VM_Accueil LocalMembre;
        private ViewModel.VM_Terrain LocalTerrain;
        private ViewModel.VM_Match LocalMatch;
        private ViewModel.VM_Entrainement LocalEntrainement;

        public Accueil()
        {
            InitializeComponent();

            //Table equipe
            LocalEquipe = new ViewModel.VM_Accueil();
            DataContext = LocalEquipe;
            //Table Entrainement
            LocalEntrainement = new ViewModel.VM_Entrainement();
            DataContext = LocalEntrainement;
            //Table Match
            LocalMatch = new ViewModel.VM_Match();
            DataContext = LocalMatch;
            //Table Terrain
            LocalTerrain = new ViewModel.VM_Terrain();
            DataContext = LocalTerrain;
            //Table Membre
            LocalMembre = new ViewModel.VM_Accueil();
            DataContext = LocalMembre;

            //Generer un document
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Fiche de Match")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Match"));
            fd.Blocks.Add(p);

            List lEquipe = new List();
            foreach (C_T_Equipe cp in LocalEquipe.BcpEquipes)
            {
                Paragraph pl = new Paragraph(new Run(cp.Nom));
                lEquipe.ListItems.Add(new ListItem(pl));
            }

            List lMembre = new List();
            foreach (C_T_Membre cp in LocalMembre.BcpMembres)
            {
                Paragraph pl = new Paragraph(new Run(cp.Nom + " " + cp.Prenom + " - " + cp.Email));
                lMembre.ListItems.Add(new ListItem(pl));
            }

            List lMatch = new List();
            foreach (C_T_Match cp in LocalMatch.BcpMatchs)
            {
                Paragraph pl = new Paragraph(new Run("Equipe domicile : " + cp.ID_Domicile + " - Equipe deplacement : " + cp.ID_Deplacement + " - Terrain : " + cp.ID_Terrain + " - Score domicile : " + cp.Score_Domicile + " - Score adversaire : " + cp.Score_Adversaire + " - Date et heure du match : " + cp.DateM));
                lMatch.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(lEquipe);
            fd.Blocks.Add(lMembre);
            fd.Blocks.Add(lMatch);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\BD_ClubDeSportWPF\DocAppWPF\Football.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void btnMembre_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
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
        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            View.Entrainement f = new View.Entrainement();
            f.ShowDialog();
        }


        //DGV equipe
        private void dgEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEquipe.SelectedIndex >= 0) LocalEquipe.EquipeSelectionnee2UneEquipe();
        }

        //DGV Membre
        private void dgMembres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMembre.SelectedIndex >= 0) LocalMembre.MembreSelectionnee2UneMembre();
        }

        //DGV Terrain
        private void dgTerrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTerrain.SelectedIndex >= 0) LocalTerrain.TerrainSelectionnee2UneTerrain();
        }

        //DGV Match
        private void dgMatchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMatch.SelectedIndex >= 0) LocalMatch.MatchSelectionnee2UneMatch();
        }

        //DGV Rntrainement
        private void dgEntrainements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEntrainement.SelectedIndex >= 0) LocalEntrainement.EntrainementSelectionnee2UneEntrainement();
        }


    }


}
