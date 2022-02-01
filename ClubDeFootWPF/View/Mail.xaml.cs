using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Projet_BD_ClubDeSportWPF.Classes;
using Projet_BD_ClubDeSportWPF.Gestion;


namespace ClubDeFootWPF.View
{
    //info http://www.mukeshkumar.net/articles/wpf/send-an-email-in-csharp-with-wpf-application
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    /// 
    public partial class Mail : Window
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public Mail()
        {
            InitializeComponent();

        }

        //Envoier un message a tous les membres
        private void bEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;

            if (tbDestinataire.Text.Trim().Length == 0)
            {
                flag = 0;
                MessageBox.Show("Veuillez indiquer au moins un destinataire ! ");
                tbDestinataire.Focus();
            }
            else if (!Regex.IsMatch(tbDestinataire.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
            {
                flag = 0;
                MessageBox.Show("Le mail entré est invalide ! ");
                tbDestinataire.Focus();
            }
            else
            {
                flag = 1;
            }
            if (tbSujet.Text.Trim().Length == 0)
            {
                flag = 0;
                MessageBox.Show("Le champ sujet est vide ! ");
                tbSujet.Focus();
            }
            if (tbContenu.Text.Trim().Length == 0)
            {
                flag = 0;
                MessageBox.Show("Le champ contenu est vide ! ");
                tbContenu.Focus();
            }
            if (flag == 1)
            {
                //Informations relative au mail avec le quel on envoie
                try
                {
                    SmtpClient mailServer = new SmtpClient("smtp.office365.com", 587);
                    mailServer.EnableSsl = true;

                    mailServer.Credentials = new System.Net.NetworkCredential("mail", "password");

                    string from = "mail";
                    MailMessage msg = new MailMessage(from, tbDestinataire.Text);
                    msg.Subject = tbSujet.Text;
                    msg.Body = tbContenu.Text;

                    if (cbProgramme.IsChecked == true)
                    {
                        msg.Attachments.Add(new Attachment(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\ProgrammePersonnel.doc"));
                    }
                    //msg.Attachments.Add(new Attachment("D:\\BD_ClubDeSportWPF\\DocAppWPF\\Football.doc"));
                    mailServer.Send(msg);
                    MessageBox.Show("Message envoyé avec succès", "Envoyé", MessageBoxButton.OK);
                    tbDestinataire.Text = "";
                    tbSujet.Text = "";
                    tbContenu.Text = "";
                    tbDestinataire.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible d'envoyer le mail ! " + ex, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void bEnvoyer_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<C_T_Membre> membre = new G_T_Membre(chConnexion).Lire("ID_Membre");
            foreach (C_T_Membre m in membre)
            {
                SmtpClient mailServer = new SmtpClient("smtp.office365.com", 587);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential("mail", "password");

                string from = "mail";
                MailMessage msg = new MailMessage(from, m.Email);
                msg.Subject = tbSujet.Text;
                msg.Body = tbContenu.Text;

                if (cbProgramme.IsChecked == true)
                {
                    msg.Attachments.Add(new Attachment(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\MatchAVenir.HTML"));
                }
                //msg.Attachments.Add(new Attachment("D:\\BD_ClubDeSportWPF\\DocAppWPF\\Football.doc"));
                mailServer.Send(msg);

                tbDestinataire.Text = "";
                tbSujet.Text = "";
                tbContenu.Text = "";
                tbDestinataire.Focus();
            }
            MessageBox.Show("Message envoyé avec succès", "Envoyé", MessageBoxButton.OK);
        }
    }
}

