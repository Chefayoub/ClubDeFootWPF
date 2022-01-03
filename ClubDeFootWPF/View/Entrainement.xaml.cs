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
    /// Logique d'interaction pour Entrainement.xaml
    /// </summary>
    public partial class Entrainement : Window
    {
        private ViewModel.VM_Entrainement LocalEntrainement;
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public Entrainement()
        {
            InitializeComponent();

            LocalEntrainement = new ViewModel.VM_Entrainement();
            DataContext = LocalEntrainement;
            //Generer un document qui vont ce jouer
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Fiche de Match")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Match"));
            p.Inlines.Add(new LineBreak());

            List<C_T_Match> match = new G_T_Match(chConnexion).Lire("DateM");
            foreach (C_T_Match m in match)
            {
                if (m.Score_Domicile == 0 && m.Score_Adversaire == 0)
                {
                    if ((m.DateM - DateTime.Now).TotalDays <= 7 && (m.DateM - DateTime.Now).TotalDays >= 0)
                    {
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Match : " + m.ID_Match.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Domicile : " + m.ID_Domicile.ToString());
                        p.Inlines.Add("  ID Deplacement : " + m.ID_Domicile.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Score Domicile : " + m.Score_Domicile.Value.ToString());
                        p.Inlines.Add("  Score Deplacement : " + m.Score_Domicile.Value.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Date et heure : " + m.DateM.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Terrain : " + m.ID_Terrain.ToString());
                        p.Inlines.Add(new LineBreak());
                    }
                }
            }
            fd.Blocks.Add(p);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\MatchAVenir.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dgEntrainements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEntrainement.SelectedIndex >= 0) LocalEntrainement.EntrainementSelectionnee2UneEntrainement();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_T_Terrain> lTmp = new G_T_Terrain(chConnexion).Lire("ID_Terrain");
            foreach (C_T_Terrain cp in lTmp)
            {
                cbIDTerrain.Items.Add(cp.ID_Terrain);
            }

            List<C_T_Equipe> lTmp2 = new G_T_Equipe(chConnexion).Lire("ID_Equipe");
            foreach (C_T_Equipe cp in lTmp2)
            {
                cbEquipe.Items.Add(cp.ID_Equipe);
            }
        }
    }
}
