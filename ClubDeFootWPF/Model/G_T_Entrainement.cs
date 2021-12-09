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
 public class G_T_Entrainement : G_Base
 {
  #region Constructeurs
  public G_T_Entrainement()
   : base()
  { }
  public G_T_Entrainement(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(DateTime DateE, int? ID_Terrain, int? ID_Equipe)
  { return new A_T_Entrainement(ChaineConnexion).Ajouter(DateE, ID_Terrain, ID_Equipe); }
  public int Modifier(int ID_Entrainement, DateTime DateE, int? ID_Terrain, int? ID_Equipe)
  { return new A_T_Entrainement(ChaineConnexion).Modifier(ID_Entrainement, DateE, ID_Terrain, ID_Equipe); }
  public List<C_T_Entrainement> Lire(string Index)
  { return new A_T_Entrainement(ChaineConnexion).Lire(Index); }
  public C_T_Entrainement Lire_ID(int ID_Entrainement)
  { return new A_T_Entrainement(ChaineConnexion).Lire_ID(ID_Entrainement); }
  public int Supprimer(int ID_Entrainement)
  { return new A_T_Entrainement(ChaineConnexion).Supprimer(ID_Entrainement); }
 }
}
