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

namespace Dragodinde_Variable
{
    public class Base
    {
        public bool Monter = false;
        public int Xp = -1;
        public bool Inventaire = false;
        public Dictionary<int, Information> Enclos = new Dictionary<int, Information>();
        public Dictionary<int, Information> Etable = new Dictionary<int, Information>();
        public Information Equiper = new Information();
        public Information Information = new Information();
    }

    public class Information
    {
        public MinMax Pods = new MinMax();

        public MinMax Experience = new MinMax();

        public Capaciter Capacite = new Capaciter();

        public int IdUnique = -1;
        public int ID = -1;
        public string ArbreGenealogique = "";
        public string Nom = "";
        public string Type = "";
        public string Sexe = "";
        public int Niveau = -1;
        public bool Montable = false;

        public Etat Etat = new Etat();
        public Fecondation Fecondation = new Fecondation();

        public MinMax Endurance = new MinMax();
        public MinMax Maturite = new MinMax();
        public MinMax Amour = new MinMax();
        public MinMax Energie = new MinMax();
        public MinMax Fatigue = new MinMax();
        public MinMax Reproduction = new MinMax();

        public Item_Variable.Caracteristique Caracteristique = new Item_Variable.Caracteristique();
    }

    public class Capaciter
    {
        public string Primaire = "";
        public string Secondaire = "";
    }

    public class Etat
    {
        public int Agressiviter = -1;
        public int Equilibrer = -1;
        public int Sereniter = -1;
    }

    public class Fecondation
    {
        public int Heure = -1;
        public bool Fecondable = false;
    }
}
