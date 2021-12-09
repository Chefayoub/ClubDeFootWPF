#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Projet_BD_ClubDeSportWPF.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_T_Terrain
 {
  #region Données membres
  private int _ID_Terrain;
  private string _Nom;
  #endregion
  #region Constructeurs
  public C_T_Terrain()
  { }
  public C_T_Terrain(string Nom_)
  {
   Nom = Nom_;
  }
  public C_T_Terrain(int ID_Terrain_, string Nom_)
   : this(Nom_)
  {
   ID_Terrain = ID_Terrain_;
  }
  #endregion
  #region Accesseurs
  public int ID_Terrain
  {
   get { return _ID_Terrain; }
   set { _ID_Terrain = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  #endregion
 }
}
