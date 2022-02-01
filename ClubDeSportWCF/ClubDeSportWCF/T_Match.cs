using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClubDeSportWCF
{
    [DataContract]
    public class T_Match
    {
        private int _ID_Match, _CarteJaune_Domicile, _CarteRouge_Domicile, _CarteJaune_Adversaire, _CarteRouge_Adversaire;
        DateTime _DateM;

        [DataMember]
        public int ID_Match
        {
            get { return _ID_Match; }
            set { _ID_Match = value; }
        }

        [DataMember]
        public int CarteJaune_Domicile
        {
            get { return _CarteJaune_Domicile; }
            set { _CarteJaune_Domicile = value; }
        }

        [DataMember]
        public int CarteRouge_Domicile
        {
            get { return _CarteRouge_Domicile; }
            set { _CarteRouge_Domicile = value; }
        }

        [DataMember]
        public int CarteJaune_Adversaire
        {
            get { return _CarteJaune_Adversaire; }
            set { _CarteJaune_Adversaire = value; }
        }

        [DataMember]
        public int CarteRouge_Adversaire
        {
            get { return _CarteRouge_Adversaire; }
            set { _CarteRouge_Adversaire = value; }
        }

        [DataMember]
        public DateTime DateM
        {
            get { return _DateM; }
            set { _DateM = value; }
        }
    }
}
