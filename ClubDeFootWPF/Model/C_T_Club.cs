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
 public class C_T_Club
 {
  #region Données membres
  private int _ID_Club;
  private string _Nom;
  private string _Rue;
  private int _Numero;
  private int _Code_Postal;
  private string _Localite;
  private string _Mon_Club;
  #endregion
  #region Constructeurs
  public C_T_Club()
  { }
  public C_T_Club(string Nom_, string Rue_, int Numero_, int Code_Postal_, string Localite_, string Mon_Club_)
  {
   Nom = Nom_;
   Rue = Rue_;
   Numero = Numero_;
   Code_Postal = Code_Postal_;
   Localite = Localite_;
   Mon_Club = Mon_Club_;
  }
  public C_T_Club(int ID_Club_, string Nom_, string Rue_, int Numero_, int Code_Postal_, string Localite_, string Mon_Club_)
   : this(Nom_, Rue_, Numero_, Code_Postal_, Localite_, Mon_Club_)
  {
   ID_Club = ID_Club_;
  }
  #endregion
  #region Accesseurs
  public int ID_Club
  {
   get { return _ID_Club; }
   set { _ID_Club = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public string Rue
  {
   get { return _Rue; }
   set { _Rue = value; }
  }
  public int Numero
  {
   get { return _Numero; }
   set { _Numero = value; }
  }
  public int Code_Postal
  {
   get { return _Code_Postal; }
   set { _Code_Postal = value; }
  }
  public string Localite
  {
   get { return _Localite; }
   set { _Localite = value; }
  }
  public string Mon_Club
  {
   get { return _Mon_Club; }
   set { _Mon_Club = value; }
  }
  #endregion
 }
}
