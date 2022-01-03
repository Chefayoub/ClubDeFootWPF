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
        private ViewModel.VM_Accueil LocalAccueil;


        public Accueil()
        {
            InitializeComponent();

            //Table Membre
            LocalAccueil = new ViewModel.VM_Accueil();
            DataContext = LocalAccueil;

            //Generer un document
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Fiche de Match")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Match"));
            p.Inlines.Add(new LineBreak());

            foreach (C_T_Equipe cp in LocalAccueil.BcpEquipes)
            {
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Equipe : " + cp.Nom);
                p.Inlines.Add(new LineBreak());
            }

            foreach (C_T_Membre cp in LocalAccueil.BcpMembres)
            {
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Membre : " + cp.Nom + " " + cp.Prenom + " - " + cp.Email);
                p.Inlines.Add(new LineBreak());


                //foreach (C_T_Match cp2 in LocalAccueil.BcpMatchs)
                //{
                //    p.Inlines.Add(new LineBreak());
                //    p.Inlines.Add("Match : ");
                //    p.Inlines.Add(new LineBreak());
                //    p.Inlines.Add("Equipe domicile : " + cp2.ID_Domicile + " - Equipe deplacement : " + cp2.ID_Deplacement + " - Terrain : " + cp2.ID_Terrain + " - Score domicile : " + cp2.Score_Domicile + " - Score adversaire : " + cp2.Score_Adversaire + " - Date et heure du match : " + cp2.DateM);
                //    p.Inlines.Add(new LineBreak());
                //}
            }

            foreach (C_T_Match cp in LocalAccueil.BcpMatchs)
            {
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Match : ");
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Equipe domicile : " + cp.ID_Domicile + " - Equipe deplacement : " + cp.ID_Deplacement + " - Terrain : " + cp.ID_Terrain + " - Score domicile : " + cp.Score_Domicile + " - Score adversaire : " + cp.Score_Adversaire + " - Date et heure du match : " + cp.DateM);
                p.Inlines.Add(new LineBreak());
            }





            fd.Blocks.Add(p);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\BD_ClubDeSportWPF\DocAppWPF\Football.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void btnMembre_Click(object sender, RoutedEventArgs e)
        {
            View.Membre f = new View.Membre();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnClub_Click(object sender, RoutedEventArgs e)
        {
            View.Club f = new View.Club();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnEquipe_Click(object sender, RoutedEventArgs e)
        {
            View.Equipe f = new View.Equipe();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnMatch_Click(object sender, RoutedEventArgs e)
        {
            View.Match f = new View.Match();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnEntrainement_Click(object sender, RoutedEventArgs e)
        {
            View.Entrainement f = new View.Entrainement();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void btnTerrain_Click(object sender, RoutedEventArgs e)
        {
            View.Terrain f = new View.Terrain();
            Hide();
            f.ShowDialog();
            Show();
        }
        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            View.Mail f = new View.Mail();
            Hide();
            f.ShowDialog();
            Show();
        }
        private void btnHTML_Click(object sender, RoutedEventArgs e)
        {
            View.Html f = new View.Html();
            Hide();
            f.ShowDialog();
            Show();
        }


        //DGV equipe
        private void dgEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEquipe.SelectedIndex >= 0) LocalAccueil.EquipeSelectionnee2UneEquipe();
        }

        //DGV Membre
        private void dgMembres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMembre.SelectedIndex >= 0) LocalAccueil.MembreSelectionnee2UneMembre();
        }

        //DGV Terrain
        private void dgTerrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTerrain.SelectedIndex >= 0) LocalAccueil.TerrainSelectionnee2UneTerrain();
        }

        //DGV Match
        private void dgMatchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMatch.SelectedIndex >= 0) LocalAccueil.MatchSelectionnee2UneMatch();
        }

        //DGV Rntrainement
        private void dgEntrainements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEntrainement.SelectedIndex >= 0) LocalAccueil.EntrainementSelectionnee2UneEntrainement();
        }
    }


}
