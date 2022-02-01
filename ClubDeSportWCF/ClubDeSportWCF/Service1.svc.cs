using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClubDeSportWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //Pour recuperer les match
        public List<T_Match> RecupMatch(DateTime DateDebut, DateTime DateFin)
        {
            string chConn = @"Data Source=MSI\SQLEXPRESS;AttachDbFilename='D:\BD\ClubDeFootWpf.mdf';Integrated Security=True;Connect Timeout=30";


            List<T_Match> ListeMembre = new List<T_Match>();

            SqlConnection conn = new SqlConnection(chConn);

            conn.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM T_Match WHERE DateM BETWEEN '" + DateDebut.Year + "-" + DateDebut.Month + "-" + DateDebut.Day + "' AND '" + DateFin.Year + "-" + DateFin.Month + "-" + DateFin.Day + "'", conn);


            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                T_Match p = new T_Match();

                p.ID_Match = Int32.Parse(dr["ID_Match"].ToString());

                p.CarteJaune_Domicile = Int32.Parse(dr["CarteJaune_Domicile"].ToString());
                p.CarteRouge_Domicile = Int32.Parse(dr["CarteRouge_Domicile"].ToString());
                p.CarteJaune_Adversaire = Int32.Parse(dr["CarteJaune_Adversaire"].ToString());
                p.CarteRouge_Adversaire = Int32.Parse(dr["CarteRouge_Adversaire"].ToString());
                p.DateM = Convert.ToDateTime(dr["DateM"].ToString());

                ListeMembre.Add(p);
            }

            dr.Close();

            conn.Close();

            return ListeMembre;
        }

    }
}
