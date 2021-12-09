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
 public class A_T_Entrainement : ADBase
 {
  #region Constructeurs
  public A_T_Entrainement(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(DateTime DateE, int? ID_Terrain, int? ID_Equipe)
  {
   CreerCommande("AjouterT_Entrainement");
   int res = 0;
   Commande.Parameters.Add("ID_Entrainement", SqlDbType.Int);
   Direction("ID_Entrainement", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@DateE", DateE);
   if(ID_Terrain == null) Commande.Parameters.AddWithValue("@ID_Terrain", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   if(ID_Equipe == null) Commande.Parameters.AddWithValue("@ID_Equipe", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Entrainement"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Entrainement, DateTime DateE, int? ID_Terrain, int? ID_Equipe)
  {
   CreerCommande("ModifierT_Entrainement");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Entrainement", ID_Entrainement);
   Commande.Parameters.AddWithValue("@DateE", DateE);
   if(ID_Terrain == null) Commande.Parameters.AddWithValue("@ID_Terrain", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   if(ID_Equipe == null) Commande.Parameters.AddWithValue("@ID_Equipe", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Entrainement> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Entrainement");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Entrainement> res = new List<C_T_Entrainement>();
   while (dr.Read())
   {
    C_T_Entrainement tmp = new C_T_Entrainement();
    tmp.ID_Entrainement = int.Parse(dr["ID_Entrainement"].ToString());
    tmp.DateE = DateTime.Parse(dr["DateE"].ToString());
   if(dr["ID_Terrain"] != DBNull.Value) tmp.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
   if(dr["ID_Equipe"] != DBNull.Value) tmp.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Entrainement Lire_ID(int ID_Entrainement)
  {
   CreerCommande("SelectionnerT_Entrainement_ID");
   Commande.Parameters.AddWithValue("@ID_Entrainement", ID_Entrainement);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Entrainement res = new C_T_Entrainement();
   while (dr.Read())
   {
    res.ID_Entrainement = int.Parse(dr["ID_Entrainement"].ToString());
    res.DateE = DateTime.Parse(dr["DateE"].ToString());
   if(dr["ID_Terrain"] != DBNull.Value) res.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
   if(dr["ID_Equipe"] != DBNull.Value) res.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Entrainement)
  {
   CreerCommande("SupprimerT_Entrainement");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Entrainement", ID_Entrainement);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
