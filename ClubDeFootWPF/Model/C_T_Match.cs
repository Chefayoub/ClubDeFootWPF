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
  private int? _CarteJaune_Domicile;
  private int? _CarteRouge_Domicile; 
  private int? _CarteJaune_Adversaire;
  private int? _CarteRouge_Adversaire; 
  #endregion
  #region Constructeurs
  public C_T_Match()
  { }
  public C_T_Match(int? Score_Domicile_, int? Score_Adversaire_, DateTime DateM_, int ID_Domicile_, int ID_Deplacement_, int ID_Terrain_, int? CarteJaune_Domicile_, int? CarteRouge_Domicile_, int? CarteJaune_Adversaire_, int? CarteRouge_Adversaire_)
  {
   Score_Domicile = Score_Domicile_;
   Score_Adversaire = Score_Adversaire_;
   DateM = DateM_;
   ID_Domicile = ID_Domicile_;
   ID_Deplacement = ID_Deplacement_;
   ID_Terrain = ID_Terrain_;
   CarteJaune_Domicile = CarteJaune_Domicile_;
   CarteRouge_Domicile = CarteRouge_Domicile_;
   CarteJaune_Adversaire = CarteJaune_Adversaire_;
   CarteRouge_Adversaire = CarteRouge_Adversaire_;
        }
  public C_T_Match(int ID_Match_, int? Score_Domicile_, int? Score_Adversaire_, DateTime DateM_, int ID_Domicile_, int ID_Deplacement_, int ID_Terrain_, int? CarteJaune_Domicile_, int? CarteRouge_Domicile_, int? CarteJaune_Adversaire_, int? CarteRouge_Adversaire_)
   : this(Score_Domicile_, Score_Adversaire_, DateM_, ID_Domicile_, ID_Deplacement_, ID_Terrain_, CarteJaune_Domicile_, CarteRouge_Domicile_, CarteJaune_Adversaire_, CarteRouge_Adversaire_)
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
  public int? CarteJaune_Domicile
  {
   get { return _CarteJaune_Domicile; }
   set { _CarteJaune_Domicile = value; }
  }
  public int? CarteRouge_Domicile
  {
   get { return _CarteRouge_Domicile; }
   set { _CarteRouge_Domicile = value; }
  }
  public int? CarteJaune_Adversaire
  {
   get { return _CarteJaune_Adversaire; }
   set { _CarteJaune_Adversaire = value; }
  }
  public int? CarteRouge_Adversaire
  {
   get { return _CarteRouge_Adversaire; }
   set { _CarteRouge_Adversaire = value; }
  }
  #endregion
 }
}
