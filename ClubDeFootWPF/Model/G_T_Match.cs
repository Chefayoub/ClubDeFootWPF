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
 public class G_T_Match : G_Base
 {
  #region Constructeurs
  public G_T_Match()
   : base()
  { }
  public G_T_Match(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int? Score_Domicile, int? Score_Adversaire, DateTime DateM, int ID_Domicile, int ID_Deplacement, int ID_Terrain)
  { return new A_T_Match(ChaineConnexion).Ajouter(Score_Domicile, Score_Adversaire, DateM, ID_Domicile, ID_Deplacement, ID_Terrain); }
  public int Modifier(int ID_Match, int? Score_Domicile, int? Score_Adversaire, DateTime DateM, int ID_Domicile, int ID_Deplacement, int ID_Terrain)
  { return new A_T_Match(ChaineConnexion).Modifier(ID_Match, Score_Domicile, Score_Adversaire, DateM, ID_Domicile, ID_Deplacement, ID_Terrain); }
  public List<C_T_Match> Lire(string Index)
  { return new A_T_Match(ChaineConnexion).Lire(Index); }
  public C_T_Match Lire_ID(int ID_Match)
  { return new A_T_Match(ChaineConnexion).Lire_ID(ID_Match); }
  public int Supprimer(int ID_Match)
  { return new A_T_Match(ChaineConnexion).Supprimer(ID_Match); }
 }
}
