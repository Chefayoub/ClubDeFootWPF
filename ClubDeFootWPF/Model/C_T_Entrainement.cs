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
 public class C_T_Entrainement
 {
  #region Données membres
  private int _ID_Entrainement;
  private DateTime _DateE;
  private int? _ID_Terrain;
  private int? _ID_Equipe;
  #endregion
  #region Constructeurs
  public C_T_Entrainement()
  { }
  public C_T_Entrainement(DateTime DateE_, int? ID_Terrain_, int? ID_Equipe_)
  {
   DateE = DateE_;
   ID_Terrain = ID_Terrain_;
   ID_Equipe = ID_Equipe_;
  }
  public C_T_Entrainement(int ID_Entrainement_, DateTime DateE_, int? ID_Terrain_, int? ID_Equipe_)
   : this(DateE_, ID_Terrain_, ID_Equipe_)
  {
   ID_Entrainement = ID_Entrainement_;
  }
  #endregion
  #region Accesseurs
  public int ID_Entrainement
  {
   get { return _ID_Entrainement; }
   set { _ID_Entrainement = value; }
  }
  public DateTime DateE
  {
   get { return _DateE; }
   set { _DateE = value; }
  }
  public int? ID_Terrain
  {
   get { return _ID_Terrain; }
   set { _ID_Terrain = value; }
  }
  public int? ID_Equipe
  {
   get { return _ID_Equipe; }
   set { _ID_Equipe = value; }
  }
  #endregion
 }
}
