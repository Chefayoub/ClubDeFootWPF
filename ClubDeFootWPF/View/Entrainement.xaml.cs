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

        //Generer un document qui donne : L'horaire d'entraînement d'une équipe déterminée
        private void bGenererFichierID_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Horaire d'entrainement")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Entrainement"));
            p.Inlines.Add(new LineBreak());

            if (tbGenererFichierID.Text == "")
            {
                MessageBox.Show("Veuillez remplir le texte box avec l'id souhaiter !");
            }
            else
            {
                List<C_T_Entrainement> entrainement = new G_T_Entrainement(chConnexion).Lire("ID_Entrainement");
                foreach (C_T_Entrainement m in entrainement)
                {

                    if (m.ID_Equipe == Int32.Parse(tbGenererFichierID.Text))
                    {
                        tbGenererFichierID.Text.ToString();
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Entrainement : " + m.ID_Entrainement.ToString());
                        p.Inlines.Add("  ID Equipe : " + m.ID_Equipe.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Terrain : " + m.ID_Terrain.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Date et heure : " + m.DateE.ToString());
                        p.Inlines.Add(new LineBreak());
                    }
                }
                fd.Blocks.Add(p);
                rtbDoc.Document = fd;
                FileStream fs = new FileStream(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\Entrainement.doc", FileMode.Create);
                TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
                tr.Save(fs, System.Windows.DataFormats.Rtf);
                MessageBox.Show("Le fichier Entrainement.doc a bien été créer !");
            }
        }
    }
}
