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

namespace Groupe_Variable
{
    public class Base
    {
        public bool Groupe = false;
        public bool Invitation = false;
        public string Inviteur = "";
        public string Inviter = "";
        public Dictionary<int, Information> Membre = new Dictionary<int, Information>();
        public int ID = -1;
        public string Coordonnees = "";
        public int Chef = -1;
    }

    public class Information
    {
        public int ID = -1;
        public string Nom = "";
        public int ClasseSexe = -1;
        public string Couleur1 = "";
        public string Couleur2 = "";
        public string Couleur3 = "";

        public Map_Variable.Equipement Equipement = new Map_Variable.Equipement();

        public MinMax Vitaliter = new MinMax();

        public int Niveau = -1;
        public int Initiative = -1;
        public int Prospection = -1;
    }
}
