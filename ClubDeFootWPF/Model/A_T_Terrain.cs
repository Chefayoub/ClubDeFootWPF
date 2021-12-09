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
 public class A_T_Terrain : ADBase
 {
  #region Constructeurs
  public A_T_Terrain(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom)
  {
   CreerCommande("AjouterT_Terrain");
   int res = 0;
   Commande.Parameters.Add("ID_Terrain", SqlDbType.Int);
   Direction("ID_Terrain", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Terrain"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Terrain, string Nom)
  {
   CreerCommande("ModifierT_Terrain");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Terrain> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Terrain");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Terrain> res = new List<C_T_Terrain>();
   while (dr.Read())
   {
    C_T_Terrain tmp = new C_T_Terrain();
    tmp.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
    tmp.Nom = dr["Nom"].ToString();
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Terrain Lire_ID(int ID_Terrain)
  {
   CreerCommande("SelectionnerT_Terrain_ID");
   Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Terrain res = new C_T_Terrain();
   while (dr.Read())
   {
    res.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
    res.Nom = dr["Nom"].ToString();
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Terrain)
  {
   CreerCommande("SupprimerT_Terrain");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
