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

namespace ClubDeFootWPF.View
{
    /// <summary>
    /// Logique d'interaction pour Entrainement.xaml
    /// </summary>
    public partial class Entrainement : Window
    {
        private ViewModel.VM_Entrainement LocalEntrainement;

        public Entrainement()
        {
            InitializeComponent();

            LocalEntrainement = new ViewModel.VM_Entrainement();
            DataContext = LocalEntrainement;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_T_Entrainement cp in LocalEntrainement.BcpEntrainements)
            {
                Paragraph pl = new Paragraph(new Run(cp.ID_Entrainement + " " + cp.DateE));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\BD_ClubDeSportWPF\DocAppWPF\Entrainement.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dgEntrainements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEntrainement.SelectedIndex >= 0) LocalEntrainement.EntrainementSelectionnee2UneEntrainement();
        }
    }
}
