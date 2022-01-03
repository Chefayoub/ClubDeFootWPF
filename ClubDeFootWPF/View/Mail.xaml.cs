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

namespace ClubDeFootWPF.View
{
    //info http://www.mukeshkumar.net/articles/wpf/send-an-email-in-csharp-with-wpf-application
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    /// 
    public partial class Mail : Window
    {
        public Mail()
        {
            InitializeComponent();
        }

        //Conditions pour un bon envoie
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

                    mailServer.Credentials = new System.Net.NetworkCredential("ayoub.allachi@student.hel.be", "Maroco4020");

                    string from = "ayoub.allachi@student.hel.be";
                    MailMessage msg = new MailMessage(from, tbDestinataire.Text);
                    msg.Subject = tbSujet.Text;
                    msg.Body = tbContenu.Text;

                    if (cbProgramme.IsChecked == true)
                    {
                        msg.Attachments.Add(new Attachment("D:\\BD_ClubDeSportWPF\\DocAppWPF\\Football.doc"));
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
    }
}

