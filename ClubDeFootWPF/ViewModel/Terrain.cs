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
    class VM_Terrain : BasePropriete
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
        private C_T_Terrain _TerrainSelectionnee;
        public C_T_Terrain TerrainSelectionnee
        {
            get { return _TerrainSelectionnee; }
            set { AssignerChamp<C_T_Terrain>(ref _TerrainSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion

        #region Données extérieures
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
        #endregion

        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cEssaiSelMult { get; set; }
        #endregion

        public VM_Terrain()
        {
            UnTerrain = new VM_UnTerrain();
            BcpTerrains = ChargerTerrains(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }

        private ObservableCollection<C_T_Terrain> ChargerTerrains(string chConn)
        {
            ObservableCollection<C_T_Terrain> rep = new ObservableCollection<C_T_Terrain>();
            List<C_T_Terrain> lTmp = new G_T_Terrain(chConn).Lire("ID_Terrain");
            foreach (C_T_Terrain Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }

        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnTerrain.ID_Terrain = new G_T_Terrain(chConnexion).Ajouter(UnTerrain.Nom);
                BcpTerrains.Add(new C_T_Terrain(UnTerrain.ID_Terrain, UnTerrain.Nom));
                MessageBox.Show("Terrain ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                new G_T_Terrain(chConnexion).Modifier(UnTerrain.ID_Terrain, UnTerrain.Nom);
                BcpTerrains[nAjout] = new C_T_Terrain(UnTerrain.ID_Terrain, UnTerrain.Nom);
                MessageBox.Show("Terrain modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            ActiverUneFiche = false;
        }

        public void Annuler()
        {
            ActiverUneFiche = false;
        }

        public void Ajouter()
        {
            UnTerrain = new VM_UnTerrain();
            nAjout = -1;
            ActiverUneFiche = true;
            ActiverUneFiche2 = true;
        }

        public void Modifier()
        {
            if (TerrainSelectionnee != null)
            {
                C_T_Terrain Tmp = new G_T_Terrain(chConnexion).Lire_ID(TerrainSelectionnee.ID_Terrain);
                UnTerrain = new VM_UnTerrain();
                UnTerrain.ID_Terrain = Tmp.ID_Terrain;
                UnTerrain.Nom = Tmp.Nom;
                nAjout = BcpTerrains.IndexOf(TerrainSelectionnee);
                ActiverUneFiche = true;
            }
        }

        public void Supprimer()
        {
            if (TerrainSelectionnee != null)
            {
                new G_T_Terrain(chConnexion).Supprimer(TerrainSelectionnee.ID_Terrain);
                BcpTerrains.Remove(TerrainSelectionnee);
                MessageBox.Show("Terrain supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        public void EssaiSelMult(object lListe)
        {
            System.Collections.IList lTmp = (System.Collections.IList)lListe;
            foreach (C_T_Terrain p in lTmp)
            { string s = p.Nom; }
            int nTmp = lTmp.Count;
        }

        public void TerrainSelectionnee2UneTerrain()
        {
            UnTerrain.ID_Terrain = TerrainSelectionnee.ID_Terrain;
            UnTerrain.Nom = TerrainSelectionnee.Nom;
        }
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
}
