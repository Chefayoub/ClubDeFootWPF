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
 public class G_T_Equipe : G_Base
 {
  #region Constructeurs
  public G_T_Equipe()
   : base()
  { }
  public G_T_Equipe(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, int ID_Club)
  { return new A_T_Equipe(ChaineConnexion).Ajouter(Nom, ID_Club); }
  public int Modifier(int ID_Equipe, string Nom, int ID_Club)
  { return new A_T_Equipe(ChaineConnexion).Modifier(ID_Equipe, Nom, ID_Club); }
  public List<C_T_Equipe> Lire(string Index)
  { return new A_T_Equipe(ChaineConnexion).Lire(Index); }
  public C_T_Equipe Lire_ID(int ID_Equipe)
  { return new A_T_Equipe(ChaineConnexion).Lire_ID(ID_Equipe); }
  public int Supprimer(int ID_Equipe)
  { return new A_T_Equipe(ChaineConnexion).Supprimer(ID_Equipe); }
 }
}
