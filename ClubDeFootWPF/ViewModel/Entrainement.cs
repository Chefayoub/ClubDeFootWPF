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

    class VM_Entrainement : BasePropriete
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

        private C_T_Entrainement _EntrainementSelectionnee;
        public C_T_Entrainement EntrainementSelectionnee
        {
            get { return _EntrainementSelectionnee; }
            set { AssignerChamp<C_T_Entrainement>(ref _EntrainementSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
        private VM_UnEntrainement _UnEntrainement;
        public VM_UnEntrainement UnEntrainement
        {
            get { return _UnEntrainement; }
            set { AssignerChamp<VM_UnEntrainement>(ref _UnEntrainement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private ObservableCollection<C_T_Entrainement> _BcpEntrainements = new ObservableCollection<C_T_Entrainement>();
        public ObservableCollection<C_T_Entrainement> BcpEntrainements
        {
            get { return _BcpEntrainements; }
            set { _BcpEntrainements = value; }
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

        public VM_Entrainement()
        {
            UnEntrainement = new VM_UnEntrainement();
            //UneEntrainement.ID_Entrainement = 1;
            //UneEntrainement.ID_Terrain = 2;
            //UneEntrainement.ID_Equipe = 3;
            //UneEntrainement.Date = ;
            BcpEntrainements = ChargerEntrainements(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Entrainement> ChargerEntrainements(string chConn)
        {
            ObservableCollection<C_T_Entrainement> rep = new ObservableCollection<C_T_Entrainement>();
            List<C_T_Entrainement> lTmp = new G_T_Entrainement(chConn).Lire("ID_Entrainement");
            foreach (C_T_Entrainement Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnEntrainement.ID_Entrainement = new G_T_Entrainement(chConnexion).Ajouter(UnEntrainement.DateE, UnEntrainement.ID_Terrain, UnEntrainement.ID_Equipe);
                BcpEntrainements.Add(new C_T_Entrainement(UnEntrainement.ID_Entrainement, UnEntrainement.DateE, UnEntrainement.ID_Terrain, UnEntrainement.ID_Equipe));
            }
            else
            {
                new G_T_Entrainement(chConnexion).Modifier(UnEntrainement.ID_Entrainement, UnEntrainement.DateE, UnEntrainement.ID_Terrain, UnEntrainement.ID_Equipe);
                BcpEntrainements[nAjout] = new C_T_Entrainement(UnEntrainement.ID_Entrainement, UnEntrainement.DateE, UnEntrainement.ID_Terrain, UnEntrainement.ID_Equipe);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UnEntrainement = new VM_UnEntrainement();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (EntrainementSelectionnee != null)
            {
                C_T_Entrainement Tmp = new G_T_Entrainement(chConnexion).Lire_ID(EntrainementSelectionnee.ID_Entrainement);
                UnEntrainement = new VM_UnEntrainement();
                UnEntrainement.ID_Entrainement = Tmp.ID_Entrainement;
                UnEntrainement.ID_Terrain = (int)Tmp.ID_Terrain;
                UnEntrainement.ID_Equipe = (int)Tmp.ID_Equipe;
                UnEntrainement.DateE = Tmp.DateE;

                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (EntrainementSelectionnee != null)
            {
                new G_T_Entrainement(chConnexion).Supprimer(EntrainementSelectionnee.ID_Entrainement);
                BcpEntrainements.Remove(EntrainementSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            System.Collections.IList lTmp = (System.Collections.IList)lListe;
            foreach (C_T_Entrainement p in lTmp)
            { int s = p.ID_Entrainement; }
            int nTmp = lTmp.Count;
        }
        public void EntrainementSelectionnee2UneEntrainement()
        {
            UnEntrainement.ID_Entrainement = EntrainementSelectionnee.ID_Entrainement;
            UnEntrainement.ID_Terrain = (int)EntrainementSelectionnee.ID_Terrain;
            UnEntrainement.ID_Equipe = (int)EntrainementSelectionnee.ID_Equipe;
            UnEntrainement.DateE = EntrainementSelectionnee.DateE;
        }
    }
    public class VM_UnEntrainement : BasePropriete
    {
        private int _ID_Entrainement, _ID_Terrain, _ID_Equipe;
        private DateTime _DateE;

        public int ID_Entrainement
        {
            get { return _ID_Entrainement; }
            set { AssignerChamp<int>(ref _ID_Entrainement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Terrain
        {
            get { return _ID_Terrain; }
            set { AssignerChamp<int>(ref _ID_Terrain, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int ID_Equipe
        {
            get { return _ID_Equipe; }
            set { AssignerChamp<int>(ref _ID_Equipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public DateTime DateE
        {
            get { return _DateE; }
            set { AssignerChamp<DateTime>(ref _DateE, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
    }
}
