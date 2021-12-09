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
 public class C_T_Equipe
 {
  #region Données membres
  private int _ID_Equipe;
  private string _Nom;
  private int _ID_Club;
  #endregion
  #region Constructeurs
  public C_T_Equipe()
  { }
  public C_T_Equipe(string Nom_, int ID_Club_)
  {
   Nom = Nom_;
   ID_Club = ID_Club_;
  }
  public C_T_Equipe(int ID_Equipe_, string Nom_, int ID_Club_)
   : this(Nom_, ID_Club_)
  {
   ID_Equipe = ID_Equipe_;
  }
  #endregion
  #region Accesseurs
  public int ID_Equipe
  {
   get { return _ID_Equipe; }
   set { _ID_Equipe = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public int ID_Club
  {
   get { return _ID_Club; }
   set { _ID_Club = value; }
  }
  #endregion
 }
}
