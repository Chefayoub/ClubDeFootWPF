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
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using Projet_BD_ClubDeSportWPF.Classes;
using System.Configuration;
using Projet_BD_ClubDeSportWPF.Gestion;

namespace ClubDeFootWPF.View
{
    /// <summary>
    /// Logique d'interaction pour Membre.xaml
    /// </summary>
    public partial class Membre : Window
    {
        private ViewModel.VM_Membre LocalMembre;
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public Membre()
        {
            InitializeComponent();

            LocalMembre = new ViewModel.VM_Membre();
            DataContext = LocalMembre;

            //Generer un document qui donne : •	le relevé, par équipe, des membres, (Pour chaque membres dire dans quel équipe il est)
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Composition de chaque equipe")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Membres"));
            p.Inlines.Add(new LineBreak());

            List<C_T_Membre> entrainement = new G_T_Membre(chConnexion).Lire("ID_Equipe");
            foreach (C_T_Membre m in entrainement)
            {
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Equipe : " + m.ID_Equipe.ToString());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Nom : " + m.Nom);
                p.Inlines.Add("  Prénom : " + m.Prenom);
                p.Inlines.Add(new LineBreak());

            }
            fd.Blocks.Add(p);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\Membres.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dgMembres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMembre.SelectedIndex >= 0) LocalMembre.MembreSelectionnee2UneMembre();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConnexion).Lire("ID_Equipe");
            foreach (C_T_Equipe cp in lTmp)
            {
                cbEquipe.Items.Add(cp.ID_Equipe);
            }
        }
    }
}
