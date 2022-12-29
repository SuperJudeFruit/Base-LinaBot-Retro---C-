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

namespace Pnj_Variable
{
    public class Base
    {
        public bool Parler, Acheter, Vendre, AcheterVendre, Echange;
        public List<int> Reponse = new List<int>();
        public int IdReponse;
        public HotelDeVente Hdv_Acheter = new HotelDeVente();
        public HotelDeVente Hdv_Vendre = new HotelDeVente();
        public Dictionary<int, Acheter_Vendre> AcheterVendre_Item = new Dictionary<int, Acheter_Vendre>();
    }

    public class Acheter_Vendre
    {
        public int ID;
        public Item_Variable.Caracteristique Caracteristique = new Item_Variable.Caracteristique();
        public string CaracteristiqueBrute;
        public int Prix;
    }

    public class HotelDeVente
    {
        public Quantiter Quantiter = new Quantiter();
        public Liste Liste = new Liste();
        public int Taxe;
        public int NiveauMax;
        public int StockEnMagasin;
        public int HeureMax;
        public int PrixMoyen;
    }

    public class Liste
    {
        public Dictionary<int, Item> Item = new Dictionary<int, Item>();
        public List<int> Categorie = new List<int>();
        public List<int> ID = new List<int>();
    }

    public class Quantiter
    {
        public bool x1 = false;
        public bool x10 = false;
        public bool x100 = false;
    }

    public class Prix
    {
        public int Actuelle = 0;
        public int x1 = 0;
        public int x10 = 0;
        public int x100 = 0;
    }

    public class Item
    {
        public int IDUnique;
        public string Nom;
        public Item_Variable.Caracteristique Caracteristique = new Item_Variable.Caracteristique();
        public Prix Prix = new Prix();
        public int IdObjet;
        public int TempsRestant;
        public int Quantiter;
    }
}
