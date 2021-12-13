using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_BD_ClubDeSportWPF.Classes;
using Projet_BD_ClubDeSportWPF.Gestion;

namespace ClubDeFootWPF.ViewModel
{
    class VM_Membre : BasePropriete
    {
        #region Données Écran
        //@"Data Source=MSI\SQLEXPRESS;AttachDbFilename=D:\BD_ClubDeFootball\BD_ClubDeSport.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;
        private int nAjout;
        private bool _ActiverUneFiche;


        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }
        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_T_Membre _MembreSelectionnee;
        public C_T_Membre MembreSelectionnee
        {
            get { return _MembreSelectionnee; }
            set { AssignerChamp<C_T_Membre>(ref _MembreSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UneMembre _UneMembre;
        public VM_UneMembre UneMembre
        {
            get { return _UneMembre; }
            set { AssignerChamp<VM_UneMembre>(ref _UneMembre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Membre> _BcpMembres = new ObservableCollection<C_T_Membre>();
        public ObservableCollection<C_T_Membre> BcpMembres
        {
            get { return _BcpMembres; }
            set { _BcpMembres = value; }
        }
        #endregion

        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cEssaiSelMult { get; set; }
        #endregion

        public VM_Membre()
        {
            UneMembre = new VM_UneMembre();
            BcpMembres = ChargerMembres(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Membre> ChargerMembres(string chConn)
        {
            ObservableCollection<C_T_Membre> rep = new ObservableCollection<C_T_Membre>();
            List<C_T_Membre> lTmp = new G_T_Membre(chConn).Lire("ID_Membre");
            foreach (C_T_Membre Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UneMembre.ID_Membre = new G_T_Membre(chConnexion).Ajouter(UneMembre.Nom, UneMembre.Prenom, UneMembre.Email, UneMembre.NumeroTel, UneMembre.DateDeNaissance, UneMembre.ID_Equipe);
                BcpMembres.Add(new C_T_Membre(UneMembre.ID_Membre, UneMembre.Nom, UneMembre.Prenom, UneMembre.Email, UneMembre.NumeroTel, UneMembre.DateDeNaissance, UneMembre.ID_Equipe));
            }
            else
            {
                new G_T_Membre(chConnexion).Modifier(UneMembre.ID_Membre, UneMembre.Nom, UneMembre.Prenom, UneMembre.Email, UneMembre.NumeroTel, UneMembre.DateDeNaissance, UneMembre.ID_Equipe);
                BcpMembres[nAjout] = new C_T_Membre(UneMembre.ID_Membre, UneMembre.Nom, UneMembre.Prenom, UneMembre.Email, UneMembre.NumeroTel, UneMembre.DateDeNaissance, UneMembre.ID_Equipe);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UneMembre = new VM_UneMembre();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (MembreSelectionnee != null)
            {
                C_T_Membre Tmp = new G_T_Membre(chConnexion).Lire_ID(MembreSelectionnee.ID_Membre);
                UneMembre = new VM_UneMembre();
                UneMembre.ID_Membre = Tmp.ID_Membre;
                UneMembre.ID_Equipe = Tmp.ID_Equipe;
                UneMembre.Nom = Tmp.Nom;
                UneMembre.Prenom = Tmp.Prenom;
                UneMembre.Email = Tmp.Email;
                UneMembre.NumeroTel = Tmp.NumeroTel;
                UneMembre.DateDeNaissance = Tmp.DateDeNaissance;
                nAjout = BcpMembres.IndexOf(MembreSelectionnee);
                ActiverUneFiche = true;
            }
        }

        public void Supprimer()
        {
            if (MembreSelectionnee != null)
            {
                new G_T_Membre(chConnexion).Supprimer(MembreSelectionnee.ID_Membre);
                BcpMembres.Remove(MembreSelectionnee);
            }
        }

        public void EssaiSelMult(object lListe)
        {
            System.Collections.IList lTmp = (System.Collections.IList)lListe;
            foreach (C_T_Membre p in lTmp)
            { string s = p.Nom; }
            int nTmp = lTmp.Count;
        }

        public void MembreSelectionnee2UneMembre()
        {
            UneMembre.ID_Membre = MembreSelectionnee.ID_Membre;
            UneMembre.ID_Equipe = MembreSelectionnee.ID_Equipe;
            UneMembre.Nom = MembreSelectionnee.Nom;
            UneMembre.Prenom = MembreSelectionnee.Prenom;
            UneMembre.Email = MembreSelectionnee.Email;
            UneMembre.NumeroTel = MembreSelectionnee.NumeroTel;
            UneMembre.DateDeNaissance = MembreSelectionnee.DateDeNaissance;
        }
    }

    public class VM_UneMembre : BasePropriete
    {
        private int _ID_Membre, _ID_Equipe;
        private string _Nom, _Prenom, _Email, _NumeroTel;
        private DateTime _DateDeNaissance;

        public int ID_Membre
        {
            get { return _ID_Membre; }
            set { AssignerChamp<int>(ref _ID_Membre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Equipe
        {
            get { return _ID_Equipe; }
            set { AssignerChamp<int>(ref _ID_Equipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string NumeroTel
        {
            get { return _NumeroTel; }
            set { AssignerChamp<string>(ref _NumeroTel, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Nom
        {
            get { return _Nom; }
            set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { AssignerChamp<string>(ref _Prenom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Email
        {
            get { return _Email; }
            set { AssignerChamp<string>(ref _Email, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public DateTime DateDeNaissance
        {
            get { return _DateDeNaissance; }
            set { AssignerChamp<DateTime>(ref _DateDeNaissance, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
}
