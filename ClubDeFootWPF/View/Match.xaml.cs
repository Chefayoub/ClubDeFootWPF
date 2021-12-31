﻿using System;
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
    /// Logique d'interaction pour Match.xaml
    /// </summary>
    public partial class Match : Window
    {
        private ViewModel.VM_Match LocalMatch;

        public Match()
        {
            InitializeComponent();

            LocalMatch = new ViewModel.VM_Match();
            DataContext = LocalMatch;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Programme de la semaine à venir")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des match"));
            fd.Blocks.Add(p);

            List l = new List();
            foreach (C_T_Match cp in LocalMatch.BcpMatchs)
            {
                Paragraph pl = new Paragraph(new Run("Equipe domicile : " + cp.ID_Domicile + " - Equipe deplacement : " + cp.ID_Deplacement + " - Terrain : " + cp.ID_Terrain + " - Score domicile : " + cp.Score_Domicile + " - Score adversaire : " + cp.Score_Adversaire + " - Date et heure du match : " + cp.DateM));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\BD_ClubDeSportWPF\DocAppWPF\Match.doc", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, System.Windows.DataFormats.Rtf);
        }

        private void dgMatchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMatch.SelectedIndex >= 0) LocalMatch.MatchSelectionnee2UneMatch();
        }

    }
}
