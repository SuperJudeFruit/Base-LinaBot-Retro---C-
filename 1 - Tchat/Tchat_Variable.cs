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

namespace Tchat_Variable
{
    public class Base
    {
        public event EventTchatEventHandler EventTchat;

        public delegate void EventTchatEventHandler(string Choix, object value);

        private List<Information> _Message = new List<Information>();
        public object Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message.Add(value);
                EventTchat?.Invoke("Message", value);
            }
        }

        private Canaux _Canaux = new Canaux();
        public Canaux Canaux
        {
            get
            {
                return _Canaux;
            }

            set
            {
                _Canaux = value;
                EventTchat?.Invoke("Canal", value);
            }
        }
    }

    public class Information
    {
        public DateTime Heure = DateTime.TimeOfDay;
        public string Canal = "";
        public int Id_Joueur = 0;
        public string Nom_Joueur = "";
        public string Message = "";
        public string Item = "";
        public Color Couleur = Color.White;
    }

    public class Canaux
    {
        public bool Information = false;
        public bool Commun = false;
        public bool GroupeEquipeMP = false;
        public bool Guilde = false;
        public bool Alignement = false;
        public bool Recrutement = false;
        public bool Commerce = false;
        public bool Evenement = false;
    }
}
