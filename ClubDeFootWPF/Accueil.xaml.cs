using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
using Projet_BD_ClubDeSportWPF.Gestion;


namespace ClubDeFootWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        private ViewModel.VM_Accueil LocalAccueil;
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public BaseCommande remplirTableEntrainement { get; set; }
        

        public Accueil()
        {
            InitializeComponent();
            LocalAccueil = new ViewModel.VM_Accueil();
            DataContext = LocalAccueil;
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

        // Le programme de la semaine, pour une équipe déterminée, pourra être envoyé par mail à chacun de ses membres disposant d'une adresse email
        private void bGenererFichierID_Click(object sender, RoutedEventArgs e)
        {
            //Generer un document qui donne : Le programme de la semaine
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Programme de la semaine")));
            p.Inlines.Add(new LineBreak());
            //p.Inlines.Add(new Run("Entrainement"));
            p.Inlines.Add(new LineBreak());

            if (tbGenererFichierID.Text == "")
            {
                MessageBox.Show("Veuillez remplir le texte box avec l'id souhaiter !");
            }
            else
            {
                List<C_T_Match> match = new G_T_Match(chConnexion).Lire("ID_Match");
                p.Inlines.Add(new Bold(new Run("ID equipe en question : " + tbGenererFichierID.Text)));
                p.Inlines.Add(new LineBreak());
                foreach (C_T_Match m in match)
                {
                    if (m.ID_Deplacement == Int32.Parse(tbGenererFichierID.Text) || m.ID_Domicile == Int32.Parse(tbGenererFichierID.Text))
                    {
                        tbGenererFichierID.Text.ToString();
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new Bold(new Run("MATCH")));
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Match : " + m.ID_Match.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Domicile : " + m.ID_Domicile.ToString());
                        p.Inlines.Add("  ID Deplacement : " + m.ID_Deplacement.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Terrain : " + m.ID_Terrain.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Date et heure : " + m.DateM.ToString());
                        p.Inlines.Add(new LineBreak());
                    }

                }
                List<C_T_Entrainement> entrainement = new G_T_Entrainement(chConnexion).Lire("ID_Entrainement");
                foreach (C_T_Entrainement ent in entrainement)
                {

                    if (ent.ID_Equipe == Int32.Parse(tbGenererFichierID.Text))
                    {
                        tbGenererFichierID.Text.ToString();
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new Bold(new Run("ENTRAINEMENT")));
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Entrainement : " + ent.ID_Entrainement.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Equipe : " + ent.ID_Equipe.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("ID Terrain : " + ent.ID_Terrain.ToString());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Date et heure : " + ent.DateE.ToString());

                        p.Inlines.Add(new LineBreak());
                    }
                }
                fd.Blocks.Add(p);
                rtbDoc.Document = fd;
                FileStream fs = new FileStream(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\ProgrammePersonnel.doc", FileMode.Create);
                TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
                tr.Save(fs, System.Windows.DataFormats.Rtf);
                MessageBox.Show("Le fichier Entrainement.doc a bien été créer !");
            }
        }

        //Envoyer le fichier de programme de la semaine a des memebres qui appartiennent a une certaines equipe
        private void bGenererFichierIDEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            List<C_T_Membre> membre = new G_T_Membre(chConnexion).Lire("ID_Membre");
            foreach (C_T_Membre m in membre)
            {
                if (m.ID_Equipe == Int32.Parse(tbGenererFichierID_Copy.Text))
                {
                    SmtpClient mailServer = new SmtpClient("smtp.office365.com", 587);
                    mailServer.EnableSsl = true;

                    mailServer.Credentials = new System.Net.NetworkCredential("ayoub.allachi@student.hel.be", "Maroco4020");

                    string from = "ayoub.allachi@student.hel.be";
                    MailMessage msg = new MailMessage(from, m.Email);
                    msg.Subject = "Programme de la semaine";
                    msg.Body = "Bonjour, Voici votre programme de la semaine. Cordialement";

                    //if (cbProgramme.IsChecked == true)
                    //{
                    //    msg.Attachments.Add(new Attachment(""));
                    //}
                    msg.Attachments.Add(new Attachment(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\ProgrammePersonnel.doc"));
                    mailServer.Send(msg);
                }
            }
            MessageBox.Show("Message envoyé avec succès", "Envoyé", MessageBoxButton.OK);
        }





        //Pour le refresh
        private ObservableCollection<C_T_Equipe> _BcpEquipes = new ObservableCollection<C_T_Equipe>();
        public ObservableCollection<C_T_Equipe> BcpEquipes
        {
            get { return _BcpEquipes; }
            set { _BcpEquipes = value; }
        }

        private ObservableCollection<C_T_Equipe> ChargerEquipes(string chConn)
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConn).Lire("ID_Equipe");
            foreach (C_T_Equipe Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LocalAccueil.Refresh();
        }
    }
}
