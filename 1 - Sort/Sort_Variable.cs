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

namespace Sort_Variable
{
    public class Base
    {
        public event EventSortEventHandler EventSort;

        public delegate void EventSortEventHandler(string choix, object value);

        private Dictionary<int, Information> _Sort = new Dictionary<int, Information>();


        public object Sort
        {
            get
            {
                if (IdUnique == -1)
                    return _Sort;
                else
                    return _Sort[IdUnique];
            }
        }


        public Information Ajoute
        {
            set
            {
                _Sort.Add(value.ID, value);
                EventSort?.Invoke("Ajoute", value);
            }
        }


        public Information Modifie
        {
            set
            {
                _Sort[value.ID] = value;
                EventSort?.Invoke("Modifie", value);
            }
        }


        private int _capital = 0;
        public int Capital
        {
            get
            {
                return _capital;
            }

            set
            {
                _capital = value;
                EventSort?.Invoke("Capital", value);
            }
        }


        public void Reset()
        {
            _Sort = new Dictionary<int, Information>();
        }
    }

    public class Information
    {
        public int ID = -1;
        public int Niveau = -1;
        public string Nom = "";
        public MinMax PO = new MinMax();

        public int PA = -1;
        public int NombreLancerParTour = -1;
        public int NombreLancerParTourParJoueur = -1;
        public int NombreToursEntreDeuxLancers = -1;
        public bool POModifiable = false;
        public bool LigneDeVue = false;
        public bool LancerEnLigne = false;
        public bool CelluleLibre = false;
        public bool ECFiniTour = false;
        public MinMax Zone = new MinMax();
        public string ZoneEffet = "";
        public int NiveauRequisUp = -1;
        public string SortClasse = "";
        public string Definition = "";
        public string BarreSort = "";
    }
}
