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
 public class C_T_Match
 {
  #region Données membres
  private int _ID_Match;
  private int? _Score_Domicile;
  private int? _Score_Adversaire;
  private DateTime _DateM;
  private int _ID_Domicile;
  private int _ID_Deplacement;
  private int _ID_Terrain;
  #endregion
  #region Constructeurs
  public C_T_Match()
  { }
  public C_T_Match(int? Score_Domicile_, int? Score_Adversaire_, DateTime DateM_, int ID_Domicile_, int ID_Deplacement_, int ID_Terrain_)
  {
   Score_Domicile = Score_Domicile_;
   Score_Adversaire = Score_Adversaire_;
   DateM = DateM_;
   ID_Domicile = ID_Domicile_;
   ID_Deplacement = ID_Deplacement_;
   ID_Terrain = ID_Terrain_;
  }
  public C_T_Match(int ID_Match_, int? Score_Domicile_, int? Score_Adversaire_, DateTime DateM_, int ID_Domicile_, int ID_Deplacement_, int ID_Terrain_)
   : this(Score_Domicile_, Score_Adversaire_, DateM_, ID_Domicile_, ID_Deplacement_, ID_Terrain_)
  {
   ID_Match = ID_Match_;
  }
  #endregion
  #region Accesseurs
  public int ID_Match
  {
   get { return _ID_Match; }
   set { _ID_Match = value; }
  }
  public int? Score_Domicile
  {
   get { return _Score_Domicile; }
   set { _Score_Domicile = value; }
  }
  public int? Score_Adversaire
  {
   get { return _Score_Adversaire; }
   set { _Score_Adversaire = value; }
  }
  public DateTime DateM
  {
   get { return _DateM; }
   set { _DateM = value; }
  }
  public int ID_Domicile
  {
   get { return _ID_Domicile; }
   set { _ID_Domicile = value; }
  }
  public int ID_Deplacement
  {
   get { return _ID_Deplacement; }
   set { _ID_Deplacement = value; }
  }
  public int ID_Terrain
  {
   get { return _ID_Terrain; }
   set { _ID_Terrain = value; }
  }
  #endregion
 }
}
