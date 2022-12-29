using System;
using System.Collections.Generic;
using Dofus_RetroBot.Caracteristique_Variable;

namespace Item_Variable
{
    public class Base
    {
        public event EventItemEventHandler EventItem;

        public delegate void EventItemEventHandler(string Choix, object value);

        private Dictionary<int, Information> _Item = new Dictionary<int, Information>();

        public object Item
        {
            get
            {
                if (IdUnique == "")
                    return _Item;
                else
                    return _Item[IdUnique];
            }
        }

        public bool Existe(string ID)
        {
            return _Item.ContainsKey(ID);
        }

        public Information Ajoute
        {
            set
            {
                _Item.Add(value.IdUnique, value);
                EventItem?.Invoke("Ajoute", value);
            }
        }

        public int Supprimer
        {
            set
            {
                _Item.Remove(value);
                EventItem?.Invoke("Supprimer", value);
            }
        }

        public Information Modifie
        {
            set
            {
                _Item[value.IdUnique] = value;
                EventItem?.Invoke("Modifie", value);
            }
        }

        public void Reset()
        {
            _Item = new Dictionary<int, Information>();
        }
    }

    public class Information
    {
        public int IdObjet = 0;
        public int IdUnique = 0;
        public string Nom = "";
        public int Quantiter = 0;
        public Caracteristique Caracteristique = new Caracteristique();
        public string CaracteristiqueBrute = "";
        public string Equipement = "";
        public int Categorie = 0;
        public string Description = "";
    }

    public class Caracteristique
    {
        public Vole Vole = new Vole();

        public Dommage Dommage = new Dommage();

        public Fixe_Pr Piege = new Fixe_Pr();

        public Resistance Resistance = new Resistance();

        public Familier Familier = new Familier();

        public Dragodinde Dragodinde = new Dragodinde();

        public string PertePA = "0";
        public string Pdv = "0";
        public string Force = "0";
        public string Vitalite = "0";
        public string Sagesse = "0";
        public string Intelligence = "0";
        public string Chance = "0";
        public string Agilite = "0";
        public string PA = "0";
        public string PM = "0";
        public string PO = "0";
        public string Invocation = "0";
        public string Initiative = "0";
        public string Prospection = "0";
        public string Pods = "0";
        public string CC = "0";


        public string Soin = "0";

        public string Cac = "0";
        public List<string> PierreAme;
        public string Puissance = "0";

        public string ResistanceItem = "0";

        public string Etheree = "0";
        public string TourRestant = 0;
    }

    public class Vole
    {
        public string Eau = "0";
        public string Feu = "0";
        public string Terre = "0";
        public string Air = "0";
        public string Neutre = "0";
    }

    public class Dommage
    {
        public string Eau = "0";
        public string Feu = "0";
        public string Terre = "0";
        public string Air = "0";
        public string Neutre = "0";
        public Fixe_Pr Physique = new Fixe_Pr();
    }

    public class Resistance
    {
        public Fixe_Pr Neutre = new Fixe_Pr();
        public Fixe_Pr Terre = new Fixe_Pr();
        public Fixe_Pr Eau = new Fixe_Pr();
        public Fixe_Pr Feu = new Fixe_Pr();
        public Fixe_Pr Air = new Fixe_Pr();
    }

    public class Fixe_Pr
    {
        public int Pourcentage = new int();
        public int Fixe = new int();
    }

    public class Dragodinde
    {
        public string Date = "";
        public string IdUnique = "";
        public string Possesseur = "";
        public string Nom = "";
        public DateTime Parchemin = DateTime.TimeOfDay;
    }

    public class Familier
    {
        public string Pdv = "0";
        public int Repas = 0;
        public string Corpulence = "Normal";
        public string Repas_Dernier = "Aliment Inconnu";
        public DateTime Repas_Date = DateTime.TimeOfDay;
        public DateTime Repas_Prochain = DateTime.TimeOfDay;
        public string Capacite_Accrue = "0";
    }

    public class Bonus
    {
        public int NumeroPanoplie = -1;
        public string[] IDObjet;
        public Caracteristique Caracteristique = new Caracteristique();
        public string CaracteristiqueBrute = "";
    }
}
