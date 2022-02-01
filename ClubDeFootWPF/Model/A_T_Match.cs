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
 public class A_T_Match : ADBase
 {
  #region Constructeurs
  public A_T_Match(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? Score_Domicile, int? Score_Adversaire, DateTime DateM, int ID_Domicile, int ID_Deplacement, int ID_Terrain, int? CarteJaune_Domicile, int? CarteRouge_Domicile, int? CarteJaune_Adversaire, int? CarteRouge_Adversaire)
  {
   CreerCommande("AjouterT_Match");
   int res = 0;
   Commande.Parameters.Add("ID_Match", SqlDbType.Int);
   Direction("ID_Match", ParameterDirection.Output);
   if(Score_Domicile == null) Commande.Parameters.AddWithValue("@Score_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Score_Domicile", Score_Domicile);
   if(Score_Adversaire == null) Commande.Parameters.AddWithValue("@Score_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Score_Adversaire", Score_Adversaire);
   Commande.Parameters.AddWithValue("@DateM", DateM);
   Commande.Parameters.AddWithValue("@ID_Domicile", ID_Domicile);
   Commande.Parameters.AddWithValue("@ID_Deplacement", ID_Deplacement);
   Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   if (CarteJaune_Domicile == null) Commande.Parameters.AddWithValue("@CarteJaune_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteJaune_Domicile", Score_Domicile);
   if (CarteRouge_Domicile == null) Commande.Parameters.AddWithValue("@CarteRouge_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteRouge_Domicile", Score_Adversaire);
   if (CarteJaune_Adversaire == null) Commande.Parameters.AddWithValue("@CarteJaune_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteJaune_Adversaire", Score_Domicile);
   if (CarteRouge_Adversaire == null) Commande.Parameters.AddWithValue("@CarteRouge_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteRouge_Adversaire", Score_Adversaire);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Match"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Match, int? Score_Domicile, int? Score_Adversaire, DateTime DateM, int ID_Domicile, int ID_Deplacement, int ID_Terrain, int? CarteJaune_Domicile, int? CarteRouge_Domicile, int? CarteJaune_Adversaire, int? CarteRouge_Adversaire)
        {
   CreerCommande("ModifierT_Match");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Match", ID_Match);
   if(Score_Domicile == null) Commande.Parameters.AddWithValue("@Score_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Score_Domicile", Score_Domicile);
   if(Score_Adversaire == null) Commande.Parameters.AddWithValue("@Score_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@Score_Adversaire", Score_Adversaire);
   Commande.Parameters.AddWithValue("@DateM", DateM);
   Commande.Parameters.AddWithValue("@ID_Domicile", ID_Domicile);
   Commande.Parameters.AddWithValue("@ID_Deplacement", ID_Deplacement);
   Commande.Parameters.AddWithValue("@ID_Terrain", ID_Terrain);
   if (CarteJaune_Domicile == null) Commande.Parameters.AddWithValue("@CarteJaune_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteJaune_Domicile", Score_Domicile);
   if (CarteRouge_Domicile == null) Commande.Parameters.AddWithValue("@CarteRouge_Domicile", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteRouge_Domicile", Score_Adversaire);
   if (CarteJaune_Adversaire == null) Commande.Parameters.AddWithValue("@CarteJaune_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteJaune_Adversaire", Score_Domicile);
   if (CarteRouge_Adversaire == null) Commande.Parameters.AddWithValue("@CarteRouge_Adversaire", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@CarteRouge_Adversaire", Score_Adversaire);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Match> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Match");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Match> res = new List<C_T_Match>();
   while (dr.Read())
   {
    C_T_Match tmp = new C_T_Match();
    tmp.ID_Match = int.Parse(dr["ID_Match"].ToString());
   if(dr["Score_Domicile"] != DBNull.Value) tmp.Score_Domicile = int.Parse(dr["Score_Domicile"].ToString());
   if(dr["Score_Adversaire"] != DBNull.Value) tmp.Score_Adversaire = int.Parse(dr["Score_Adversaire"].ToString());
    tmp.DateM = DateTime.Parse(dr["DateM"].ToString());
    tmp.ID_Domicile = int.Parse(dr["ID_Domicile"].ToString());
    tmp.ID_Deplacement = int.Parse(dr["ID_Deplacement"].ToString());
    tmp.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
   if(dr["CarteJaune_Domicile"] != DBNull.Value) tmp.CarteJaune_Domicile = int.Parse(dr["CarteJaune_Domicile"].ToString());
   if(dr["CarteRouge_Domicile"] != DBNull.Value) tmp.CarteRouge_Domicile = int.Parse(dr["CarteJaune_Domicile"].ToString());
   if(dr["CarteJaune_Adversaire"] != DBNull.Value) tmp.CarteJaune_Adversaire = int.Parse(dr["CarteJaune_Adversaire"].ToString());
   if(dr["CarteRouge_Adversaire"] != DBNull.Value) tmp.CarteRouge_Adversaire = int.Parse(dr["CarteRouge_Adversaire"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Match Lire_ID(int ID_Match)
  {
   CreerCommande("SelectionnerT_Match_ID");
   Commande.Parameters.AddWithValue("@ID_Match", ID_Match);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Match res = new C_T_Match();
   while (dr.Read())
   {
    res.ID_Match = int.Parse(dr["ID_Match"].ToString());
   if(dr["Score_Domicile"] != DBNull.Value) res.Score_Domicile = int.Parse(dr["Score_Domicile"].ToString());
   if(dr["Score_Adversaire"] != DBNull.Value) res.Score_Adversaire = int.Parse(dr["Score_Adversaire"].ToString());
    res.DateM = DateTime.Parse(dr["DateM"].ToString());
    res.ID_Domicile = int.Parse(dr["ID_Domicile"].ToString());
    res.ID_Deplacement = int.Parse(dr["ID_Deplacement"].ToString());
    res.ID_Terrain = int.Parse(dr["ID_Terrain"].ToString());
   if(dr["CarteJaune_Domicile"] != DBNull.Value) res.CarteJaune_Domicile = int.Parse(dr["CarteJaune_Domicile"].ToString());
   if(dr["CarteRouge_Domicile"] != DBNull.Value) res.CarteRouge_Domicile = int.Parse(dr["CarteRouge_Domicile"].ToString());
   if(dr["CarteJaune_Adversaire"] != DBNull.Value) res.CarteJaune_Adversaire = int.Parse(dr["CarteJaune_Adversaire"].ToString());
   if(dr["CarteRouge_Adversaire"] != DBNull.Value) res.CarteRouge_Adversaire = int.Parse(dr["CarteRouge_Adversaire"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Match)
  {
   CreerCommande("SupprimerT_Match");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Match", ID_Match);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
