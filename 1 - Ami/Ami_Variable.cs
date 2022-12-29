using System.Collections.Generic;

namespace Ami_Variable
{
    public class Base
    {
        public event EventAmiEventHandler EventAmi;

        public delegate void EventAmiEventHandler(string choix, object value);

        private Dictionary<string, Information> _Personnage = new Dictionary<string, Information>();
        public Dictionary<string, Information> Liste
        {
            get
            {
                return _Personnage;
            }
        }

        public Information Ajoute
        {
            set
            {
                if (_Personnage.ContainsKey(value.Pseudo))
                    _Personnage[value.Pseudo] = value;
                else
                    _Personnage.Add(value.Pseudo, value);

                EventAmi?.Invoke("Ajoute", value);
            }
        }

        private bool _Averti = false;
        public bool Averti
        {
            get
            {
                return _Averti;
            }

            set
            {
                _Averti = value;
                EventAmi?.Invoke("Averti", value);
            }
        }

        public void Reset()
        {
            _Personnage = new Dictionary<string, Information>();
        }
    }

    public class Information
    {
        public bool Ajoute = false;
        public string Pseudo = "";
        public bool Connecte = false;
        public string Nom = "";
        public int Niveau = -1;
        public string Alignement = "";
        public string Classe = "";
        public string Sex = "";
        public string ClasseSex = "";
        public int Zone = -1;
    }
}
