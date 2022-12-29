using System.Collections.Generic;

namespace Maison_Variable
{
    public class Base
    {
        public bool Ouverture = false;
        public Maison Personnelle = new Maison();
        public Dictionary<string, Maison> Map = new Dictionary<string, Maison>();
    }

    public class Maison
    {
        public string Proprietaire = "";
        public int ID = -1;
        public bool Verouiller = false;
        public bool Vente = false;
        public bool Guilde = false;
        public string Nom_Guilde = "";
        public int Cellule = -1;
        public int MapID = -1;
        public string Coordonnees = "";
        public int Prix = -1;
        public int Code = -1;
        public Dictionary<string, Coffre> Coffre = new Dictionary<string, Coffre>();
    }

    public class Coffre
    {
        public bool Verouiller = false;
        public int Cellule = -1;
        public int MapID = -1;
        public string Coordonnees = "";
        public int Code = -1;
    }
}
