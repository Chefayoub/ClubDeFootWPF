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
using Projet_BD_ClubDeSportWPF.Gestion;
using System.Configuration;

namespace ClubDeFootWPF.View
{
    /// <summary>
    /// Logique d'interaction pour Equipe.xaml
    /// </summary>
    public partial class Equipe : Window
    {
        private ViewModel.VM_Equipe LocalEquipe;
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;

        public Equipe()
        {
            InitializeComponent();

            LocalEquipe = new ViewModel.VM_Equipe();
            DataContext = LocalEquipe;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_T_Equipe cp in LocalEquipe.BcpEquipes)
            {
                Paragraph pl = new Paragraph(new Run(cp.ID_Equipe + " " + cp.Nom));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            //rtbDoc.Document = fd;
            //FileStream fs = new FileStream(@"D:\BD_ClubDeSportWPF\DocAppWPF\Equipe.doc", FileMode.Create);
            //TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            //tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dgEquipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEquipe.SelectedIndex >= 0) LocalEquipe.EquipeSelectionnee2UneEquipe();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_T_Club> lTmp = new G_T_Club(chConnexion).Lire("ID_Club");
            foreach (C_T_Club cp in lTmp)
            {
                cbClub.Items.Add(cp.ID_Club);
            }
        }
    }
}
