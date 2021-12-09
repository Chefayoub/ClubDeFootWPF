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
 public class G_T_Club : G_Base
 {
  #region Constructeurs
  public G_T_Club()
   : base()
  { }
  public G_T_Club(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string Nom, string Rue, int Numero, int Code_Postal, string Localite, string Mon_Club)
  { return new A_T_Club(ChaineConnexion).Ajouter(Nom, Rue, Numero, Code_Postal, Localite, Mon_Club); }
  public int Modifier(int ID_Club, string Nom, string Rue, int Numero, int Code_Postal, string Localite, string Mon_Club)
  { return new A_T_Club(ChaineConnexion).Modifier(ID_Club, Nom, Rue, Numero, Code_Postal, Localite, Mon_Club); }
  public List<C_T_Club> Lire(string Index)
  { return new A_T_Club(ChaineConnexion).Lire(Index); }
  public C_T_Club Lire_ID(int ID_Club)
  { return new A_T_Club(ChaineConnexion).Lire_ID(ID_Club); }
  public int Supprimer(int ID_Club)
  { return new A_T_Club(ChaineConnexion).Supprimer(ID_Club); }
 }
}
