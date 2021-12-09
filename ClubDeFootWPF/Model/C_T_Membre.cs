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
 public class C_T_Membre
 {
  #region Données membres
  private int _ID_Membre;
  private string _Nom;
  private string _Prenom;
  private string _Email;
  private string _NumeroTel;
  private DateTime _DateDeNaissance;
  private int _ID_Equipe;
  #endregion
  #region Constructeurs
  public C_T_Membre()
  { }
  public C_T_Membre(string Nom_, string Prenom_, string Email_, string NumeroTel_, DateTime DateDeNaissance_, int ID_Equipe_)
  {
   Nom = Nom_;
   Prenom = Prenom_;
   Email = Email_;
   NumeroTel = NumeroTel_;
   DateDeNaissance = DateDeNaissance_;
   ID_Equipe = ID_Equipe_;
  }
  public C_T_Membre(int ID_Membre_, string Nom_, string Prenom_, string Email_, string NumeroTel_, DateTime DateDeNaissance_, int ID_Equipe_)
   : this(Nom_, Prenom_, Email_, NumeroTel_, DateDeNaissance_, ID_Equipe_)
  {
   ID_Membre = ID_Membre_;
  }
  #endregion
  #region Accesseurs
  public int ID_Membre
  {
   get { return _ID_Membre; }
   set { _ID_Membre = value; }
  }
  public string Nom
  {
   get { return _Nom; }
   set { _Nom = value; }
  }
  public string Prenom
  {
   get { return _Prenom; }
   set { _Prenom = value; }
  }
  public string Email
  {
   get { return _Email; }
   set { _Email = value; }
  }
  public string NumeroTel
  {
   get { return _NumeroTel; }
   set { _NumeroTel = value; }
  }
  public DateTime DateDeNaissance
  {
   get { return _DateDeNaissance; }
   set { _DateDeNaissance = value; }
  }
  public int ID_Equipe
  {
   get { return _ID_Equipe; }
   set { _ID_Equipe = value; }
  }
  #endregion
 }
}
