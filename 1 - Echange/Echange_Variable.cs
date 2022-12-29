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

namespace Echange_Variable
{
    public class Base
    {
        public string Interaction = "";
        public bool Echange = false;
        public bool Invitation = false;
        public int ID = -1;
        public Information Moi = new Information();
        public Information Lui = new Information();
    }

    public class Information
    {
        public Item_Variable.Base Inventaire = new Item_Variable.Base();
        public int Kamas = -1;
        public bool Valider = false;
    }
}
