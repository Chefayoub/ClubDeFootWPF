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
    class VM_Accueil : BasePropriete
    {
        //@"Data Source=MSI\SQLEXPRESS;AttachDbFilename=D:\BD_ClubDeFootball\BD_ClubDeSport.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        private string chConnexion = ConfigurationManager.ConnectionStrings["ClubDeFootWPF.Properties.Settings.BDConnexion"].ConnectionString;
        private bool _ActiverUneFiche;

        public VM_Accueil()
        {
            //Equipe
            UneEquipe = new VM_UneEquipe();
            BcpEquipes = ChargerEquipes(chConnexion);
            //Membre
            UnMembre = new VM_UnMembre();
            BcpMembres = ChargerMembres(chConnexion);
            //Entrainement
            UnEntrainement = new VM_UnEntrainement();
            BcpEntrainements = ChargerEntrainements(chConnexion);
            //Match
            UnMatch = new VM_UnMatch();
            BcpMatchs = ChargerMatchs(chConnexion);
            //Terrain
            UnTerrain = new VM_UnTerrain();
            BcpTerrains = ChargerTerrains(chConnexion);
            ActiverUneFiche = false;
        }
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

        #region EQUIPE
        private C_T_Equipe _EquipeSelectionnee;
        public C_T_Equipe EquipeSelectionnee
        {
            get { return _EquipeSelectionnee; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private VM_UneEquipe _UneEquipe;
        public VM_UneEquipe UneEquipe
        {
            get { return _UneEquipe; }
            set { AssignerChamp<VM_UneEquipe>(ref _UneEquipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Equipe> _BcpEquipes = new ObservableCollection<C_T_Equipe>();
        public ObservableCollection<C_T_Equipe> BcpEquipes
        {
            get { return _BcpEquipes; }
            set { _BcpEquipes = value; }
        }

        private ObservableCollection<C_T_Equipe> ChargerEquipes(string chConn)
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConn).Lire("ID_Equipe");
            foreach (C_T_Equipe Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void EquipeSelectionnee2UneEquipe()
        {
            UneEquipe.ID_Equipe = EquipeSelectionnee.ID_Equipe;
            UneEquipe.ID_Club = EquipeSelectionnee.ID_Club;
            UneEquipe.Nom = EquipeSelectionnee.Nom;
        }
        public class VM_UneEquipe : BasePropriete
        {
            private int _ID_Equipe, _ID_Club;
            private string _Nom;

            public int ID_Equipe
            {
                get { return _ID_Equipe; }
                set { AssignerChamp<int>(ref _ID_Equipe, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int ID_Club
            {
                get { return _ID_Club; }
                set { AssignerChamp<int>(ref _ID_Club, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string Nom
            {
                get { return _Nom; }
                set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
        #endregion

        #region MEMBRE
        private C_T_Membre _MembreSelectionnee;
        public C_T_Membre MembreSelectionnee
        {
            get { return _MembreSelectionnee; }
            set { AssignerChamp<C_T_Membre>(ref _MembreSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnMembre _UnMembre;
        public VM_UnMembre UnMembre
        {
            get { return _UnMembre; }
            set { AssignerChamp<VM_UnMembre>(ref _UnMembre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Membre> _BcpMembres = new ObservableCollection<C_T_Membre>();
        public ObservableCollection<C_T_Membre> BcpMembres
        {
            get { return _BcpMembres; }
            set { _BcpMembres = value; }
        }

        private ObservableCollection<C_T_Membre> ChargerMembres(string chConn)
        {
            ObservableCollection<C_T_Membre> rep = new ObservableCollection<C_T_Membre>();
            List<C_T_Membre> lTmp = new G_T_Membre(chConn).Lire("ID_Membre");
            foreach (C_T_Membre Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void MembreSelectionnee2UneMembre()
        {
            UnMembre.ID_Membre = MembreSelectionnee.ID_Membre;
            UnMembre.ID_Equipe = MembreSelectionnee.ID_Equipe;
            UnMembre.Nom = MembreSelectionnee.Nom;
            UnMembre.Prenom = MembreSelectionnee.Prenom;
            UnMembre.Email = MembreSelectionnee.Email;
            UnMembre.NumeroTel = MembreSelectionnee.NumeroTel;
            UnMembre.DateDeNaissance = MembreSelectionnee.DateDeNaissance;
        }

        public class VM_UnMembre : BasePropriete
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
        #endregion

        #region Entrainement
        private C_T_Entrainement _EntrainementSelectionnee;
        public C_T_Entrainement EntrainementSelectionnee
        {
            get { return _EntrainementSelectionnee; }
            set { AssignerChamp<C_T_Entrainement>(ref _EntrainementSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
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
        private ObservableCollection<C_T_Entrainement> ChargerEntrainements(string chConn)
        {
            ObservableCollection<C_T_Entrainement> rep = new ObservableCollection<C_T_Entrainement>();
            List<C_T_Entrainement> lTmp = new G_T_Entrainement(chConn).Lire("ID_Entrainement");
            foreach (C_T_Entrainement Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void EntrainementSelectionnee2UneEntrainement()
        {
            UnEntrainement.ID_Entrainement = EntrainementSelectionnee.ID_Entrainement;
            UnEntrainement.ID_Terrain = (int)EntrainementSelectionnee.ID_Terrain;
            UnEntrainement.ID_Equipe = (int)EntrainementSelectionnee.ID_Equipe;
            UnEntrainement.DateE = EntrainementSelectionnee.DateE;
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
        #endregion

        #region MATCH
        private C_T_Match _MatchSelectionnee;
        public C_T_Match MatchSelectionnee
        {
            get { return _MatchSelectionnee; }
            set { AssignerChamp<C_T_Match>(ref _MatchSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private VM_UnMatch _UnMatch;
        public VM_UnMatch UnMatch
        {
            get { return _UnMatch; }
            set { AssignerChamp<VM_UnMatch>(ref _UnMatch, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Match> _BcpMatchs = new ObservableCollection<C_T_Match>();
        public ObservableCollection<C_T_Match> BcpMatchs
        {
            get { return _BcpMatchs; }
            set { _BcpMatchs = value; }
        }
        private ObservableCollection<C_T_Match> ChargerMatchs(string chConn)
        {
            ObservableCollection<C_T_Match> rep = new ObservableCollection<C_T_Match>();
            List<C_T_Match> lTmp = new G_T_Match(chConn).Lire("ID_Match");
            foreach (C_T_Match Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public class VM_UnMatch : BasePropriete
        {
            private int _ID_Match, _ID_Domicile, _ID_Deplacement, _ID_Terrain, _Score_Domicile, _Score_Adversaire;
            private DateTime _DateM;

            public int ID_Match
            {
                get { return _ID_Match; }
                set { AssignerChamp<int>(ref _ID_Match, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int ID_Domicile
            {
                get { return _ID_Domicile; }
                set { AssignerChamp<int>(ref _ID_Domicile, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int ID_Deplacement
            {
                get { return _ID_Deplacement; }
                set { AssignerChamp<int>(ref _ID_Deplacement, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int ID_Terrain
            {
                get { return _ID_Terrain; }
                set { AssignerChamp<int>(ref _ID_Terrain, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int Score_Domicile
            {
                get { return _Score_Domicile; }
                set { AssignerChamp<int>(ref _Score_Domicile, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public int Score_Adversaire
            {
                get { return _Score_Adversaire; }
                set { AssignerChamp<int>(ref _Score_Adversaire, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public DateTime DateM
            {
                get { return _DateM; }
                set { AssignerChamp<DateTime>(ref _DateM, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }
        }
        #endregion

        #region Terrain
        private C_T_Terrain _TerrainSelectionnee;
        public C_T_Terrain TerrainSelectionnee
        {
            get { return _TerrainSelectionnee; }
            set { AssignerChamp<C_T_Terrain>(ref _TerrainSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private VM_UnTerrain _UnTerrain;
        public VM_UnTerrain UnTerrain
        {
            get { return _UnTerrain; }
            set { AssignerChamp<VM_UnTerrain>(ref _UnTerrain, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_T_Terrain> _BcpTerrains = new ObservableCollection<C_T_Terrain>();
        public ObservableCollection<C_T_Terrain> BcpTerrains
        {
            get { return _BcpTerrains; }
            set { _BcpTerrains = value; }
        }
        private ObservableCollection<C_T_Terrain> ChargerTerrains(string chConn)
        {
            ObservableCollection<C_T_Terrain> rep = new ObservableCollection<C_T_Terrain>();
            List<C_T_Terrain> lTmp = new G_T_Terrain(chConn).Lire("ID_Terrain");
            foreach (C_T_Terrain Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public class VM_UnTerrain : BasePropriete
        {
            private int _ID_Terrain;
            private string _Nom;

            public int ID_Terrain
            {
                get { return _ID_Terrain; }
                set { AssignerChamp<int>(ref _ID_Terrain, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

            public string Nom
            {
                get { return _Nom; }
                set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            }

        }
        #endregion
    }
}
