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
 public class A_T_Equipe : ADBase
 {
  #region Constructeurs
  public A_T_Equipe(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, int ID_Club)
  {
   CreerCommande("AjouterT_Equipe");
   int res = 0;
   Commande.Parameters.Add("ID_Equipe", SqlDbType.Int);
   Direction("ID_Equipe", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@ID_Club", ID_Club);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Equipe"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Equipe, string Nom, int ID_Club)
  {
   CreerCommande("ModifierT_Equipe");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@ID_Club", ID_Club);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Equipe> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Equipe");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Equipe> res = new List<C_T_Equipe>();
   while (dr.Read())
   {
    C_T_Equipe tmp = new C_T_Equipe();
    tmp.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
    tmp.Nom = dr["Nom"].ToString();
    tmp.ID_Club = int.Parse(dr["ID_Club"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Equipe Lire_ID(int ID_Equipe)
  {
   CreerCommande("SelectionnerT_Equipe_ID");
   Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Equipe res = new C_T_Equipe();
   while (dr.Read())
   {
    res.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
    res.Nom = dr["Nom"].ToString();
    res.ID_Club = int.Parse(dr["ID_Club"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Equipe)
  {
   CreerCommande("SupprimerT_Equipe");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
