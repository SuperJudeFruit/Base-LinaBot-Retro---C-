using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Map_Variable
{
    public class Base
    {
        public int Largeur;
        public int Hauteur;
        public Cell[] Handler = new Cell[1281];
        public string PathTotal;
        public int ID;
        public bool StopDeplacement;
        public int Haut, Bas, Gauche, Droite;
        public bool Deplacement;
        public string Coordonnees;
        public bool Spectateur;
        public Dictionary<int, Entite> Entite = new Dictionary<int, Entite>();
        public Dictionary<int, Objet> Objet = new Dictionary<int, Objet>();
        public Dictionary<int, Interaction_Variable.Base> Interaction = new Dictionary<int, Interaction_Variable.Base>();
        public System.Threading.ManualResetEvent Bloque = new System.Threading.ManualResetEvent(false);
    }

    public class Objet
    {
        public int Cellule;
        public int Id;
        public int IdUnique;
        public string Nom;
        public MinMax Resistance = new MinMax();
    }

    public class Entite
    {
        public int Categorie;
        public int IDUnique;
        public int Cellule;
        public string Nom;
        public string Niveau;
        public string ID;
        public int Etoile;
        public string Classe;
        public string Sexe;
        public string Guilde;
        public bool ModeMarchand;
        public string Alignement;
        public bool Orientation;
        public bool Assis;
        public Equipement Equipement = new Equipement();
    }

    public class Equipement
    {
        public Information Chapeau = new Information();
        public Information Cape = new Information();
        public int Cac, Familier, Bouclier;
    }

    public class Information
    {
        public int ID;
        public int Niveau;
        public int Forme;
    }
}
