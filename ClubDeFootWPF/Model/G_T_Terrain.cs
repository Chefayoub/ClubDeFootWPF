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
 public class G_T_Terrain : G_Base
 {
  #region Constructeurs
  public G_T_Terrain()
   : base()
  { }
  public G_T_Terrain(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom)
  { return new A_T_Terrain(ChaineConnexion).Ajouter(Nom); }
  public int Modifier(int ID_Terrain, string Nom)
  { return new A_T_Terrain(ChaineConnexion).Modifier(ID_Terrain, Nom); }
  public List<C_T_Terrain> Lire(string Index)
  { return new A_T_Terrain(ChaineConnexion).Lire(Index); }
  public C_T_Terrain Lire_ID(int ID_Terrain)
  { return new A_T_Terrain(ChaineConnexion).Lire_ID(ID_Terrain); }
  public int Supprimer(int ID_Terrain)
  { return new A_T_Terrain(ChaineConnexion).Supprimer(ID_Terrain); }
 }
}
