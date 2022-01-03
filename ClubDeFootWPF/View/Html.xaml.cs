using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
//using System.Windows.Forms;
using Projet_BD_ClubDeSportWPF.Classes;
using Projet_BD_ClubDeSportWPF.Gestion;

namespace ClubDeFootWPF.View
{
    //Pour les vues https://www.youtube.com/watch?v=LiXTgZ3pYgI
    /// <summary>
    /// Logique d'interaction pour Html.xaml
    /// </summary>
    public partial class Html : Window
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;
        private DataTable dtHtml;
        private BindingSource bsHtml;

        public Html()
        {
            InitializeComponent();
            RemplirDT();
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<h1 style='text-align:center ; background - color: #65C509; font-family:arial; '>Football Club Managers</h1>");
            strHTMLBuilder.Append("<h1 style='text-align:center ; background - color: #65C509; font-family:arial; '>Programme de la semaine a venir</h1>");
            strHTMLBuilder.Append("<table align='center' border='3px' cellpadding='5' cellspacing='1' bgcolor='black'style='color:white; border: 1px solid #ccc;font-size: 12pt;font-family:arial'>");
            strHTMLBuilder.Append("<tr>");

            foreach (DataColumn myColumn in dtHtml.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }

            strHTMLBuilder.Append("</tr>");
            foreach (DataRow myRow in dtHtml.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dtHtml.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            File.WriteAllText(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\MatchAVenir.HTML", Htmltext);
            wbMatch.Navigate(@"D:\Documents\BLOC_3\WPF MVVM\Application\ClubDeFootWPF\Fichier_Match\MatchAVenir.HTML");
        }

        public void RemplirDT()
        {
            dtHtml = new DataTable();
            dtHtml.Columns.Add(new DataColumn("ID_Match", System.Type.GetType("System.Int32")));
            dtHtml.Columns.Add(new DataColumn("ID_Domicile", System.Type.GetType("System.Int32")));
            dtHtml.Columns.Add(new DataColumn { ColumnName = "Score_Domicile", DataType = System.Type.GetType("System.Int32"), AllowDBNull = true });
            dtHtml.Columns[2].AllowDBNull = true;
            dtHtml.Columns.Add(new DataColumn("ID_Adversaire", System.Type.GetType("System.Int32")));
            dtHtml.Columns.Add(new DataColumn { ColumnName = "Score_Adversaire", DataType = System.Type.GetType("System.Int32"), AllowDBNull = true });
            dtHtml.Columns[4].AllowDBNull = true;
            dtHtml.Columns.Add(new DataColumn("Date"));
            dtHtml.Columns.Add(new DataColumn("ID_Terrain", System.Type.GetType("System.Int32")));


            List<C_T_Match> lTmp = new G_T_Match(chConnexion).Lire("ID_Match");
            foreach (C_T_Match p in lTmp)
            {
                if (p.Score_Domicile == 0 && p.Score_Adversaire == 0)
                {
                    if ((p.DateM - DateTime.Now).TotalDays <= 7 && (p.DateM - DateTime.Now).TotalDays >= 0)
                    {
                        dtHtml.Rows.Add(p.ID_Match, p.ID_Domicile, p.Score_Domicile, p.ID_Deplacement, p.Score_Adversaire, p.DateM.ToString("g"), p.ID_Terrain);
                    }
                }

            }
            bsHtml = new BindingSource();
            bsHtml.DataSource = dtHtml;
        }
    }    
}


