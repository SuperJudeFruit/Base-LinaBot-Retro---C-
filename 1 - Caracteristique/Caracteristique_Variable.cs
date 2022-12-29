namespace Caracteristique_Variable
{
    public class Base
    {
        public event EventCaracteristiqueEventHandler EventCaracteristique;

        public delegate void EventCaracteristiqueEventHandler(string Choix, object value);

        private Caracteristiques _Avancee = new Caracteristiques();
        public Caracteristiques Avancee
        {
            get
            {
                return _Avancee;
            }

            set
            {
                _Avancee = value;
                EventCaracteristique?.Invoke("Avancee", _Avancee);
            }
        }


        private int _Capital = 0;
        public int Capital
        {
            get
            {
                return _Capital;
            }

            set
            {
                _Capital = value;
                EventCaracteristique?.Invoke("Capital", _Capital);
            }
        }
    }

    public class Caracteristiques
    {
        public Primaire Primaire = new Primaire();

        public Bonus Bonus = new Bonus();

        public Esquive Esquive = new Esquive();

        public Resistance Resistance = new Resistance();
    }

    public class Primaire
    {
        public Statistique Vitalite = new Statistique();
        public Statistique Sagesse = new Statistique();
        public Statistique Force = new Statistique();
        public Statistique Intelligence = new Statistique();
        public Statistique Chance = new Statistique();
        public Statistique Agilite = new Statistique();
        public Statistique PA = new Statistique();
        public Statistique PM = new Statistique();
        public Statistique Initiative = new Statistique();
        public Statistique Prospection = new Statistique();
        public Statistique Portee = new Statistique();
        public Statistique Maximum_De_Creatures_Invocables = new Statistique();
    }

    public class Bonus
    {
        public Statistique Degats = new Statistique();
        public Statistique Degats_Physiques = new Statistique();
        public Statistique Maitrise_Arme = new Statistique();
        public Statistique Dommages_PR = new Statistique();
        public Statistique Pieges = new Statistique();
        public Statistique Pieges_PR = new Statistique();
        public Statistique Soins = new Statistique();
        public Statistique Renvoi_De_Dommages = new Statistique();
        public Statistique Coups_Critiques = new Statistique();
        public Statistique Echecs_Critiques = new Statistique();
    }

    public class Esquive
    {
        public Statistique PA = new Statistique();
        public Statistique PM = new Statistique();
    }

    public class Statistique
    {
        public string Base = "";
        public string Equipement = "";
        public string Dons = "";
        public string Boost = "";
        public string Total = "";
    }



    public class Resistance
    {
        public Combat Combat = new Combat();
        public PvP PvP = new PvP();
    }

    public class PvP
    {
        public Fixe_Pr Neutre = new Fixe_Pr();
        public Fixe_Pr Terre = new Fixe_Pr();
        public Fixe_Pr Feu = new Fixe_Pr();
        public Fixe_Pr Eau = new Fixe_Pr();
        public Fixe_Pr Air = new Fixe_Pr();
    }

    public class Combat
    {
        public Fixe_Pr Neutre = new Fixe_Pr();
        public Fixe_Pr Terre = new Fixe_Pr();
        public Fixe_Pr Feu = new Fixe_Pr();
        public Fixe_Pr Eau = new Fixe_Pr();
        public Fixe_Pr Air = new Fixe_Pr();
    }

    public class Fixe_Pr
    {
        public Statistique Pourcentage = new Statistique();
        public Statistique Fixe = new Statistique();
    }
}
