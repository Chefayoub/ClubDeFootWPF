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
    /// Logique d'interaction pour Match.xaml
    /// </summary>
    public partial class Match : Window
    {
        private ViewModel.VM_Match LocalMatch;
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public Match()
        {
            InitializeComponent();

            LocalMatch = new ViewModel.VM_Match();
            DataContext = LocalMatch;

            //Generer un document qui donne : le programme de la semaine à venir, pour toutes les équipes
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Fiche de Match")));
            p.Inlines.Add(new LineBreak());
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


            //Generer un document qui donne : les résultats de la semaine écoulée, pour toutes les équipes
            FlowDocument fd2 = new FlowDocument();
            Paragraph p1 = new Paragraph();
            p1.Inlines.Add(new Bold(new Run("Fiche de Match")));
            p1.Inlines.Add(new LineBreak());
            p1.Inlines.Add(new LineBreak());
            p1.Inlines.Add(new Run("Match"));
            p1.Inlines.Add(new LineBreak());

            List<C_T_Match> match2 = new G_T_Match(chConnexion).Lire("DateM");
            foreach (C_T_Match m in match2)
            {
                //if ((m.DateM - DateTime.Now).TotalDays <= 7 && (m.DateM - DateTime.Now).TotalDays >= 0)
                if (m.DateM < DateTime.Now && m.DateM > DateTime.Now.AddDays(-7))
                {
                    p1.Inlines.Add(new LineBreak());
                    p1.Inlines.Add("ID Match : " + m.ID_Match.ToString());
                    p1.Inlines.Add(new LineBreak());
                    p1.Inlines.Add("ID Domicile : " + m.ID_Domicile.ToString());
                    p1.Inlines.Add("  ID Deplacement : " + m.ID_Domicile.ToString());
                    p1.Inlines.Add(new LineBreak());
                    p1.Inlines.Add("Score Domicile : " + m.Score_Domicile.Value.ToString());
                    p1.Inlines.Add("  Score Deplacement : " + m.Score_Adversaire.Value.ToString());
                    p1.Inlines.Add(new LineBreak());
                    p1.Inlines.Add("Date et heure : " + m.DateM.ToString());
                    p1.Inlines.Add(new LineBreak());
                    p1.Inlines.Add("Terrain : " + m.ID_Terrain.ToString());
                    p1.Inlines.Add(new LineBreak());
                }
            }

            fd2.Blocks.Add(p1);
            rtbDoc.Document = fd2;
            FileStream fs1 = new FileStream(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\MatchPasser.doc", FileMode.Create);
            TextRange tr1 = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr1.Save(fs1, System.Windows.DataFormats.Rtf);
        }

        private void dgMatchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMatch.SelectedIndex >= 0) LocalMatch.MatchSelectionnee2UneMatch();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConnexion).Lire("ID_Equipe");
            foreach (C_T_Equipe cp in lTmp)
            {
                cbIDDomicile.Items.Add(cp.ID_Equipe);
            }

            List<C_T_Equipe> lTmp2 = new G_T_Equipe(chConnexion).Lire("ID_Equipe");
            foreach (C_T_Equipe cp in lTmp2)
            {
                cbIDDeplacement.Items.Add(cp.ID_Equipe);
            }

            List<C_T_Terrain> lTmp3 = new G_T_Terrain(chConnexion).Lire("ID_Terrain");
            foreach (C_T_Terrain cp in lTmp3)
            {
                cbIDTerrain.Items.Add(cp.ID_Terrain);
            }
        }
    }
}
