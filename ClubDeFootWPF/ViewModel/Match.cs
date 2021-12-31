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
    class VM_Match : BasePropriete
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
        private C_T_Match _MatchSelectionnee;
        public C_T_Match MatchSelectionnee
        {
            get { return _MatchSelectionnee; }
            set { AssignerChamp<C_T_Match>(ref _MatchSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
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
        #endregion

        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cEssaiSelMult { get; set; }
        #endregion

        public VM_Match()
        {
            UnMatch = new VM_UnMatch();
            BcpMatchs = ChargerMatchs(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Match> ChargerMatchs(string chConn)
        {
            ObservableCollection<C_T_Match> rep = new ObservableCollection<C_T_Match>();
            List<C_T_Match> lTmp = new G_T_Match(chConn).Lire("ID_Match");
            foreach (C_T_Match Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnMatch.ID_Match = new G_T_Match(chConnexion).Ajouter(UnMatch.Score_Domicile, UnMatch.Score_Adversaire, UnMatch.DateM, UnMatch.ID_Domicile, UnMatch.ID_Deplacement, UnMatch.ID_Terrain);
                BcpMatchs.Add(new C_T_Match(UnMatch.ID_Match, UnMatch.Score_Domicile, UnMatch.Score_Adversaire, UnMatch.DateM, UnMatch.ID_Domicile, UnMatch.ID_Deplacement, UnMatch.ID_Terrain));
                MessageBox.Show("Match ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                new G_T_Match(chConnexion).Modifier(UnMatch.ID_Match, UnMatch.Score_Domicile, UnMatch.Score_Adversaire, UnMatch.DateM, UnMatch.ID_Domicile, UnMatch.ID_Deplacement, UnMatch.ID_Terrain);
                BcpMatchs[nAjout] = new C_T_Match(UnMatch.ID_Match, UnMatch.Score_Domicile, UnMatch.Score_Adversaire, UnMatch.DateM, UnMatch.ID_Domicile, UnMatch.ID_Deplacement, UnMatch.ID_Terrain);
                MessageBox.Show("Match modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UnMatch = new VM_UnMatch();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (MatchSelectionnee != null)
            {
                C_T_Match Tmp = new G_T_Match(chConnexion).Lire_ID(MatchSelectionnee.ID_Match);
                UnMatch = new VM_UnMatch();
                UnMatch.ID_Match = Tmp.ID_Match;
                UnMatch.ID_Domicile = Tmp.ID_Domicile;
                UnMatch.ID_Deplacement = Tmp.ID_Deplacement;
                UnMatch.ID_Terrain = Tmp.ID_Terrain;
                UnMatch.Score_Domicile = (int)Tmp.Score_Domicile;
                UnMatch.Score_Adversaire = (int)Tmp.Score_Adversaire;
                UnMatch.DateM = Tmp.DateM;
                nAjout = BcpMatchs.IndexOf(MatchSelectionnee);
                ActiverUneFiche = true;
            }
        }

        public void Supprimer()
        {
            if (MatchSelectionnee != null)
            {
                new G_T_Match(chConnexion).Supprimer(MatchSelectionnee.ID_Match);
                BcpMatchs.Remove(MatchSelectionnee);
                MessageBox.Show("Match supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        public void EssaiSelMult(object lListe)
        {
            System.Collections.IList lTmp = (System.Collections.IList)lListe;
            foreach (C_T_Match p in lTmp)
            { int s = p.ID_Match; }
            int nTmp = lTmp.Count;
        }

        public void MatchSelectionnee2UneMatch()
        {
            UnMatch.ID_Match = MatchSelectionnee.ID_Match;
            UnMatch.ID_Domicile = MatchSelectionnee.ID_Domicile;
            UnMatch.ID_Deplacement = MatchSelectionnee.ID_Deplacement;
            UnMatch.ID_Terrain = MatchSelectionnee.ID_Terrain;
            UnMatch.Score_Domicile = (int)MatchSelectionnee.Score_Domicile;
            UnMatch.Score_Adversaire = (int)MatchSelectionnee.Score_Adversaire;
            UnMatch.DateM = MatchSelectionnee.DateM;
        }
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
}
