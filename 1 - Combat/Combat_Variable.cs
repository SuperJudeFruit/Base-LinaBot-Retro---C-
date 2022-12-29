using System.Collections.Generic;

namespace Combat_Variable
{
    public class Base
    {
        public bool Preparation = false;
        public bool Placement = false;
        public bool Combat = false;
        public bool Defi = false;

        public bool Spectateur = false;
        public bool Cadenas = false;
        public bool Aide = false;
        public bool Groupe = false;

        public bool MonTour = false;
        public bool Echec = false;
        public int Pause = -1;

        public Dictionary<int, List<Lancer>> Lancer = new Dictionary<int, List<Lancer>>();
        public Dictionary<int, Entite> Entite = new Dictionary<int, Entite>();
        public Dictionary<int, Challenge> Challenge = new Dictionary<int, Challenge>();
        public Dictionary<int, List<int>> Placement_Cellule = new Dictionary<int, List<int>>();
    }

    public class Lancer
    {
        public int idUnique = -1;
        public string IdNom = "";
        public int Niveau = -1;
    }

    public class Challenge
    {
        public int ID = -1;
        public string Nom = "";
        public bool Rate = false;
        public int Xp = -1;
        public int Xp_Groupe = -1;
        public int Butin = -1;
        public int Butin_Groupe = -1;
    }

    public class Entite
    {
        public bool Pret = false;
        public int OrdreTour = -1;
        public bool Vivant = false;
        public int Vitalite = -1;
        public int PA = -1;
        public int PM = -1;

        public Resistance Resistance = new Resistance();

        public Esquive Esquive = new Esquive();

        public int NumeroTour = -1;
        public string Etat = "";
        public int Equipe = -1;
    }

    public class Esquive
    {
        public int PA = 0;
        public int PM = 0;
    }

    public class Resistance
    {
        public int Eau = 0;
        public int Feu = 0;
        public int Terre = 0;
        public int Air = 0;
        public int Neutre = 0;
    }

    public class Drop
    {
        public int Kamas = -1;
        public int Gagne = -1;
        public int Perdu = -1;
        public Dictionary<int, int> Item = new Dictionary<int, int>();
    }
}
