using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projet_BD_ClubDeSportWPF.Classes;
using Projet_BD_ClubDeSportWPF.Gestion;

namespace ClubDeFootWPF.ViewModel
{
    class VM_Club : BasePropriete
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
        public bool ActiverUneFiche2
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
        private C_T_Club _ClubSelectionnee;
        public C_T_Club ClubSelectionnee
        {
            get { return _ClubSelectionnee; }
            set { AssignerChamp<C_T_Club>(ref _ClubSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnClub _UnClub;
        public VM_UnClub UnClub
        {
            get { return _UnClub; }
            set { AssignerChamp<VM_UnClub>(ref _UnClub, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Club> _BcpClubs = new ObservableCollection<C_T_Club>();
        public ObservableCollection<C_T_Club> BcpClubs
        {
            get { return _BcpClubs; }
            set { _BcpClubs = value; }
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

        public VM_Club()
        {
            UnClub = new VM_UnClub();
            BcpClubs = ChargerClubs(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Club> ChargerClubs(string chConn)
        {
            ObservableCollection<C_T_Club> rep = new ObservableCollection<C_T_Club>();
            List<C_T_Club> lTmp = new G_T_Club(chConn).Lire("ID_Club");
            foreach (C_T_Club Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }


        public void Confirmer()
        {

            if (nAjout == -1)
            {
                UnClub.ID_Club = new G_T_Club(chConnexion).Ajouter(UnClub.Nom, UnClub.Rue, UnClub.Numero, UnClub.Code_Postal, UnClub.Localite, UnClub.Mon_Club);
                BcpClubs.Add(new C_T_Club(UnClub.ID_Club, UnClub.Nom, UnClub.Rue, UnClub.Numero, UnClub.Code_Postal, UnClub.Localite, UnClub.Mon_Club));
                MessageBox.Show("Club ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                new G_T_Club(chConnexion).Modifier(UnClub.ID_Club, UnClub.Nom, UnClub.Rue, UnClub.Numero, UnClub.Code_Postal, UnClub.Localite, UnClub.Mon_Club);
                BcpClubs[nAjout] = new C_T_Club(UnClub.ID_Club, UnClub.Nom, UnClub.Rue, UnClub.Numero, UnClub.Code_Postal, UnClub.Localite, UnClub.Mon_Club);
                MessageBox.Show("Club modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        { 
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UnClub = new VM_UnClub();
            nAjout = -1;
            ActiverUneFiche = true;
            ActiverUneFiche2 = true;
        }

        public void Modifier()
        {
            if (ClubSelectionnee != null)
            {
                C_T_Club Tmp = new G_T_Club(chConnexion).Lire_ID(ClubSelectionnee.ID_Club);
                UnClub = new VM_UnClub();
                UnClub.ID_Club = Tmp.ID_Club;
                UnClub.Nom = Tmp.Nom;
                UnClub.Rue = Tmp.Rue;
                UnClub.Numero = Tmp.Numero;
                UnClub.Code_Postal = Tmp.Code_Postal;
                UnClub.Localite = Tmp.Localite;
                UnClub.Mon_Club = Tmp.Mon_Club;
                nAjout = BcpClubs.IndexOf(ClubSelectionnee);
                ActiverUneFiche = true;
            }
        }

        public void Supprimer()
        {
            if (ClubSelectionnee != null)
            {
                new G_T_Club(chConnexion).Supprimer(ClubSelectionnee.ID_Club);
                BcpClubs.Remove(ClubSelectionnee);
                MessageBox.Show("Club supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        public void EssaiSelMult(object lListe)
        {
            System.Collections.IList lTmp = (System.Collections.IList)lListe;
            foreach (C_T_Club p in lTmp)
            { string s = p.Nom; }
            int nTmp = lTmp.Count;
        }

        public void ClubSelectionnee2UneClub()
        {
            UnClub.ID_Club = ClubSelectionnee.ID_Club;
            UnClub.Nom = ClubSelectionnee.Nom;
            UnClub.Rue = ClubSelectionnee.Rue;
            UnClub.Numero = ClubSelectionnee.Numero;
            UnClub.Code_Postal = ClubSelectionnee.Code_Postal;
            UnClub.Localite = ClubSelectionnee.Localite;
            UnClub.Mon_Club = ClubSelectionnee.Mon_Club;
        }
    }

    public class VM_UnClub : BasePropriete
    {
        private int _ID_Club, _Numero, _Code_Postal;
        private string _Nom, _Rue, _Localite, _Mon_Club;

        public int ID_Club
        {
            get { return _ID_Club; }
            set { AssignerChamp<int>(ref _ID_Club, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int Numero
        {
            get { return _Numero; }
            set { AssignerChamp<int>(ref _Numero, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int Code_Postal
        {
            get { return _Code_Postal; }
            set { AssignerChamp<int>(ref _Code_Postal, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Nom
        {
            get { return _Nom; }
            set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Rue
        {
            get { return _Rue; }
            set { AssignerChamp<string>(ref _Rue, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Localite
        {
            get { return _Localite; }
            set { AssignerChamp<string>(ref _Localite, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Mon_Club
        {
            get { return _Mon_Club; }
            set { AssignerChamp<string>(ref _Mon_Club, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
}

