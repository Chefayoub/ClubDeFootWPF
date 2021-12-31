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
    class VM_Equipe : BasePropriete
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
        private C_T_Equipe _EquipeSelectionnee;
        public C_T_Equipe EquipeSelectionnee
        {
            get { return _EquipeSelectionnee; }
            set { AssignerChamp<C_T_Equipe>(ref _EquipeSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
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
        #endregion

        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        //public BaseCommande cEssaiSelMult { get; set; }
        #endregion

        public VM_Equipe()
        {
            UneEquipe = new VM_UneEquipe();
            BcpEquipes = ChargerEquipes(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            //cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Equipe> ChargerEquipes(string chConn)
        {
            ObservableCollection<C_T_Equipe> rep = new ObservableCollection<C_T_Equipe>();
            List<C_T_Equipe> lTmp = new G_T_Equipe(chConn).Lire("ID_Equipe");
            foreach (C_T_Equipe Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UneEquipe.ID_Equipe = new G_T_Equipe(chConnexion).Ajouter(UneEquipe.Nom, UneEquipe.ID_Club);
                BcpEquipes.Add(new C_T_Equipe(UneEquipe.ID_Equipe, UneEquipe.Nom, UneEquipe.ID_Club));
                MessageBox.Show("Equipe ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                new G_T_Equipe(chConnexion).Modifier(UneEquipe.ID_Equipe, UneEquipe.Nom, UneEquipe.ID_Club);
                BcpEquipes[nAjout] = new C_T_Equipe(UneEquipe.ID_Equipe, UneEquipe.Nom, UneEquipe.ID_Club);
                MessageBox.Show("Equipe modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UneEquipe = new VM_UneEquipe();
            nAjout = -1;
            ActiverUneFiche = true;
        }

        public void Modifier()
        {
            if (EquipeSelectionnee != null)
            {
                C_T_Equipe Tmp = new G_T_Equipe(chConnexion).Lire_ID(EquipeSelectionnee.ID_Equipe);
                UneEquipe = new VM_UneEquipe();
                UneEquipe.ID_Equipe = Tmp.ID_Equipe;
                UneEquipe.ID_Club = Tmp.ID_Club;
                UneEquipe.Nom = Tmp.Nom;
                nAjout = BcpEquipes.IndexOf(EquipeSelectionnee);
                ActiverUneFiche = true;
            }
        }

        public void Supprimer()
        {
            if (EquipeSelectionnee != null)
            {
                new G_T_Equipe(chConnexion).Supprimer(EquipeSelectionnee.ID_Equipe);
                BcpEquipes.Remove(EquipeSelectionnee);
                MessageBox.Show("Equipe supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        //public void EssaiSelMult(object lListe)
        //{
        //    System.Collections.IList lTmp = (System.Collections.IList)lListe;
        //    foreach (C_T_Equipe p in lTmp)
        //    { string s = p.Nom; }
        //    int nTmp = lTmp.Count;
        //}

        public void EquipeSelectionnee2UneEquipe()
        {
            UneEquipe.ID_Equipe = EquipeSelectionnee.ID_Equipe;
            UneEquipe.ID_Club = EquipeSelectionnee.ID_Club;
            UneEquipe.Nom = EquipeSelectionnee.Nom;
        }
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
}
