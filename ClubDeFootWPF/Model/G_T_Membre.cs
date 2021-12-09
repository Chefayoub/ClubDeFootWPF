#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_BD_ClubDeSportWPF.Classes;
using Projet_BD_ClubDeSportWPF.Acces;
#endregion

namespace Projet_BD_ClubDeSportWPF.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_T_Membre : G_Base
 {
  #region Constructeurs
  public G_T_Membre()
   : base()
  { }
  public G_T_Membre(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, string Prenom, string Email, string NumeroTel, DateTime DateDeNaissance, int ID_Equipe)
  { return new A_T_Membre(ChaineConnexion).Ajouter(Nom, Prenom, Email, NumeroTel, DateDeNaissance, ID_Equipe); }
  public int Modifier(int ID_Membre, string Nom, string Prenom, string Email, string NumeroTel, DateTime DateDeNaissance, int ID_Equipe)
  { return new A_T_Membre(ChaineConnexion).Modifier(ID_Membre, Nom, Prenom, Email, NumeroTel, DateDeNaissance, ID_Equipe); }
  public List<C_T_Membre> Lire(string Index)
  { return new A_T_Membre(ChaineConnexion).Lire(Index); }
  public C_T_Membre Lire_ID(int ID_Membre)
  { return new A_T_Membre(ChaineConnexion).Lire_ID(ID_Membre); }
  public int Supprimer(int ID_Membre)
  { return new A_T_Membre(ChaineConnexion).Supprimer(ID_Membre); }
 }
}
