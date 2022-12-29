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

namespace Metier_Variable
{
    public class Base
    {
        public string Nom = "";
        public int ID = -1;
        public int Niveau = -1;
        public bool ItemEquipe = false;
        public MinMax Experience = new MinMax();
        public string Action = "";
        public bool NeFournitAucuneRessource = false;
        public bool GratuitSurEchec = false;
        public bool Payant = false;
        public int NombreIngredientMinimum = -1;
        public bool ModePublic = false;

        public Dictionary<int, Atelier> Atelier = new Dictionary<int, Atelier>();
    }

    public class Atelier
    {
        public string Nom = "";
        public int ID = -1;
        public string Action = "";
        public MinMax NombreCaseRecolte = new MinMax();
        public int TempsReussite = -1;
    }
}
