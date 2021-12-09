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
 public class A_T_Membre : ADBase
 {
  #region Constructeurs
  public A_T_Membre(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, string Prenom, string Email, string NumeroTel, DateTime DateDeNaissance, int ID_Equipe)
  {
   CreerCommande("AjouterT_Membre");
   int res = 0;
   Commande.Parameters.Add("ID_Membre", SqlDbType.Int);
   Direction("ID_Membre", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Prenom", Prenom);
   Commande.Parameters.AddWithValue("@Email", Email);
   Commande.Parameters.AddWithValue("@NumeroTel", NumeroTel);
   Commande.Parameters.AddWithValue("@DateDeNaissance", DateDeNaissance);
   Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("ID_Membre"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int ID_Membre, string Nom, string Prenom, string Email, string NumeroTel, DateTime DateDeNaissance, int ID_Equipe)
  {
   CreerCommande("ModifierT_Membre");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Membre", ID_Membre);
   Commande.Parameters.AddWithValue("@Nom", Nom);
   Commande.Parameters.AddWithValue("@Prenom", Prenom);
   Commande.Parameters.AddWithValue("@Email", Email);
   Commande.Parameters.AddWithValue("@NumeroTel", NumeroTel);
   Commande.Parameters.AddWithValue("@DateDeNaissance", DateDeNaissance);
   Commande.Parameters.AddWithValue("@ID_Equipe", ID_Equipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Membre> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Membre");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Membre> res = new List<C_T_Membre>();
   while (dr.Read())
   {
    C_T_Membre tmp = new C_T_Membre();
    tmp.ID_Membre = int.Parse(dr["ID_Membre"].ToString());
    tmp.Nom = dr["Nom"].ToString();
    tmp.Prenom = dr["Prenom"].ToString();
    tmp.Email = dr["Email"].ToString();
    tmp.NumeroTel = dr["NumeroTel"].ToString();
    tmp.DateDeNaissance = DateTime.Parse(dr["DateDeNaissance"].ToString());
    tmp.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Membre Lire_ID(int ID_Membre)
  {
   CreerCommande("SelectionnerT_Membre_ID");
   Commande.Parameters.AddWithValue("@ID_Membre", ID_Membre);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Membre res = new C_T_Membre();
   while (dr.Read())
   {
    res.ID_Membre = int.Parse(dr["ID_Membre"].ToString());
    res.Nom = dr["Nom"].ToString();
    res.Prenom = dr["Prenom"].ToString();
    res.Email = dr["Email"].ToString();
    res.NumeroTel = dr["NumeroTel"].ToString();
    res.DateDeNaissance = DateTime.Parse(dr["DateDeNaissance"].ToString());
    res.ID_Equipe = int.Parse(dr["ID_Equipe"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int ID_Membre)
  {
   CreerCommande("SupprimerT_Membre");
   int res = 0;
   Commande.Parameters.AddWithValue("@ID_Membre", ID_Membre);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
