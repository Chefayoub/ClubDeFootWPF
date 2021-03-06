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
    /// Logique d'interaction pour Terrain.xaml
    /// </summary>
    public partial class Terrain : Window
    {
        private ViewModel.VM_Terrain LocalTerrain;

        public Terrain()
        {
            InitializeComponent();

            LocalTerrain = new ViewModel.VM_Terrain();
            DataContext = LocalTerrain;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();

            foreach (C_T_Terrain cp in LocalTerrain.BcpTerrains)
            {
                Paragraph pl = new Paragraph(new Run(cp.ID_Terrain + " " + cp.Nom));
                l.ListItems.Add(new ListItem(pl));
            }

            fd.Blocks.Add(l);
        }

        private void dgTerrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTerrain.SelectedIndex >= 0) LocalTerrain.TerrainSelectionnee2UneTerrain();
        }
    }
}
