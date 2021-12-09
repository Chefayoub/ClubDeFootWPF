#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Projet_BD_ClubDeSportWPF.Classes;
#endregion

namespace Projet_BD_ClubDeSportWPF.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_T_Club : ADBase
 {
  #region Constructeurs
  public A_T_Club(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, string Rue, int Numero, int Code_Postal, string Localite, string Mon_Club)
  {
   CreerCommande("AjouterT_Club");
   int res = 0;
   Commande.Parameters.Add("ID_Club", SqlDbType.Int);
   Direction("ID_Club", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Rue", Rue);
   Commande.Parameters.AddWithValue("@Numero", Numero);
   Commande.Parameters.AddWithValue("@Code_Postal", Code_Postal);
   Commande.Parameters.AddWithValue("@Localite", Localite);
   Commande.Parameters.AddWithValue("@Mon_Club", Mon_Club);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Club"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Club, string Nom, string Rue, int Numero, int Code_Postal, string Localite, string Mon_Club)
  {
   CreerCommande("ModifierT_Club");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Club", ID_Club);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Rue", Rue);
   Commande.Parameters.AddWithValue("@Numero", Numero);
   Commande.Parameters.AddWithValue("@Code_Postal", Code_Postal);
   Commande.Parameters.AddWithValue("@Localite", Localite);
   Commande.Parameters.AddWithValue("@Mon_Club", Mon_Club);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Club> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Club");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Club> res = new List<C_T_Club>();
   while (dr.Read())
   {
    C_T_Club tmp = new C_T_Club();
    tmp.ID_Club = int.Parse(dr["ID_Club"].ToString());
    tmp.Nom = dr["Nom"].ToString();
    tmp.Rue = dr["Rue"].ToString();
    tmp.Numero = int.Parse(dr["Numero"].ToString());
    tmp.Code_Postal = int.Parse(dr["Code_Postal"].ToString());
    tmp.Localite = dr["Localite"].ToString();
    tmp.Mon_Club = dr["Mon_Club"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Club Lire_ID(int ID_Club)
  {
   CreerCommande("SelectionnerT_Club_ID");
   Commande.Parameters.AddWithValue("@ID_Club", ID_Club);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Club res = new C_T_Club();
   while (dr.Read())
   {
    res.ID_Club = int.Parse(dr["ID_Club"].ToString());
    res.Nom = dr["Nom"].ToString();
    res.Rue = dr["Rue"].ToString();
    res.Numero = int.Parse(dr["Numero"].ToString());
    res.Code_Postal = int.Parse(dr["Code_Postal"].ToString());
    res.Localite = dr["Localite"].ToString();
    res.Mon_Club = dr["Mon_Club"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Club)
  {
   CreerCommande("SupprimerT_Club");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Club", ID_Club);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
